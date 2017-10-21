Imports System.Net.Mail

Partial Class PaymentMethods
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function getTotal() As Integer
        Return Session.Item("runningTotal")
    End Function

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim cart As Dictionary(Of String, Integer) = Session.Item("list_cart")
        'Create Order
        Dim customerID As Integer = CInt(Session.Item("Cust_ID"))
        Dim today_date As String = Now.Date.ToString
        Dim today_time As String = Now.TimeOfDay.ToString

        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.Order_TableAdapter

        TA.InsertOrder(cart.Count, Session.Item("runningTotal"), today_date, today_time, Nothing, "Not Complete", 7, customerID)

        Dim DS1 As New DS_Group3DataSet
        Dim TA1 As New DS_Group3DataSetTableAdapters.Order_TableAdapter

        TA1.FillBy1(DS1.Order_, customerID)
        Dim orderNumber As Integer = CInt(DS1.Order_.Rows(DS1.Order_.Rows.Count - 1).Item(0))



        For Each kvp As KeyValuePair(Of String, Integer) In cart
            Dim productName As String = kvp.Key.ToString
            Dim Quantity As Integer = kvp.Value

            'Get Product Price
            Dim DS2 As New DS_Group3DataSet
            Dim TA2 As New DS_Group3DataSetTableAdapters.FreshlyMade_ProductTableAdapter

            TA2.FillBy1(DS2.FreshlyMade_Product, productName)

            Dim productPrice As Integer = CInt(DS2.FreshlyMade_Product.Rows(0).Item("fmproduct_UnitPrice"))
            Dim productID As Integer = CInt(DS2.FreshlyMade_Product.Rows(0).Item("fmproduct_ID"))

            Dim DS3 As New DS_Group3DataSet
            Dim TA3 As New DS_Group3DataSetTableAdapters.Order_ProductTableAdapter

            TA3.InsertOrderProduct(orderNumber, productID, Nothing, Quantity, productPrice, 1)

            Dim DS4 As New DS_Group3DataSet
            Dim TA4 As New DS_Group3DataSetTableAdapters.TEMP_CheckoutTableAdapter

            TA4.FillByProductName(DS4.TEMP_Checkout, productName)

            For r As Integer = 0 To DS4.TEMP_Checkout.Rows.Count - 1 Step 1
                Dim ingre_ID As Integer = CInt(DS4.TEMP_Checkout.Rows(r).Item(0).ToString)
                Dim currentStock As Integer = CInt(DS4.TEMP_Checkout.Rows(r).Item(2).ToString)
                Dim recipie As Integer = CInt(DS4.TEMP_Checkout.Rows(r).Item(1).ToString)

                Dim DS5 As New DS_Group3DataSet
                Dim TA5 As New DS_Group3DataSetTableAdapters.IngredientTableAdapter

                TA5.UpdateQuanity((currentStock - (recipie * Quantity)), ingre_ID)
            Next

        Next
        Dim body As String = "Thank you " + Session("Cust_Name") + "!" + vbNewLine + vbNewLine + "Your order ( No. " + CStr(orderNumber) + " ) is being prepared." + vbNewLine + "You will be contacted soon to pick your yummy goods!"
        'Dim body As String = "Hi " + DS.Customer.Rows(0).Item(1) + vbNewLine + vbNewLine + "Your password has been successfully recovered!" + vbNewLine + "Password: " + DS.Customer.Rows(0).Item(8)
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
            e_mail.Subject = "Adams Coffee Bar: Order Confirmation"
            e_mail.IsBodyHtml = False
            e_mail.Body = body + vbNewLine + vbNewLine + "Regards" + vbNewLine + "The guys at Adams Coffee Bar :)"
            Smtp_Server.Send(e_mail)

        Catch error_t As Exception
        End Try

        Session.Remove("list_cart")
        Session.Remove("runningTotal")
        Response.Redirect("~\CheckoutResult.aspx")
    End Sub
End Class
