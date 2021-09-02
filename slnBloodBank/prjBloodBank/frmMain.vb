Public Class frmMain
    Dim index As Integer
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
        pnlStockIn.Visible = False
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = False
    End Sub

    Private Sub DonationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonationsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = True
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = False
    End Sub

    Private Sub PatientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = True
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = False
    End Sub

    Private Sub TransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransactionToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = True
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = False
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = True
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = False
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlStockIn.Visible = False
        pnlUsers.Visible = True
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = False
    End Sub
    Private Sub StockInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockInToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = True
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = False
    End Sub

    Private Sub StockOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockOutToolStripMenuItem.Click
        pnlDonors.Visible = False
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        PnlStockOut.Visible = True
        pnlAuditLogs.Visible = False
    End Sub
    Private Sub AuditLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuditLogsToolStripMenuItem.Click
        pnlDonations.Visible = False
        pnlPatients.Visible = False
        pnlTransaction.Visible = False
        pnlProducts.Visible = False
        pnlUsers.Visible = False
        pnlStockIn.Visible = False
        PnlStockOut.Visible = False
        pnlAuditLogs.Visible = True
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
            MessageBox.Show("Error: Save() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strQuery As String
        dbConnection()
        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        DisplayRecords(strQuery, dgPatients)
        btnAddPatient.Visible = True
        btnUpdatePatient.Visible = False
        btnDeletePatient.Visible = False

        strQuery = "SELECT * FROM bloodproduct ORDER BY ProductID"
        DisplayRecords(strQuery, dgProducts)
    End Sub
    Private Sub btnAddPatient_Click(sender As Object, e As EventArgs) Handles btnAddPatient.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO patient (`PatientBloodType`, `PatientFname`, `PatientMname`, 
            `PatientLname`, `PatientBirthDate`, `PatientAge`, `PatientHeight`, `PatientWeight`,
            `PatientDisease`, `Address`, `City`, `Zip`,  `PatientContactPerson`, `PatientContactNo`, `IsActive`)" +
            "VALUES ('" & cboBloodTypePatient.SelectedItem & "',
            '" & txtFirstnamePatient.Text & "',
            '" & txtMiddlenamePatient.Text & "',
            '" & txtLastnamePatient.Text & "',
            '" & dtpPatient.Value.ToString("yyyy-M-d") & "',
            '" & txtAgePatient.Text & "',
            '" & txtHeightPatient.Text & "',
            '" & txtWeightPatient.Text & "',
            '" & txtDiseasePatient.Text & "',
            '" & txtAddressPatient.Text & "',
            '" & txtCityPatient.Text & "',
            " & txtZipPatient.Text & ",
            '" & txtContactPersonPatient.Text & "',
            " & txtContactPersonNumber.Text & ")"
            SQLManager(strQuery, "Record saved.")
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboBloodTypePatient.Text = ""
        txtFirstnamePatient.Clear()
        txtMiddlenamePatient.Clear()
        txtLastnamePatient.Clear()
        dtpPatient.ResetText()
        txtAgePatient.Clear()
        txtHeightPatient.Clear()
        txtWeightPatient.Clear()
        txtDiseasePatient.Clear()
        txtAddressPatient.Clear()
        txtCityPatient.Clear()
        txtZipPatient.Clear()
        txtContactPersonPatient.Clear()
        txtContactPersonNumber.Clear()
        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        DisplayRecords(strQuery, dgPatients)
    End Sub

    Private Sub dgPatients_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPatients.CellClick
        Dim i As Integer = e.RowIndex
        Try
            With dgPatients
                index = .Item("PatientID", i).Value
                txtFirstnamePatient.Text = .Item("PatientFname", i).Value
                txtMiddlenamePatient.Text = .Item("PatientMname", i).Value
                txtLastnamePatient.Text = .Item("PatientLname", i).Value
                cboBloodTypePatient.Text = .Item("PatientBloodType", i).Value
                txtDiseasePatient.Text = .Item("PatientDisease", i).Value
                dtpPatient.Value = CDate(.Item("PatientBirthDate", i).Value)
                txtAgePatient.Text = .Item("PatientAge", i).Value
                txtHeightPatient.Text = .Item("PatientHeight", i).Value
                txtWeightPatient.Text = .Item("PatientWeight", i).Value
                txtAddressPatient.Text = .Item("Address", i).Value
                txtCityPatient.Text = .Item("City", i).Value
                txtZipPatient.Text = .Item("Zip", i).Value
                txtContactPersonPatient.Text = .Item("PatientContactPerson", i).Value
                txtContactPersonNumber.Text = .Item("PatientContactNo", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick()" & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        btnAddPatient.Visible = False
        btnUpdatePatient.Visible = True
        btnDeletePatient.Visible = True
    End Sub

    Private Sub btnUpdatePatient_Click(sender As Object, e As EventArgs) Handles btnUpdatePatient.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE patient SET PatientFname = '" & txtFirstnamePatient.Text & "', 
                PatientMname = '" & txtMiddlenamePatient.Text & "',
                PatientLname = '" & txtLastnamePatient.Text & "',
                PatientBloodType = '" & cboBloodTypePatient.SelectedItem & "',
                PatientDisease = '" & txtDiseasePatient.Text & "',
                PatientBirthDate = '" & dtpPatient.Value.ToString("yyyy-M-d") & "',
                PatientAge = " & txtAgePatient.Text & ",
                PatientHeight ='" & txtHeightPatient.Text & "',
                PatientWeight = '" & txtWeightPatient.Text & "',
                Address = '" & txtAddressPatient.Text & "',
                City = '" & txtCityPatient.Text & "',
                Zip = '" & txtZipPatient.Text & "',
                PatientContactPerson = '" & txtContactPersonPatient.Text & "',
                PatientContactNo = '" & txtContactPersonNumber.Text & "'
                WHERE PatientID = " & index & ""
            SQLManager(strQuery, "Record updated.")
        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        DisplayRecords(strQuery, dgPatients)
        cboBloodTypePatient.Text = ""
        txtFirstnamePatient.Clear()
        txtMiddlenamePatient.Clear()
        txtLastnamePatient.Clear()
        dtpPatient.ResetText()
        txtAgePatient.Clear()
        txtHeightPatient.Clear()
        txtWeightPatient.Clear()
        txtDiseasePatient.Clear()
        txtAddressPatient.Clear()
        txtCityPatient.Clear()
        txtZipPatient.Clear()
        txtContactPersonPatient.Clear()
        txtContactPersonNumber.Clear()
        btnAddPatient.Visible = True
        btnUpdatePatient.Visible = False
        btnDeletePatient.Visible = False
    End Sub

    Private Sub btnDeletePatient_Click(sender As Object, e As EventArgs) Handles btnDeletePatient.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM patient WHERE PatientID = '" & index & "' "
            del = MessageBox.Show("Are you sure you want to delete this patient from the records?", "Delete Patient",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "Successfully deleted")
                strQuery = "SELECT * FROM patient ORDER BY PatientID"
                DisplayRecords(strQuery, dgPatients)
                cboBloodTypePatient.Text = ""
                txtFirstnamePatient.Clear()
                txtMiddlenamePatient.Clear()
                txtLastnamePatient.Clear()
                dtpPatient.ResetText()
                txtAgePatient.Clear()
                txtHeightPatient.Clear()
                txtWeightPatient.Clear()
                txtDiseasePatient.Clear()
                txtAddressPatient.Clear()
                txtCityPatient.Clear()
                txtZipPatient.Clear()
                txtContactPersonPatient.Clear()
                txtContactPersonNumber.Clear()
                btnAddPatient.Visible = True
                btnUpdatePatient.Visible = False
                btnDeletePatient.Visible = False
            Else
                strQuery = "SELECT PatientID, PatientFname, PatientMname, PatientLname, PatientBloodType, PatientDisease, PatientBirthdate," +
            "PatientHeight, PatientWeight,PatientBirthDate, PatientAge, Address, City, Zip," +
            "PatientContactPerson, PatientContactNo FROM patient ORDER BY PatientID"
                DisplayRecords(strQuery, dgPatients)
                cboBloodTypePatient.Text = ""
                txtFirstnamePatient.Clear()
                txtMiddlenamePatient.Clear()
                txtLastnamePatient.Clear()
                dtpPatient.ResetText()
                txtAgePatient.Clear()
                txtHeightPatient.Clear()
                txtWeightPatient.Clear()
                txtDiseasePatient.Clear()
                txtAddressPatient.Clear()
                txtCityPatient.Clear()
                txtZipPatient.Clear()
                txtContactPersonPatient.Clear()
                txtContactPersonNumber.Clear()
                btnAddPatient.Visible = True
                btnUpdatePatient.Visible = False
                btnDeletePatient.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pnlPatients_Click(sender As Object, e As EventArgs) Handles pnlPatients.Click
        Dim strQuery As String
        strQuery = "SELECT * FROM patient ORDER BY PatientID"
        DisplayRecords(strQuery, dgPatients)
        cboBloodTypePatient.Text = ""
        txtFirstnamePatient.Clear()
        txtMiddlenamePatient.Clear()
        txtLastnamePatient.Clear()
        dtpPatient.ResetText()
        txtAgePatient.Clear()
        txtHeightPatient.Clear()
        txtWeightPatient.Clear()
        txtDiseasePatient.Clear()
        txtAddressPatient.Clear()
        txtCityPatient.Clear()
        txtZipPatient.Clear()
        txtContactPersonPatient.Clear()
        txtContactPersonNumber.Clear()
        btnAddPatient.Visible = True
        btnUpdatePatient.Visible = False
        btnDeletePatient.Visible = False
    End Sub

    Private Sub txtSearchPatient_Enter(sender As Object, e As EventArgs) Handles txtSearchPatient.TextChanged
        Dim strQuery As String
        Try
            If txtSearchPatient.Text = "" Then
                strQuery = "SELECT * FROM patient ORDER BY PatientID"
                DisplayRecords(strQuery, dgPatients)
            Else
                strQuery = "SELECT * FROM patient WHERE PatientID= '" & txtSearchPatient.Text & "' OR 
            PatientLname= '" & txtSearchPatient.Text & "' OR PatientBloodType='" & txtSearchPatient.Text & "' 
            ORDER BY PatientID"
                DisplayRecords(strQuery, dgPatients)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtSearchProduct_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProduct.TextChanged
        Dim strQuery As String
        Try
            If txtSearchProduct.Text = "" Then
                strQuery = "SELECT * FROM bloodproduct ORDER BY ProductID"
                DisplayRecords(strQuery, dgProducts)
            Else
                strQuery = "SELECT * FROM bloodproduct WHERE ProductID = '" & txtSearchProduct.Text & "' OR 
                    ProductName = '" & txtSearchProduct.Text & "' OR BloodType = '" & txtSearchProduct.Text & "' 
                    ORDER BY ProductID"
                DisplayRecords(strQuery, dgProducts)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddDonor_Click(sender As Object, e As EventArgs) Handles btnAddDonor.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO donor (`DonorBloodType`, `DonorFname`, `DonorMname`, DonorLname`, 
             `DonorBirthDate`, `DonorAge`, `DonorHeight`, `DonorWeight`, `Address`, `City`, `Zip`, `DonorContactNo`, `IsActive`)" +
             "VALUES ('" & cboBloodType.SelectedValue.ToString & "',
             '" & txtFirstnameDonor.Text & "',
             '" & txtMiddlenameDonor.Text & "',
             '" & txtLastnameDonor.Text & "',
             '" & dtpDonor.Value.ToString("yyyy-M-d") & "',
             '" & txtAgeDonor.Text & "',
             '" & txtHeightDonor.Text & "', 
             '" & txtWeightDonor.Text & "',
             '" & txtAddressDonor.Text & "',
             '" & txtCityDonor.Text & "',
             '" & txtZipDonor.Text & "',
             '" & txtContactNumberDonor.Text & " )"


        Catch ex As Exception
              MessageBox.Show("Error: Save() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboBloodType.Text = ""
        txtFirstnameDonor.Clear()
        txtMiddlenameDonor.Clear()
        txtLastnameDonor.Clear()
        dtpDonor.ResetText()
        txtAgeDonor.Clear()
        txtHeightDonor.Clear()
        txtWeightDonor.Clear()
        txtAddressDonor.Clear()
        txtCityDonor.Clear()
        txtZipDonor.Clear()
        txtContactNumberDonor.Clear()
        strQuery = "SELECT * FROM donor ORDER BY DonorID"
        DisplayRecords(strQuery, dgDonors)
    End Sub

    Private Sub btnUpdateDonor_Click(sender As Object, e As EventArgs) Handles btnUpdateDonor.Click
        Dim strQuery As String

        Try
            strQuery = "UPDATE donor SET DonorFname = '" & txtFirstnameDonor.Text & "',
                DonorMname = '" & txtMiddlenameDonor.Text & "',
                DonorLname =  '" & txtLastnameDonor.Text & "',
                DonorBloodType = '" & cboBloodType.SelectedValue.ToString & "',
                DonorBirthDate = '" & dtpDonor.Value.ToString("yyyy-M-d") & "',
                DonorAge = '" & txtAgeDonor.Text & "',
                DonorHeight = '" & txtHeightDonor.Text & "', 
                DonorWeight = '" & txtWeightDonor.Text & "',
                Address = '" & txtAddressDonor.Text & "',
                City = '" & txtCityDonor.Text & "',
                Zip = '" & txtZipDonor.Text & "',
                DonorContactNo'" & txtContactNumberDonor.Text & "',
                WHERE DonorID = " & index & ""

            SQLManager(strQuery, "Record updated.")
        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT * FROM donor ORDER BY DonorID"
        DisplayRecords(strQuery, dgDonors)
        cboBloodType.Text = ""
        txtFirstnameDonor.Clear()
        txtMiddlenameDonor.Clear()
        txtLastnameDonor.Clear()
        dtpDonor.ResetText()
        txtAgeDonor.Clear()
        txtHeightDonor.Clear()
        txtWeightDonor.Clear()
        txtAddressDonor.Clear()
        txtCityDonor.Clear()
        txtZipDonor.Clear()
        txtContactNumberDonor.Clear()

    End Sub

    Private Sub btnDeleteDonor_Click(sender As Object, e As EventArgs) Handles btnDeleteDonor.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM donor WHERE DonorID = '" & index & "' "
            del = MessageBox.Show(" Do You Want To Remove This Row? ", " Remove Row",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "SuccessFully Remove")
                strQuery = "SELECT * FROM donor ORDER BY DonorID"
                DisplayRecords(strQuery, dgDonors)
                cboBloodType.Text = ""
                txtFirstnameDonor.Clear()
                txtMiddlenameDonor.Clear()
                txtLastnameDonor.Clear()
                dtpDonor.ResetText()
                txtAgeDonor.Clear()
                txtHeightDonor.Clear()
                txtWeightDonor.Clear()
                txtAddressDonor.Clear()
                txtCityDonor.Clear()
                txtZipDonor.Clear()
                txtContactNumberDonor.Clear()

            Else
                strQuery = "SELECT DonorID , DonorFname, DonorMname, DonorLname, 
            DonorBirthDate, DonorAge, DonorHeight, DonorWeight, Address, City, Zip," +
            "DonorContactNo FROM donor ORDER BY DonorID"
                DisplayRecords(strQuery, dgDonors)
                cboBloodType.Text = ""
                txtFirstnameDonor.Clear()
                txtMiddlenameDonor.Clear()
                txtLastnameDonor.Clear()
                dtpDonor.ResetText()
                txtAgeDonor.Clear()
                txtHeightDonor.Clear()
                txtWeightDonor.Clear()
                txtAddressDonor.Clear()
                txtCityDonor.Clear()
                txtZipDonor.Clear()
                txtContactNumberDonor.Clear()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearchDonor_TextChanged(sender As Object, e As EventArgs) Handles txtSearchDonor.TextChanged
        Dim strQuery As String
        Try
            If txtSearchDonor.Text = " " Then
                strQuery = "SELECT * FROM donor ORDER BY DonorID"
                DisplayRecords(strQuery, dgDonors)
            Else
                strQuery = " SELECT * FROM donor WHERE DonorID= '" & txtSearchDonor.Text & "' OR 
                DonorLname = '" & txtSearchDonor.Text & "' OR DonorBloodType = '" & txtSearchDonor.Text & "' ORDER BY DonorID "
                DisplayRecords(strQuery, dgDonors)

            End If
        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddDonation_Click(sender As Object, e As EventArgs) Handles btnAddDonation.Click
        Dim strQuery As String
        Try
            strQuery = "INSERT INTO donations (`DonorID', 'DateDonated', 'DonationType', 'BProductDonated', 'QuantityUnits', 'Status')" +
                "VALUES ( '" & cboDonorID.SelectedValue.ToString & "',
                           '" & dtpDonation.Value.ToString & "',
                           '" & cboDonationType.SelectedValue.ToString & "',
                           '" & cboProductDonated.SelectedValue.ToString & "',
                            '" & txtUnits.Text & "',
                           '" & txtRemarks.Text & ")"
            SQLManager(strQuery, "Record saved.")
        Catch ex As Exception
            MessageBox.Show("Error: Save() " & ex.Message, "Pet DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        cboBloodType.Text = ""
        dtpDonation.ResetText()
        cboProductDonated.Text = ""
        cboDonorID.Text = ""
        txtUnits.Clear()
        txtRemarks.Clear()
        strQuery = "SELECT * FROM donations ORDER BY Donation ID"
        DisplayRecords(strQuery, dgDonations)

    End Sub

    Private Sub btnUpdateDonation_Click(sender As Object, e As EventArgs) Handles btnUpdateDonation.Click
        Dim strQuery As String
        Try
            strQuery = "UPDATE donations SET DonationType = '" & cboDonationType.SelectedValue.ToString & "',
                                DateDonated = '" & dtpDonation.Value.ToString & "',
                                DonorID = '" & cboDonorID.SelectedValue.ToString & "',
                                BProductDonated = '" & cboProductDonated.SelectedValue.ToString & "',
                                QuantityUnits =  '" & txtUnits.Text & "',
                                Status =  '" & txtRemarks.Text & "'
                                WHERE DonationID = " & index & " "
        Catch ex As Exception
            MessageBox.Show("Error: Update() " & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strQuery = "SELECT * FROM donations ORDER BY DonationID"
        DisplayRecords(strQuery, dgDonations)
        cboBloodType.Text = ""
        dtpDonation.ResetText()
        cboProductDonated.Text = ""
        cboDonorID.Text = ""
        txtUnits.Clear()
        txtRemarks.Clear()
    End Sub

    Private Sub btnDeleteDonation_Click(sender As Object, e As EventArgs) Handles btnDeleteDonation.Click
        Dim strQuery As String
        Dim del As DialogResult
        Try
            strQuery = "DELETE FROM donations WHERE DonationID = '" & index & "' "
            del = MessageBox.Show(" Do You Want To Remove This Row? ", " Remove Row",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If del = DialogResult.Yes Then
                SQLManager(strQuery, "SuccessFully Remove")
                strQuery = "SELECT * FROM donations ORDER BY DonationID"
                DisplayRecords(strQuery, dgDonations)
                cboBloodType.Text = ""
                dtpDonation.ResetText()
                cboProductDonated.Text = ""
                cboDonorID.Text = ""
                txtUnits.Clear()
                txtRemarks.Clear()

            Else
                strQuery = "SELECT DonationID , DonorID, DateDonated, DonationType, BProductDonated, QuantityUnits, Status FROM donation OEDER BY DonationID"
                DisplayRecords(strQuery, dgDonations)
                cboBloodType.Text = ""
                dtpDonation.ResetText()
                cboProductDonated.Text = ""
                cboDonorID.Text = ""
                txtUnits.Clear()
                txtRemarks.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearchDonation_TextChanged(sender As Object, e As EventArgs) Handles txtSearchDonation.TextChanged
        Dim strQuery As String
        Try
            If txtSearchDonation.Text = "" Then
                strQuery = "SELECT * FROM donations ORDER BY DonationID"
                DisplayRecords(strQuery, dgDonations)

            Else
                strQuery = "SELECT * FROM donations WHERE DonationID = '" & txtSearchDonation.Text & " ' OR 
                Status = '" & txtSearchDonation.Text & "' ORDER BY DonationID"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: Search() " & ex.Message, "Blood Bank DBMS",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgAuditLogs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuditLogs.CellContentClick

    End Sub

    Private Sub dgDonations_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDonations.CellContentClick
        Dim i As Integer = e.RowIndex
        Try
            With dgDonations
                index = .Item("DonationID", i).Value
                dtpDonation.Value = CDate(.Item("DateDonated", i).Value)
                cboBloodType.Text = .Item("DonationType", i).Value
                cboProductDonated.Text = .Item("BProductDonated", i).Value
                txtUnits.Text = .Item("QuatityUnits", i).Value
                txtRemarks.Text = .Item("Status", i).Value
            End With
        Catch ex As Exception
            MessageBox.Show("Error: Datagrid CellClick()" & ex.Message, "Blood Bank DBMS",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub cboDonorID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDonorID.SelectedIndexChanged, cboDonorID.SelectionChangeCommitted

    End Sub
End Class
