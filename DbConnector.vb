Imports MySql.Data.MySqlClient

Namespace KBStudio
    Public Class DbConnector
        ' Строка подключения к твоему серверу на Hoster.ru
        ' ВАЖНО: После тестов обязательно смени пароль в панели хостинга и обнови его здесь
        Private Shared ReadOnly ConnectionString As String =
            "server=mysql-246398.srv.hoster.ru;user=srv246398_1;database=srv246398_database;password=19702003;SslMode=Preferred;"

        ''' <summary>
        ''' Простая проверка связи с сервером
        ''' </summary>
        Public Shared Function TestConnection() As Boolean
            Using conn As New MySqlConnection(ConnectionString)
                Try
                    conn.Open()
                    Return True
                Catch ex As Exception
                    ' Здесь можно вывести сообщение об ошибке для отладки
                    Debug.WriteLine("Ошибка БД: " & ex.Message)
                    Return False
                End Try
            End Using
        End Function

        ''' <summary>
        ''' Пример получения данных: считаем количество строк в таблице my_tasks
        ''' </summary>
        Public Shared Function GetTaskCount() As Integer
            Using conn As New MySqlConnection(ConnectionString)
                Try
                    conn.Open()
                    Dim sql As String = "SELECT COUNT(*) FROM my_tasks"
                    Dim cmd As New MySqlCommand(sql, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                Catch ex As Exception
                    Return -1
                End Try
            End Using
        End Function

        ''' <summary>
        ''' Безопасная вставка данных (защита от SQL-инъекций через параметры)
        ''' </summary>
        Public Shared Sub AddTask(taskName As String)
            Using conn As New MySqlConnection(ConnectionString)
                Try
                    conn.Open()
                    Dim sql As String = "INSERT INTO my_tasks (task_name) VALUES (@name)"
                    Dim cmd As New MySqlCommand(sql, conn)
                    ' Используем параметры вместо прямой склейки строк — это стандарт безопасности
                    cmd.Parameters.AddWithValue("@name", taskName)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Throw New Exception("Не удалось сохранить задачу: " & ex.Message)
                End Try
            End Using
        End Sub

    End Class
End Namespace
