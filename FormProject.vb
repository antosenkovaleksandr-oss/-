Imports System.Windows.Forms
Imports Autodesk.AutoCAD.DatabaseServices
Imports KBStudio.KBStudio

Public Class FormProject

    ' 1. Событие загрузки формы
    Private Sub FormProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'заголовок формы
        Me.Text = AcFunction.GetDrawingInfo(2)
        'поиск контролов во всех вложенных контейнерах, проверка / создание свойств в DWG и их загрузка в контролы
        Me.SyncAndLoadDwgProperties()
    End Sub

    ' 2. Логика синхронизации свойств чертежа и формы
    Private Sub SyncAndLoadDwgProperties()
        Dim db As Database = HostApplicationServices.WorkingDatabase
        Dim infoBuilder As New DatabaseSummaryInfoBuilder(db.SummaryInfo)
        Dim custProps = infoBuilder.CustomPropertyTable
        Dim isChanged As Boolean = False

        ' Рекурсивно собираем все ComboBox, TextBox, DateTimePicker
        Dim allControls As New List(Of Control)
        FindControlsRecursive(Me, allControls)

        For Each ctrl In allControls
            Dim propName As String = ctrl.Name

            If Not custProps.Contains(propName) Then
                ' ПЕРЕНОС: Если поля нет в DWG — создаем и пишем значение из формы
                custProps.Add(propName, GetControlValue(ctrl))
                isChanged = True
            Else
                ' ЗАПОЛНЕНИЕ: Если поле есть — читаем из DWG в форму
                SetControlValue(ctrl, custProps(propName).ToString())
            End If
        Next

        ' Фиксируем новые поля в БД чертежа
        If isChanged Then
            db.SummaryInfo = infoBuilder.ToDatabaseSummaryInfo()
        End If
    End Sub

    ' 3. Кнопка СОХРАНИТЬ (ButtonSave) — запись измененных данных в чертеж
    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Try
            Dim db As Database = HostApplicationServices.WorkingDatabase
            Dim infoBuilder As New DatabaseSummaryInfoBuilder(db.SummaryInfo)
            Dim custProps = infoBuilder.CustomPropertyTable

            Dim allControls As New List(Of Control)
            FindControlsRecursive(Me, allControls)

            ' Записываем все значения из полей формы в свойства чертежа
            For Each ctrl In allControls
                Dim propName As String = ctrl.Name
                Dim val As String = GetControlValue(ctrl)

                If custProps.Contains(propName) Then
                    custProps(propName) = val
                Else
                    custProps.Add(propName, val)
                End If
            Next

            ' Обновляем метаданные чертежа
            db.SummaryInfo = infoBuilder.ToDatabaseSummaryInfo()

            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Ошибка при сохранении свойств: " & ex.Message)
        End Try
    End Sub

    ' --- ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ---

    ' Рекурсивный поиск контролов нужных типов во всех контейнерах
    Private Sub FindControlsRecursive(parent As Control, ByRef resultList As List(Of Control))
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox OrElse TypeOf ctrl Is DateTimePicker Then
                resultList.Add(ctrl)
            End If
            If ctrl.HasChildren Then
                FindControlsRecursive(ctrl, resultList)
            End If
        Next
    End Sub

    ' Чтение значения из контрола (с учетом типа)
    Private Function GetControlValue(ctrl As Control) As String
        If TypeOf ctrl Is DateTimePicker Then
            Return DirectCast(ctrl, DateTimePicker).Value.ToShortDateString()
        Else
            Return ctrl.Text
        End If
    End Function

    ' Запись значения в контрол (с учетом типа)
    Private Sub SetControlValue(ctrl As Control, value As String)
        If TypeOf ctrl Is TextBox OrElse TypeOf ctrl Is ComboBox Then
            ctrl.Text = value
        ElseIf TypeOf ctrl Is DateTimePicker Then
            Dim dt As DateTime
            If DateTime.TryParse(value, dt) Then
                DirectCast(ctrl, DateTimePicker).Value = dt
            End If
        End If
    End Sub

    ' Кнопка ОТМЕНА (предположим ButtonCancel)
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.KBSsoft.ru")
    End Sub

    ' Обработчик для кнопки Logo
    Private Sub ButtonCreateLogo_Click(sender As Object, e As EventArgs) Handles ButtonCreateLogo.Click
        RunBlockCreation("KBS_Logo_50x15", 50.0, 15.0, 135.0, 0.0)
    End Sub

    ' Обработчик для кнопки Top
    Private Sub ButtonCreateTop_Click(sender As Object, e As EventArgs) Handles ButtonCreateTop.Click
        RunBlockCreation("KBS_TopBlock_185x50", 185.0, 50.0, 20.0, 242.0)
    End Sub

    ' Обработчик для кнопки Bottom
    Private Sub ButtonCreateBottom_Click(sender As Object, e As EventArgs) Handles ButtonCreateBottom.Click
        RunBlockCreation("KBS_BottomBlock_185x200", 185.0, 200.0, 20.0, 222.0)
    End Sub

    ''' <summary>
    ''' Общий метод запуска процесса из формы
    ''' </summary>
    Private Sub RunBlockCreation(name As String, w As Double, h As Double, x As Double, y As Double)
        Dim doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument

        ' Блокировка документа обязательна при работе из формы
        Using loc As Autodesk.AutoCAD.ApplicationServices.DocumentLock = doc.LockDocument()
            Try
                Me.Hide() ' Скрываем форму, чтобы не мешала OpenFileDialog

                Dim creator As New KBStudio.OleBlockCreator()
                creator.DefineLibraryBlock(name, w, h, x, y)

            Catch ex As System.Exception
                doc.Editor.WriteMessage(vbLf & "Ошибка: " & ex.Message)
            Finally
                Me.Show() ' Показываем форму обратно
                doc.Window.Focus() ' Возвращаем фокус на окно AutoCAD
            End Try
        End Using
    End Sub
End Class