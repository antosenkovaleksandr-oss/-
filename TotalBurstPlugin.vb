Imports System
Imports System.IO
Imports System.Linq
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

' Псевдонимы для устранения неоднозначности типов
Imports AcApp = Autodesk.AutoCAD.ApplicationServices.Application
Imports WinForms = System.Windows.Forms
Imports CadColors = Autodesk.AutoCAD.Colors

Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry

Namespace KBStudio
    Public Class TotalBurstPlugin
        ' Структура данных для таблицы
        Public Class LayerInfo
            Public Property Name As String
            Public Property Count As Integer
            Public Property CurrentColorObj As CadColors.Color
            Public Property CurrentColorName As String
            Public Property NewColor As CadColors.Color
        End Class

        <CommandMethod("KBS_TotalBurst")>
        Public Sub TotalBurst()
            Dim doc As Document = AcApp.DocumentManager.MdiActiveDocument
            Dim db As Database = doc.Database
            Dim ed = doc.Editor
            Dim layerStats As New Dictionary(Of String, Integer)()

            Using tr As Transaction = db.TransactionManager.StartTransaction()
                Try
                    Dim ms As BlockTableRecord = tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForRead)

                    ' 1. Сбор статистики по блокам (рекурсивно)
                    ScanBlocksAndLayers(ms, tr, layerStats)

                    ' 2. Подготовка данных для формы
                    Dim layersData As New List(Of LayerInfo)()
                    Dim lt As LayerTable = tr.GetObject(db.LayerTableId, OpenMode.ForRead)

                    If layerStats.Count > 0 Then
                        For Each pair In layerStats
                            Dim ltr As LayerTableRecord = tr.GetObject(lt(pair.Key), OpenMode.ForRead)
                            layersData.Add(New LayerInfo() With {
                                .Name = pair.Key,
                                .Count = pair.Value,
                                .CurrentColorObj = ltr.Color,
                                .CurrentColorName = ltr.Color.ToString(),
                                .NewColor = ltr.Color
                            })
                        Next

                        ' 3. Вызов формы (с использованием псевдонима AcApp)
                        Dim frm As New LayerSettingsForm(layersData)
                        If AcApp.ShowModalDialog(frm) <> WinForms.DialogResult.OK Then Return

                        ' 4. Применение новых цветов к слоям
                        For Each info In frm.FinalData
                            Dim ltr As LayerTableRecord = tr.GetObject(lt(info.Name), OpenMode.ForWrite)
                            ltr.Color = info.NewColor
                            ltr.IsLocked = False
                            ltr.IsOff = False
                            If Not ltr.ObjectId = db.LayerZero Then ltr.IsFrozen = False
                        Next

                        ' 5. Рекурсивный взрыв
                        RunDeepExplode(db, tr)
                    End If

                    ' 6. Глобальная унификация объектов ByLayer
                    ms.UpgradeOpen()
                    Dim totalEnts As Integer = 0
                    For Each id As ObjectId In ms
                        If id.IsValid AndAlso Not id.IsErased Then
                            Dim ent As Entity = tr.GetObject(id, OpenMode.ForWrite)
                            ent.ColorIndex = 256 ' ByLayer
                            ent.LineWeight = LineWeight.ByLayer
                            ent.Linetype = "ByLayer"
                            totalEnts += 1
                        End If
                    Next

                    PurgeUnusedBlocks(db, tr)
                    tr.Commit()
                    ed.WriteMessage(vbLf & "Команда KBS_TotalBurst завершена успешно. Объектов приведено к ByLayer: {0}", totalEnts)

                Catch ex As System.Exception
                    ed.WriteMessage(vbLf & "Ошибка: " & ex.Message)
                    tr.Abort()
                End Try
            End Using
        End Sub

        Private Sub ScanBlocksAndLayers(btr As BlockTableRecord, tr As Transaction, ByRef stats As Dictionary(Of String, Integer))
            For Each id As ObjectId In btr
                Dim ent As Entity = tr.GetObject(id, OpenMode.ForRead)
                If TypeOf ent Is BlockReference Then
                    Dim br As BlockReference = DirectCast(ent, BlockReference)
                    If stats.ContainsKey(br.Layer) Then stats(br.Layer) += 1 Else stats.Add(br.Layer, 1)
                    Dim subBtr As BlockTableRecord = tr.GetObject(br.BlockTableRecord, OpenMode.ForRead)
                    ScanBlocksAndLayers(subBtr, tr, stats)
                End If
            Next
        End Sub

        Private Sub RunDeepExplode(db As Database, tr As Transaction)
            Dim ms As BlockTableRecord = tr.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), OpenMode.ForWrite)
            Dim blocksExist As Boolean = True
            Dim safetyCounter As Integer = 0
            While blocksExist And safetyCounter < 100
                Dim found As Boolean = False
                Dim currentIds As ObjectId() = ms.Cast(Of ObjectId)().ToArray()
                For Each id In currentIds
                    If Not id.IsValid Or id.IsErased Then Continue For
                    Dim ent As Entity = tr.GetObject(id, OpenMode.ForRead)
                    If TypeOf ent Is BlockReference Then
                        Dim br As BlockReference = DirectCast(ent, BlockReference)
                        found = True
                        ProcessAttributesToMText(br, ms, tr)
                        Using explodedObjs As New DBObjectCollection()
                            br.Explode(explodedObjs)
                            For Each obj As Entity In explodedObjs
                                obj.Layer = br.Layer
                                ms.AppendEntity(obj)
                                tr.AddNewlyCreatedDBObject(obj, True)
                            Next
                        End Using
                        br.UpgradeOpen() : br.Erase()
                    End If
                Next
                blocksExist = found
                safetyCounter += 1
            End While
        End Sub

        Private Sub ProcessAttributesToMText(br As BlockReference, ms As BlockTableRecord, tr As Transaction)
            For Each attId As ObjectId In br.AttributeCollection
                Dim attRef As AttributeReference = tr.GetObject(attId, OpenMode.ForRead)
                If Not attRef.Invisible Then
                    Dim mt As New MText()
                    mt.SetDatabaseDefaults()
                    mt.Layer = br.Layer
                    mt.Contents = Regex.Replace(attRef.TextString, "(\\L|\\l|\\O|\\o|\\X|\\S[^;]*;|\\S|\\A[^;]*;|\\C[^;]*;|\\H[^;]*;|\\T[^;]*;|\\Q[^;]*;|\\W[^;]*;|\\f[^;]*;|\{|\})", "").Replace("\P", vbCrLf)
                    mt.Location = attRef.Position
                    mt.TextHeight = attRef.Height
                    mt.Rotation = attRef.Rotation
                    mt.Attachment = attRef.Justify
                    ms.AppendEntity(mt)
                    tr.AddNewlyCreatedDBObject(mt, True)
                End If
            Next
        End Sub

        Private Sub PurgeUnusedBlocks(db As Database, tr As Transaction)
            Dim bt As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            Dim idsToPurge As New ObjectIdCollection()
            For Each id As ObjectId In bt : idsToPurge.Add(id) : Next
            db.Purge(idsToPurge)
            For Each id As ObjectId In idsToPurge
                Dim btr As BlockTableRecord = tr.GetObject(id, OpenMode.ForWrite)
                If Not btr.IsLayout Then btr.Erase()
            Next
        End Sub
    End Class

    ' КЛАСС ГРАФИЧЕСКОЙ ФОРМЫ
    Public Class LayerSettingsForm
        Inherits WinForms.Form
        Public FinalData As List(Of TotalBurstPlugin.LayerInfo)
        Private dgv As DataGridView
        Private bs As BindingSource

        Public Sub New(data As List(Of TotalBurstPlugin.LayerInfo))
            Me.Text = "KBS: Настройка слоев"
            Me.Size = New System.Drawing.Size(750, 500)
            Me.StartPosition = FormStartPosition.CenterParent
            Me.FinalData = data
            Me.bs = New BindingSource(data, Nothing)

            ' Панель управления
            Dim pnlBottom As New Panel() With {.Dock = DockStyle.Bottom, .Height = 60}
            Dim btnOk As New Button() With {.Text = "ВЫПОЛНИТЬ", .Width = 160, .Height = 40, .Location = New System.Drawing.Point(560, 10), .DialogResult = WinForms.DialogResult.OK, .Font = New System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold)}
            Dim btnAllColors As New Button() With {.Text = "ОДИН ЦВЕТ ВСЕМ", .Width = 160, .Height = 40, .Location = New System.Drawing.Point(10, 10)}

            AddHandler btnAllColors.Click, Sub()
                                               Dim colDlg As New Autodesk.AutoCAD.Windows.ColorDialog()
                                               ' Системный заголовок по умолчанию
                                               Me.Hide()
                                               Dim dr As WinForms.DialogResult = colDlg.ShowDialog()
                                               Me.Show()
                                               If dr = WinForms.DialogResult.OK Then
                                                   For Each item In FinalData : item.NewColor = colDlg.Color : Next
                                                   bs.ResetBindings(False)
                                               End If
                                           End Sub
            pnlBottom.Controls.Add(btnAllColors) : pnlBottom.Controls.Add(btnOk)

            ' Настройка таблицы (ReadOnly)
            dgv = New DataGridView() With {
                .Dock = DockStyle.Fill,
                .AllowUserToAddRows = False,
                .AutoGenerateColumns = False,
                .DataSource = bs,
                .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                .RowHeadersVisible = False,
                .AllowUserToResizeRows = False
            }

            ' Добавление колонок с русскими заголовками
            dgv.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Name", .HeaderText = "Слой", .FillWeight = 35})
            dgv.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "Count", .HeaderText = "Найдено", .FillWeight = 15})
            dgv.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "CurrentColorName", .HeaderText = "Текущий цвет", .FillWeight = 25})
            dgv.Columns.Add(New DataGridViewTextBoxColumn() With {.DataPropertyName = "NewColor", .HeaderText = "Новый цвет", .FillWeight = 25})

            ' Отрисовка цветов в ячейках
            AddHandler dgv.CellFormatting, Sub(sender, e)
                                               If e.RowIndex < 0 Then Return
                                               If e.ColumnIndex = 2 Then ApplyCellColor(e, FinalData(e.RowIndex).CurrentColorObj)
                                               If e.ColumnIndex = 3 Then ApplyCellColor(e, FinalData(e.RowIndex).NewColor)
                                           End Sub

            ' Выбор цвета по двойному клику ПО ВСЕЙ СТРОКЕ
            AddHandler dgv.CellDoubleClick, Sub(sender, e)
                                                If e.RowIndex < 0 Then Return
                                                Dim colDlg As New Autodesk.AutoCAD.Windows.ColorDialog()
                                                ' Системный заголовок по умолчанию
                                                Me.Hide()
                                                Dim dr As WinForms.DialogResult = colDlg.ShowDialog()
                                                Me.Show()
                                                If dr = WinForms.DialogResult.OK Then
                                                    FinalData(e.RowIndex).NewColor = colDlg.Color
                                                    bs.ResetBindings(False)
                                                End If
                                            End Sub

            Me.Controls.Add(dgv)
            Me.Controls.Add(New Label() With {.Text = " Двойной клик по строке для выбора цвета", .Dock = DockStyle.Top, .Height = 30, .TextAlign = System.Drawing.ContentAlignment.MiddleLeft, .BackColor = System.Drawing.Color.LightSteelBlue})
            Me.Controls.Add(pnlBottom)
        End Sub

        Public Property Dgv1 As DataGridView
            Get
                Return dgv
            End Get
            Set(value As DataGridView)
                dgv = value
            End Set
        End Property

        Public Property Bs1 As BindingSource
            Get
                Return bs
            End Get
            Set(value As BindingSource)
                bs = value
            End Set
        End Property

        Private Sub ApplyCellColor(e As DataGridViewCellFormattingEventArgs, acCol As CadColors.Color)
            Dim drawCol = acCol.ColorValue
            e.CellStyle.BackColor = drawCol
            e.CellStyle.ForeColor = If(drawCol.GetBrightness() < 0.5, System.Drawing.Color.White, System.Drawing.Color.Black)
            e.Value = acCol.ToString()
            e.FormattingApplied = True
        End Sub
    End Class
End Namespace


