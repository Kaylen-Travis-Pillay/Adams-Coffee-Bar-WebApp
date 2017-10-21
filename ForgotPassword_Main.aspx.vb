Imports System.Net.Mail
Partial Class ForgotPassword_Main
    Inherits System.Web.UI.Page

    Protected Sub btn_Recover_Click(sender As Object, e As System.EventArgs) Handles btn_Recover.Click
        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.CustomerTableAdapter

        TA.FillByEmail(DS.Customer, txt_Username.Text)

        If DS.Customer.Rows.Count > 0 Then

            Dim body As String = "Hi " + DS.Customer.Rows(0).Item(1) + vbNewLine + vbNewLine + "Your password has been successfully recovered!" + vbNewLine + "Password: " + DS.Customer.Rows(0).Item(8)
            Try
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
                e_mail.Subject = "Adams Coffee Bar: Password Recovery"
                e_mail.IsBodyHtml = False
                e_mail.Body = body + vbNewLine + vbNewLine + "Regards" + vbNewLine + "The guys at Adams Coffee Bar :)"
                Smtp_Server.Send(e_mail)

            Catch error_t As Exception
            End Try
            Response.Redirect("~\RecoveryResult.aspx")

        Else
            MsgBox("Invalid Username", MsgBoxStyle.OkOnly, "ERROR")
        End If

        


    End Sub
End Class
