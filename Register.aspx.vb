Imports System.Net.Mail
Partial Class Register
    Inherits System.Web.UI.Page

    Protected Sub btn_Register_Click(sender As Object, e As System.EventArgs) Handles btn_Register.Click
        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.CustomerTableAdapter
        Try
            TA.InsertCustomer(txt_Name.Text,
                              txt_Surname.Text,
                              txt_Email.Text,
                              CInt(txt_CellNumber.Text),
                              txt_Addr_Street.Text,
                              txt_Addr_City.Text,
                              CInt(txt_AreaCode.Text),
                              txt_Password.Text)
            Try
                Dim body As String = "Hi," + vbNewLine + vbNewLine + "Welcome to Adams Coffee Bar! We're super glad you joined us" + vbNewLine + "Here are your login details:" + vbNewLine + "  Username: " + txt_Email.Text + vbNewLine + "  Password: " + txt_Password.Text + vbNewLine + vbNewLine + "Regards" + vbNewLine + "The guys at Adams Coffee Bar"
                Dim Smtp_Server As New SmtpClient
                Dim e_mail As New MailMessage()
                Smtp_Server.UseDefaultCredentials = False
                Smtp_Server.Credentials = New Net.NetworkCredential("neurosolutions.igp@gmail.com", "password123!")
                Smtp_Server.Port = 587
                Smtp_Server.EnableSsl = True
                Smtp_Server.Host = "smtp.gmail.com"

                e_mail = New MailMessage()
                e_mail.From = New MailAddress("neurosolutions.igp@gmail.com")
                e_mail.To.Add("kaylen.student@gmail.com")
                e_mail.Subject = "Adams Coffee Bar: Account Registration"
                e_mail.IsBodyHtml = False
                e_mail.Body = body + vbNewLine + vbNewLine + "Regards" + vbNewLine + "The guys at Adams Coffee Bar :)"
                Smtp_Server.Send(e_mail)

            Catch error_t As Exception

            End Try

            TA.FillByEmail(DS.Customer, txt_Email.Text)

            If DS.Customer.Rows.Count > 0 Then
                Session.Add("Cust_ID", DS.Customer.Rows(0).Item(0).ToString)
                Session.Add("Cust_Name", DS.Customer.Rows(0).Item(1).ToString)
                Response.Redirect("~\RegisterResult.aspx")
            Else

            End If
        Catch w As Exception
            MsgBox("Oops!" + vbNewLine + "Something went wrong, please try again", MsgBoxStyle.Critical, "Error")
        End Try

        

    End Sub
End Class
