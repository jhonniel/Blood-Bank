Imports MySql.Data.MySqlClient
Module modBloodBank
    ' establishes connection to a MySQL Server Database
    Private dbConn As MySqlConnection

    ' represents an SQL statement to execute against a MySQL database
    Private sqlCommand As MySqlCommand

    ' represents a set of data commands and a database connection that are used to fill
    ' a dataset and update a MySQL database
    Private da As MySqlDataAdapter

    ' it is an in-memory representation of structured data (like data read from a database)
    Private dt As DataTable

    ' sets the string used to connect to a MySQL server database
    Dim strConn As String = "Server=localhost; User ID=root; Database=dbbloodbank; " +
                            "Convert Zero Datetime=True;"

    Private checker As MySqlDataReader

    Public Sub dbConnection()

        Try
            dbConn = New MySqlConnection(strConn)
            dbConn.Open()
            MessageBox.Show("DB test connection is successful.", "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: DBConnection() " & ex.Message, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DisplayRecords(ByVal strSQL As String, ByVal dg As DataGridView)
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)
            dg.DataSource = dt
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: DisplayRecords() " & ex.Message, "Blood Bank DBMS",
                             MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub SQLManager(ByVal strSQL As String, ByVal strMsg As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(strSQL, dbConn)
            With sqlCommand
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            dbConn.Close()
            MessageBox.Show(strMsg, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error: SQLManager() " & ex.Message, "Blood Bank DBMS",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub FunctionLogin(ByVal user As String, ByVal pass As String)
        Try
            dbConn = New MySqlConnection(strConn)
            dbConn.Open()

            Dim sqlQuery As String = "SELECT Username, Password FROM tbluser WHERE Username = '" + user + "' AND Password = '" + pass + "'"

            sqlCommand = New MySqlCommand(sqlQuery, dbConn)
            checker = sqlCommand.ExecuteReader()

            If (checker.Read() = True) Then
                frmMain.Show()
                login.Hide()
            Else
                MessageBox.Show("Incorrect username or password.")
            End If
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function RecordCount() As Integer
        Dim count As Integer = 0
        Dim strSQL As String = "SELECT * FROM patient ORDER BY PatientID DESC LIMIT 1"
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(strSQL, dbConn)
            dt = New DataTable
            da.Fill(dt)

            If dt.Rows.Count() > 0 Then
                count = dt.Rows(0).Item("PatientID")
            Else
                count = 0
            End If
            dbConn.Close()
        Catch ex As Exception
            MessageBox.Show("Error: RecordCount() " & ex.Message, "Pet DBMS",
                             MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return count
    End Function
End Module
