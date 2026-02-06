Imports System.Windows.Forms
Imports System.Drawing
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.EditorInput

' Псевдоним для устранения конфликта имен Application
Imports AcApp = Autodesk.AutoCAD.ApplicationServices.Application

Namespace KBStudio
    Public Class OleBlockCreator

        ''' <summary>
        ''' Создает определение блока в библиотеке чертежа. Содержимое принудительно на слое 0.
        ''' </summary>
        Public Sub DefineLibraryBlock(blockName As String, w As Double, h As Double, posX As Double, posY As Double)
            Dim doc = AcApp.DocumentManager.MdiActiveDocument
            Dim db = doc.Database
            Dim ed = doc.Editor

            ' 1. Выбор файла
            Dim ofd As New OpenFileDialog With {
                .Filter = "Изображения|*.png;*.jpg;*.bmp",
                .Title = "Выберите файл для " & blockName
            }

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            Try
                ' 2. Внедрение данных
                Using img = Drawing.Image.FromFile(ofd.FileName)
                    Clipboard.SetImage(img)
                End Using

                Using tr = db.TransactionManager.StartTransaction()
                    Dim bt = DirectCast(tr.GetObject(db.BlockTableId, OpenMode.ForWrite), BlockTable)

                    ' 3. Создание или очистка определения блока
                    Dim btr As BlockTableRecord
                    If Not bt.Has(blockName) Then
                        btr = New BlockTableRecord With {
                            .Name = blockName,
                            .Annotative = AnnotativeStates.True,
                            .Units = UnitsValue.Undefined
                        }
                        bt.Add(btr)
                        tr.AddNewlyCreatedDBObject(btr, True)
                    Else
                        btr = DirectCast(tr.GetObject(bt(blockName), OpenMode.ForWrite), BlockTableRecord)
                        For Each id As ObjectId In btr
                            tr.GetObject(id, OpenMode.ForWrite).Erase()
                        Next
                    End If

                    ' 4. Создание OLE2Frame
                    Dim ole As New Ole2Frame()
                    btr.AppendEntity(ole)
                    tr.AddNewlyCreatedDBObject(ole, True)

                    ' --- ПРИВЯЗКА К СЛОЮ 0 ---
                    ' Убеждаемся, что содержимое внутри блока всегда на слое 0
                    ole.Layer = "0"

                    ' 5. Настройка размеров и позиции
                    ole.WcsWidth = w
                    ole.WcsHeight = h

                    ' Перемещение объекта внутри блока
                    Dim moveVec As New Vector3d(posX, posY, 0)
                    ole.TransformBy(Matrix3d.Displacement(moveVec))

                    tr.Commit()
                End Using

                ed.WriteMessage(vbLf & "Блок '{0}' обновлен. Содержимое на слое 0.", blockName)
                Clipboard.Clear()

            Catch ex As System.Exception
                ed.WriteMessage(vbLf & "Ошибка KBStudio: " & ex.Message)
            End Try
        End Sub

    End Class
End Namespace
