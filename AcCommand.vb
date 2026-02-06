
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Windows
Imports System.Windows.Forms
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime
Imports Application = Autodesk.AutoCAD.ApplicationServices.Application
'Объявление псевдонима для класса Application
Imports AcApp = Autodesk.AutoCAD.ApplicationServices.Application

Namespace KBStudio
    Public Class AcCommand

        <CommandMethod("KBS_NewDrawingCAD")> ' Имя команды в AutoCAD
        Public Sub MyNewDrawingCAD()
            Dim str As String = "Cоздание нового чертежа ACAD"
            'Однострочное сообщение в командной строке
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim ed As Editor = doc.Editor
            ed.WriteMessage(str)
            'Cоздание нового чертежа
            AcMethod.CreateNewDrawing(Path.Combine(PluginSettings.TemplatePath, PluginSettings.TemplateCAD))
        End Sub

        <CommandMethod("KBS_NewDrawingCVL")> ' Имя команды в AutoCAD
        Public Sub MyNewDrawingCVL()
            Dim str As String = "Cоздание нового чертежа CIVIL"
            'Однострочное сообщение в командной строке
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim ed As Editor = doc.Editor
            ed.WriteMessage(str)
            'Cоздание нового чертежа
            AcMethod.CreateNewDrawing(Path.Combine(PluginSettings.TemplatePath, PluginSettings.TemplateCVL))
        End Sub

        <CommandMethod("KBS_OpenDrawing")>
        Public Sub MyOpenDrawing()
            Dim docMgr As DocumentCollection = Application.DocumentManager
            Dim activeDoc As Document = docMgr.MdiActiveDocument

            activeDoc.Editor.WriteMessage(vbCrLf & "Открытие существующего чертежа")

            Dim startDir = If(activeDoc.IsNamedDrawing, Path.GetDirectoryName(activeDoc.Database.Filename), Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))

            Dim ofd As New OpenFileDialog With {
        .Title = "Выберите чертеж",
        .Filter = "DWG|*.dwg",
        .InitialDirectory = startDir
    }

            If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim newDoc = docMgr.Open(ofd.FileName, False)
                docMgr.MdiActiveDocument = newDoc
                newDoc.SendStringToExecute("._ZOOM _E ", True, False, False)
            End If
        End Sub

        <CommandMethod("KBS_ProjectInfo")> ' Имя команды в AutoCAD
        Public Sub MyProjectInfo()
            ' --- Ваши переменные и сообщение в консоль ---
            Dim str As String = "Информация о текущем проекте"
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim ed As Editor = doc.Editor
            ed.WriteMessage(vbCrLf & str)
            ' ----------------------------------------------

            ' Запуск формы
            Using frm As New FormProject()
                Application.ShowModalDialog(frm)
            End Using
        End Sub

    End Class
End Namespace

