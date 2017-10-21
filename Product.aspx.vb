
Partial Class Product
    Inherits System.Web.UI.Page
    Dim name As String
    Dim descr As String
    Dim price As Integer
    Dim productID As Integer
    Dim cart As List(Of String) = New List(Of String)

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~\Store.aspx")
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        name = Session.Item("temp_productName")
        descr = Session.Item("temp_productDescr")
        price = CInt(Session.Item("temp_productPrice"))
        productID = CInt(Session.Item("temp_productID"))

        Dim DS As New DS_Review
        Dim TA As New DS_ReviewTableAdapters.ProductReviewTableAdapter

        Dim rating As Integer = CInt(TA.ScalarQuery(productID))
        Dim s As String = "Rating: "
        Dim ee As Integer = rating - 1

        For f As Integer = 0 To ee Step 1
            s = s + "<i class=""fa fa-star"" aria-hidden=""true""></i>"
        Next
        For h As Integer = 0 To ((5 - ee) - 2) Step 1
            s = s + "<i class=""fa fa-star-o"" aria-hidden=""true""></i>"
        Next
        s = s + "<p> </p>"
        ratingDiv.InnerHtml = s

        'Reviews
        Dim DS1 As New DS_Review
        Dim TA1 As New DS_ReviewTableAdapters.ProductReviewTableAdapter

            TA1.FillByProductID(DS1.ProductReview, productID)

            For i As Integer = 0 To DS1.ProductReview.Rows.Count - 1 Step 1
                Dim div As HtmlGenericControl = New HtmlGenericControl("div")
                div.Style.Add(HtmlTextWriterStyle.Width, "60%")
                div.Style.Add(HtmlTextWriterStyle.MarginLeft, "8%")

                Dim h4 As HtmlGenericControl = New HtmlGenericControl("h4")
                h4.InnerText = DS1.ProductReview.Rows(i).Item("pr_Title").ToString
                div.Controls.Add(h4)

                Dim div1 As HtmlGenericControl = New HtmlGenericControl("div")
                Dim review_Rating = DS1.ProductReview.Rows(i).Item("pr_FTUCount")
                Dim ss As String = ""
                Dim eee As Integer = review_Rating - 1
                For f As Integer = 0 To eee Step 1
                    ss = ss + "<i class=""fa fa-star"" aria-hidden=""true""></i>"
                Next
                For h As Integer = 0 To ((5 - eee) - 2) Step 1
                    ss = ss + "<i class=""fa fa-star-o"" aria-hidden=""true""></i>"
                Next
                div1.InnerHtml = ss
                div.Controls.Add(div1)

                Dim DS3 As New DS_Review
                Dim TA3 As New DS_ReviewTableAdapters.TEMP_GetterTableAdapter

                TA3.FillbyID(DS3.TEMP_Getter, DS1.ProductReview.Rows(i).Item("pr_Customer"))


                Dim h6 As HtmlGenericControl = New HtmlGenericControl("h6")
            h6.InnerText = "Comment by " + DS3.TEMP_Getter.Rows(0).Item("cust_FirstName") + " @ " + CStr(DS1.ProductReview.Rows(i).Item("pr_Date"))
                div.Controls.Add(h6)

                Dim data As HtmlGenericControl = New HtmlGenericControl("p")
            data.InnerText = CStr(DS1.ProductReview.Rows(i).Item("pr_Data"))
                div.Controls.Add(data)

                Dim hr As HtmlGenericControl = New HtmlGenericControl("hr")
                hr.Style.Add(HtmlTextWriterStyle.Width, "50%")
                div.Controls.Add(hr)

                reviewDiv.Controls.Add(div)

            Next

        If DS1.ProductReview.Rows.Count = 0 Then
            Dim diiv As HtmlGenericControl = New HtmlGenericControl("h4")
            diiv.Style.Add(HtmlTextWriterStyle.TextAlign, "center")

            diiv.InnerText = "No one has reviewed this product. Post a review!"

            reviewDiv.Controls.Add(diiv)

        End If


    End Sub

    Protected Function getName() As String
        Return name
    End Function

    Protected Function getPrice() As Integer
        Return price
    End Function

    Protected Function getDescription() As String
        Return descr
    End Function

    Public Function CheckIngredients(ByVal productID As Integer, ByVal quantity As Integer) As Boolean
        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.CheckValidTableAdapter

        TA.FillProductID(DS.CheckValid, productID)

        For i As Integer = 0 To DS.CheckValid.Rows.Count - 1 Step 1
            If (CInt(DS.CheckValid.Rows(i).Item(0).ToString) * quantity) >= (CInt(DS.CheckValid.Rows(i).Item(1))) Then
                Return False
            End If
        Next

        Return True
    End Function

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        If Session.Item("loggin_Flag") = Nothing Then
            Response.Redirect("~\SignIn.aspx")
        End If
        Try
            Dim qty As Integer = CInt(quantityTXB.Text)

            If CheckIngredients(productID, CInt(qty)) Then

                Dim DS1 As New DS_Group3DataSet
                Dim TA1 As New DS_Group3DataSetTableAdapters.FreshlyMade_ProductTableAdapter

                TA1.FillID(DS1.FreshlyMade_Product, productID)

                cart.Add("<h5>" + CStr(qty) + "x " + DS1.FreshlyMade_Product.Rows(0).Item(0).ToString + "</h5>")

                Dim l As Dictionary(Of String, Integer) = Session.Item("list_cart")
                l.Add(DS1.FreshlyMade_Product.Rows(0).Item(0).ToString, CInt(qty))
                Session.Item("list_cart") = l

                Session.Item("runningTotal") = Session.Item("runningTotal") + (CInt(DS1.FreshlyMade_Product.Rows(0).Item(2).ToString) * CInt(qty))

                Dim s As String = ""

                For w As Integer = 0 To cart.Count - 1 Step 1
                    s = s + cart.Item(w)
                Next


                Dim www As String = Session.Item("prim") + s
                Session("prim") = www
            Else
                MsgBox("Not Enough Ingredients", MsgBoxStyle.Exclamation, "Cannot Add")
                Response.Redirect("~\Product.aspx")
            End If

            Response.Redirect("~\Store.aspx")

        Catch ee As Exception
            MsgBox("Please enter a valid quantity", MsgBoxStyle.Critical, "Invalid Input")
        End Try

    End Sub

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click
        If Session.Item("loggin_Flag") = Nothing Then
            Response.Redirect("~\SignIn.aspx")
        End If
        If TextArea1.Value = "" Or TextBox1.Text = "" Then
            MsgBox("Please fill out all required fields", MsgBoxStyle.Critical, "Input Required")
        Else
            Dim DS As New DS_Review
            Dim TA As New DS_ReviewTableAdapters.ProductReviewTableAdapter

            TA.InsertQuery(TextArea1.Value, CStr(Now.Date), CStr(Now.TimeOfDay.ToString), Session.Item("Cust_ID"), CInt(DropDownList1.SelectedIndex + 1), productID, TextBox1.Text)

            Response.Redirect("~\Product.aspx")
            TextArea1.Value = ""
            TextBox1.Text = ""
        End If
       
    End Sub
End Class
