Imports System.Data.SqlClient




Public Class login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        dbConnection()
        Dim strQuery As String

        Try
            strQuery = "INSERT INTO auditlogs (`Uname`, `logType`) " +
                "VALUES ('" & txtUsername.Text & "')"


            If txtUsername.Text.Length <= 0 Then
                MessageBox.Show("Please enter username")
            ElseIf txtPassword.Text.Length <= 0 Then
                MessageBox.Show("Please enter password")
            End If

            Dim user As String = txtUsername.Text
            Dim pass As String = txtPassword.Text

            FunctionLogin(user, pass)

        Catch ex As Exception

        End Try


    End Sub
End Class