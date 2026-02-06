Imports System.IO
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.Runtime

Namespace KBStudio

    Public Class AcMethod
        Public Shared Sub CreateNewDrawing(ByVal TemplateID As String) 'Cоздание нового чертежа по заданному шаблону TemplateID
            ' Получаем менеджер документов
            Dim acDocMgr As DocumentCollection = Application.DocumentManager
            ' Создаем новый документ на основе шаблона
            Dim acDoc As Document = DocumentCollectionExtension.Add(acDocMgr, TemplateID)
            ' Делаем его активным
            acDocMgr.MdiActiveDocument = acDoc
        End Sub
        Public Shared Sub SetDrawingPropertiesDefault() 'Установка свойств чертежа по умолчанию
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim db As Database = doc.Database

            ' Используем билдер на основе текущих свойств
            ' Установка стандартных свойств
            Dim infoBuilder As New DatabaseSummaryInfoBuilder(db.SummaryInfo) With {
                .Title = My.Application.Info.Title,
                .Author = My.Application.Info.CompanyName,
                .Subject = My.Application.Info.ProductName,
                .Comments = My.Application.Info.Copyright,
                .Keywords = "версия " & My.Application.Info.Version.ToString,
                .HyperlinkBase = My.Application.Info.Description
            }

            ' Добавление или изменение пользовательских свойств (Custom Properties)
            ' Если свойство с таким ключом уже есть, оно обновится
            'If infoBuilder.CustomPropertyTable.Contains("Проект") Then
            '    infoBuilder.CustomPropertyTable("Проект") = "Объект №101"
            'Else
            '    infoBuilder.CustomPropertyTable.Add("Проект", "Объект №101")
            'End If

            ' Применяем изменения к базе данных чертежа
            db.SummaryInfo = infoBuilder.ToDatabaseSummaryInfo()
        End Sub



        Public Sub InsertMyBlock(ByVal blockName As String)  'Вставка блока blockName (ИМЯ_ВАШЕГО_БЛОКА) из текущего чертежа
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim db As Database = doc.Database
            Dim ed As Editor = doc.Editor
            ' 1. Начать транзакцию
            Using tr As Transaction = db.TransactionManager.StartTransaction()
                ' 2. Открыть таблицу блоков для чтения
                Dim bt As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
                If bt.Has(blockName) Then
                    ' 3. Получить запись блока
                    Dim btrId As ObjectId = bt(blockName)
                    Dim btr As BlockTableRecord = tr.GetObject(btrId, OpenMode.ForRead)
                    ' 4. Открыть текущее пространство (ModelSpace) для записи
                    Dim currentSpace As BlockTableRecord = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite)
                    ' 5. Создать BlockReference (ссылку на блок)
                    Dim position As New Point3d(0, 0, 0) ' Точка вставки
                    Dim br As New BlockReference(position, btrId)
                    ' 6. Добавить BlockReference в пространство
                    currentSpace.AppendEntity(br)
                    tr.AddNewlyCreatedDBObject(br, True)
                    ' 7. (Опционально) Обработка атрибутов блока
                    If btr.HasAttributeDefinitions Then
                        For Each id As ObjectId In btr
                            Dim obj As DBObject = tr.GetObject(id, OpenMode.ForRead)
                            Dim attDef As AttributeDefinition = TryCast(obj, AttributeDefinition)
                            If attDef IsNot Nothing AndAlso Not attDef.Constant Then
                                Dim attRef As New AttributeReference()
                                attRef.SetAttributeFromBlock(attDef, br.BlockTransform)
                                attRef.Position = attDef.Position.TransformBy(br.BlockTransform)
                                br.AttributeCollection.AppendAttribute(attRef)
                                tr.AddNewlyCreatedDBObject(attRef, True)
                            End If
                        Next
                    End If
                Else
                    ed.WriteMessage(vbLf & "Блок не найден: " & blockName)
                End If
                ' 8. Зафиксировать транзакцию
                tr.Commit()
            End Using
        End Sub



        Public Sub InsertExternalBlock(ByVal dwgPath As String) 'Вставка блока dwgPath (ИМЯ_ВАШЕГО_БЛОКА) из внешнего чертежа
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim db As Database = doc.Database
            Dim ed As Editor = doc.Editor

            ' Путь к внешнему файлу
            'Dim dwgPath As String = "C:\Path\To\Your\Block.dwg"

            Using tr As Transaction = db.TransactionManager.StartTransaction()
                Dim bt As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
                Dim btrModel As BlockTableRecord = tr.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

                ' Создаем новую базу данных для внешнего файла
                Using dbExternal As New Database(False, True)
                    dbExternal.ReadDwgFile(dwgPath, FileShare.Read, True, "")

                    ' Импортируем блок из внешней БД в текущую
                    Dim blockId As ObjectId = db.Insert(System.IO.Path.GetFileNameWithoutExtension(dwgPath), dbExternal, False)

                    ' Создаем вхождение блока
                    Dim blockRef As New BlockReference(New Point3d(0, 0, 0), blockId)
                    btrModel.AppendEntity(blockRef)
                    tr.AddNewlyCreatedDBObject(blockRef, True)
                End Using

                tr.Commit()
            End Using
        End Sub

        Public Sub InsertExternalBlockLibrary(ByVal blockPath As String, ByVal blockName As String)    'Вставка блока из внешней библиотеки блоков
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim db As Database = doc.Database
            Dim ed As Editor = doc.Editor

            ' Путь к файлу библиотеки
            'Dim blockPath As String = "C:\Path\To\Your\Library.dwg"
            'Dim blockName As String = "YourBlockName" ' Имя блока внутри файла

            Using tr As Transaction = db.TransactionManager.StartTransaction()
                ' 1. Открыть внешнюю базу данных
                Using sourceDb As New Database(False, True)
                    sourceDb.ReadDwgFile(blockPath, FileOpenMode.OpenForReadAndAllShare, False, "")

                    ' 2. Импортировать блок
                    Dim idMapping As New IdMapping()
                    Dim blockIds As New ObjectIdCollection()

                    Using sourceTr As Transaction = sourceDb.TransactionManager.StartTransaction()
                        Dim sourceBT As BlockTable = sourceTr.GetObject(sourceDb.BlockTableId, OpenMode.ForRead)
                        If sourceBT.Has(blockName) Then
                            blockIds.Add(sourceBT(blockName))
                            sourceDb.WblockCloneObjects(blockIds, db.BlockTableId, idMapping, DuplicateRecordCloning.Replace, False)
                        End If
                        sourceTr.Commit()
                    End Using
                End Using

                ' 3. Вставить вхождение блока
                Dim bt As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
                Dim btrModelSpace As BlockTableRecord = tr.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

                If bt.Has(blockName) Then
                    Dim blockId As ObjectId = bt(blockName)
                    Dim br As New BlockReference(New Point3d(0, 0, 0), blockId) ' Точка вставки
                    btrModelSpace.AppendEntity(br)
                    tr.AddNewlyCreatedDBObject(br, True)
                End If

                tr.Commit()
            End Using
        End Sub
    End Class
End Namespace

