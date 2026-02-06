Imports System.IO
Imports System.Reflection
Imports System.Windows.Forms
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime
' Устраняем неоднозначность Application
Imports AcApp = Autodesk.AutoCAD.ApplicationServices.Application
Imports WinApp = System.Windows.Forms.Application

Namespace KBStudio

    Public Class AcFunction

        Public Shared Function EnsureFileSaved(doc As Document) As Boolean
            Dim db As Database = doc.Database

            ' Если файл новый (не существует на диске)
            If String.IsNullOrEmpty(db.Filename) OrElse Not File.Exists(db.Filename) Then
                Dim result As DialogResult = MessageBox.Show(
            "Для определения папки необходимо сохранить текущий чертеж. Сохранить сейчас?",
            "KBStudio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' 1. Берем имя прямо с вкладки (doc.Name)
                    Dim tabName As String = Path.GetFileName(doc.Name)

                    ' 2. Определяем папку (если есть временная — берем её, иначе "Мои документы")
                    Dim initialDir As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    If Not String.IsNullOrEmpty(db.Filename) Then
                        Try
                            initialDir = Path.GetDirectoryName(db.Filename)
                        Catch
                        End Try
                    End If

                    Dim saveOpts As New PromptSaveFileOptions("Выберите место для сохранения") With {
                .Filter = "Чертеж AutoCAD (*.dwg)|*.dwg",
                .DialogCaption = "KBStudio: Сохранить как",
                .InitialFileName = tabName, ' Имя как на вкладке
                .InitialDirectory = initialDir
            }

                    Dim saveRes As PromptFileNameResult = doc.Editor.GetFileNameForSave(saveOpts)

                    If saveRes.Status = PromptStatus.OK Then
                        Try
                            ' Сохраняем и обновляем заголовок
                            db.SaveAs(saveRes.StringResult, DwgVersion.Current)
                            doc.Database.SaveAs(saveRes.StringResult, DwgVersion.Current)
                            Return True
                        Catch ex As System.Exception
                            MessageBox.Show("Ошибка при сохранении: " & ex.Message)
                            Return False
                        End Try
                    End If
                    Return False
                Else
                    Return False
                End If
            End If
            Return True
        End Function


        Public Shared Function GetDrawingInfo(ByRef Optional typeName As Short = 0) As String     'имя или полный путь текущего чертежа
            ' Доступ к активному документу
            Dim doc As Document = AcApp.DocumentManager.MdiActiveDocument
            Select Case typeName
                Case 0
                    'Полный путь к файлу чертежа (включая имя)
                    Return doc.Name
                Case 1
                    'Только имя файла (без пути, но с расширением)
                    Return Path.GetFileName(doc.Name)
                Case Else
                    'Только имя (без пути, без расширением)
                    Return Path.GetFileNameWithoutExtension(doc.Name)
            End Select
        End Function

        Public Function IsBlockExists(ByVal blockName As String) As Boolean   'Проверка наличия определения блока в текущем чертеже
            Dim db As Database = HostApplicationServices.WorkingDatabase
            Dim exists As Boolean = False

            Using tr As Transaction = db.TransactionManager.StartTransaction()
                ' Получаем таблицу блоков чертежа
                Dim bt As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)

                ' Метод Has проверяет наличие имени в таблице
                If bt.Has(blockName) Then
                    exists = True
                End If

                tr.Commit()
            End Using

            Return exists
        End Function

        Public Function IsBlockInExternalFile(filePath As String, blockName As String) As Boolean   'Проверка наличия определения блока во внешнем чертеже
            ' Проверяем существование самого файла
            If Not File.Exists(filePath) Then Return False

            Using externalDb As New Database(False, True)
                Try
                    ' Считываем файл (без открытия в редакторе)
                    externalDb.ReadDwgFile(filePath, FileShare.Read, True, "")

                    Using tr As Transaction = externalDb.TransactionManager.StartTransaction()
                        ' Получаем таблицу блоков внешнего файла
                        Dim bt As BlockTable = tr.GetObject(externalDb.BlockTableId, OpenMode.ForRead)

                        ' Проверяем, есть ли блок с таким именем
                        If bt.Has(blockName) Then
                            Return True
                        End If
                    End Using
                Catch
                    ' Ошибка чтения файла или доступа
                    Return False
                End Try
            End Using
            Return False
        End Function
    End Class
End Namespace

