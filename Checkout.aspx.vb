
Imports System.Web
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Collections
Imports System.Net.Mail

Partial Class Checkout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        Dim s As String = "<h4>Cart:</h4>"
        Dim cart As Dictionary(Of String, Integer) = Session.Item("list_cart")

        For Each kvp As KeyValuePair(Of String, Integer) In cart
            Dim productName As String = kvp.Key.ToString
            Dim Quantity As Integer = kvp.Value

            s = s + "<h5 align=""left"">" + CStr(Quantity) + "x " + productName + "</h5>"
        Next

        cartDiv.InnerHtml = s + "<p> <p>"
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~\PaymentMethods.aspx")

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
            sendConfirmation(body)

        Catch error_t As Exception
        End Try

        Session.Remove("list_cart")
        Session.Remove("runningTotal")
        Response.Redirect("~\CheckoutResult.aspx")
    End Sub

    Private Sub sendConfirmation(ByVal data222 As String)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim address As Uri

        Dim username As String
        Dim password As String
        Dim message As String
        Dim msisdn As String

        Dim data As New StringBuilder
        Dim byteData() As Byte
        Dim postStream As Stream = Nothing

        ' Please see the FAQ regarding HTTPS (port 443) and HTTP (port 80/5567)
        address = New Uri("http://bulksms.2way.co.za/eapi/submission/send_sms/2/2.0")

        ' Create the web request
        request = DirectCast(WebRequest.Create(address), HttpWebRequest)

        ' Set type to POST
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Create the data we want to send
        username = "kaylentp"
        password = "pillay21"
        message = data222
        msisdn = "27744404484"

        data.Append("username=" + HttpUtility.UrlEncode(username, System.Text.Encoding.GetEncoding("ISO-8859-1")))
        data.Append("&password=" + HttpUtility.UrlEncode(password, System.Text.Encoding.GetEncoding("ISO-8859-1")))
        data.Append("&message=" + HttpUtility.UrlEncode(character_map(message), System.Text.Encoding.GetEncoding("ISO-8859-1")))
        data.Append("&msisdn=" + HttpUtility.UrlEncode(msisdn, System.Text.Encoding.GetEncoding("ISO-8859-1")))

        ' Create a byte array of the data we want to send
        byteData = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(data.ToString())
        'byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

        ' Set the content length in the request headers
        request.ContentLength = byteData.Length


        ' Write data
        Try
            postStream = request.GetRequestStream()
            postStream.Write(byteData, 0, byteData.Length)
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        Finally
            If Not postStream Is Nothing Then postStream.Close()
        End Try

        Try
            ' Get response
            response = DirectCast(request.GetResponse(), HttpWebResponse)

            ' Get the response stream into a reader
            reader = New StreamReader(response.GetResponseStream())

            ' Console application output
            ' Console.WriteLine(reader.ReadToEnd())

            Dim result As String = reader.ReadToEnd()
            Dim tokens() As String
            tokens = result.Split("|")

            If tokens.Length() <> 3 Then
                Console.WriteLine("Error: could not parse valid return data from server")
            Else
                If String.Compare(tokens(0).ToString, "0") = 0 Then
                    Console.WriteLine("Message sent: batch " & tokens(2).ToString())
                Else
                    Console.WriteLine("Error sending message: " & tokens(0) & " " & tokens(1))
                End If
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        Finally
            If Not response Is Nothing Then response.Close()
        End Try
    End Sub

    Public Shared Function character_map(msg As String) As String
        Dim chrs As Hashtable = New Hashtable
        ' Greek characters are mapped onto extended ASCII characters which are unused in the GSM character set
        chrs.Add("Ω", "Û")
        chrs.Add("Θ", "Ô")
        chrs.Add("Δ", "Ð")
        chrs.Add("Φ", "Þ")
        chrs.Add("Γ", "¬")
        chrs.Add("Λ", "Â")
        chrs.Add("Π", "º")
        chrs.Add("Ψ", "Ý")
        chrs.Add("Σ", "Ê")
        chrs.Add("Ξ", "±")

        Dim ret_str As String = ""
        Dim key As String
        Dim chrArray() As Char
        Dim nCnt As Integer
        chrArray = msg.ToCharArray

        For nCnt = 0 To chrArray.Length - 1
            key = chrArray(nCnt)
            If chrs.ContainsKey(key) Then
                ret_str = ret_str + chrs.Item(key)
            Else
                ret_str = ret_str + chrArray(nCnt)
            End If
        Next
        character_map = ret_str
    End Function

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Session.Remove("list_cart")
        Session.Remove("runningTotal")
        Session.Remove("prim")
        MsgBox("Your order has been cancelled!", MsgBoxStyle.OkOnly, "Order Cancelled")
        Response.Redirect("~\Store.aspx")
    End Sub
End Class
