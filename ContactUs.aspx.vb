Imports System.Net.Mail

Partial Class ContactUs
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim body As String = "Customer Name: " & CStr(firstname.Value) & " " & CStr(lastname.Value) & vbNewLine &
                             "Customer Cell: " & CStr(kk.Value) & vbNewLine &
                             "Customer Email: " & CStr(email.Value) & vbNewLine &
                             "Customer Message : " & vbNewLine & vbNewLine &
                             CStr(data.Value)

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
            e_mail.Subject = "Adams Coffee Bar: New Enquiry"
            e_mail.IsBodyHtml = False
            e_mail.Body = body + vbNewLine + vbNewLine + "From Website"
            Smtp_Server.Send(e_mail)

        Catch error_t As Exception
        End Try

        Response.Redirect("~\ContactConfirmation.aspx")
    End Sub
End Class
