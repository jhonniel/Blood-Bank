Public Class frmMain



    Private Sub tryConn_Click(sender As Object, e As EventArgs)
        dbConnection()
    End Sub

    Private Sub DonorsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DonorsToolStripMenuItem.Click
        pnlDonors.Visible = True
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
    End Sub

    Private Sub DonationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonationsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = True
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
    End Sub

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = True
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
    End Sub

    Private Sub TransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = True
        pnlProducts.Visible = False
        pnlUsers.Visible = False
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = True
        pnlUsers.Visible = False
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = True
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        dbConnection()
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO tbluser (Username, Password, FirstName, LastName)" +
            "VALUES ('" + txtUsername.Text + "', '" + txtPassword.Text + "' " +
                     ", '" + txtFirstnameUser.Text + "' " +
                     ", '" + txtLastnameUser.Text + "') "

            SQLManager(strQuery, "Record saved.")

        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddDonation_Click(sender As Object, e As EventArgs) Handles btnAddDonation.Click
        dbConnection()
        Dim strQuery As String
        Try

            strQuery = "INSERT INTO donation (DonorID, DonationType, BProductDonated, QuantityUnits, Status) " +
            "VALUES ('" + txtDonorID.Text +
                     ", '" + cboDonationType.SelectedValue.ToString + "' " +
                     ", '" + cboDonationType.SelectedValue.ToString + "' " +
                     ", '" + txtUnits.Text + "' " +
                     ", '" + txtRemarks.Text + "') "



            SQLManager(strQuery, "Record saved.")

        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Blood Bank",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateDonation_Click(sender As Object, e As EventArgs) Handles btnUpdateDonation.Click

    End Sub

    Private Sub btnAddTrans_Click(sender As Object, e As EventArgs) Handles btnAddTrans.Click

    End Sub

    Private Sub btnAddDonor_Click(sender As Object, e As EventArgs) Handles btnAddDonor.Click
        Dim strQuery As String

        Try
            strQuery = "INSERT INTO donor (DonorBloodType, DonorFname, DonorMname, DonorLname, DonorBirthDate, DonorAge, DonorHeight, DonorWeight, DonorContactNo) " +
                "VALUES ('" + cboBloodType.SelectedValue.ToString + "', '" + txtFirstnameDonor.Text + "' " +
                                ", '" + txtMiddlenameDonor.Text + "' " + ", '" + txtLastnameDonor.Text + "' " +
                                ", '" + txtBirthdateDonor.Text + "' " + ", '" + txtAgeDonor.Text + "' " +
                                ", '" + txtHeightDonor.Text + "' " + ", '" + txtWeightDonor.Text + "' " +
                                ", '" + txtContactNumberDonor.Text + "') "
            SQLManager(strQuery, "Record saved.")

        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Blood Bank",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
