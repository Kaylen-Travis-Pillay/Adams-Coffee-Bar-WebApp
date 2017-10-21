
Partial Class SignIn
    Inherits System.Web.UI.Page

    Protected Sub btn_Login_Click(sender As Object, e As System.EventArgs) Handles btn_Login.Click
        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.CustomerTableAdapter()

        TA.FillByLogin(DS.Customer, txt_Username.Text, txt_Password.Text)

        If DS.Customer.Rows.Count > 0 Then
            txt_Username.Text = ""
            txt_Password.Text = ""
            Session.Add("Cust_ID", DS.Customer.Rows(0).Item(0).ToString)
            Session.Add("Cust_Name", DS.Customer.Rows(0).Item(1).ToString)
            Session.Add("Loggin_Flag", True)
            Response.Redirect("~\Default.aspx")
        Else
            MsgBox("Invalid loggin", MsgBoxStyle.Critical, "Incorrect Loggin Details")
            txt_Password.Text = ""
        End If
    End Sub

    Protected Sub btn_ForgotPassword_Click(sender As Object, e As System.EventArgs) Handles btn_ForgotPassword.Click
        Response.Redirect("~\ForgotPassword_Main.aspx")
    End Sub

    Protected Sub btn_Register_Click(sender As Object, e As System.EventArgs) Handles btn_Register.Click
        Response.Redirect("~\Register.aspx")
    End Sub
End Class
