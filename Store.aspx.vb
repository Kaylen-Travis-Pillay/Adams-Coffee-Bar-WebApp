
Partial Class Store
    Inherits System.Web.UI.Page
    Dim qty As String
    Dim totalPrice As Integer = 0
    Dim cart As List(Of String) = New List(Of String)
    Dim productArray As List(Of String) = New List(Of String)

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Session.Item("runningTotal") = Nothing Then
            Session.Add("runningTotal", 0)
            Dim list_cart As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
            Session.Add("list_cart", list_cart)
        Else
            cartList.InnerHtml = Session("prim")
        End If

        Try

            Dim DS4 As New DS_Group3DataSet
            Dim TA4 As New DS_Group3DataSetTableAdapters.FreshlyMade_ProductTableAdapter

            TA4.FillByActiveProducts(DS4.FreshlyMade_Product)

            For k As Integer = 0 To DS4.FreshlyMade_Product.Rows.Count - 1 Step 1
                Dim productID As String = DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_ID").ToString
                Dim productName As String = DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_Name").ToString
                Dim productDescription As String = DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_Description").ToString
                Dim pc As Integer = CInt(DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_UnitPrice").ToString)
                Dim productCost As String = CStr(pc)

                Dim productDiv As HtmlGenericControl = New HtmlGenericControl("div")
                productDiv.Style.Add(HtmlTextWriterStyle.Width, "50%")
                productDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25%")
                productDiv.Style.Add(HtmlTextWriterStyle.Color, "EBEBEB")
                productDiv.ID = productName
                productArray.Add(productName)

                productDiv.InnerHtml = productDiv.InnerHtml + "<h4>" + productName + "</h4><a href=""https://placeholder.com""><img src=""http://www.qualityexcipients.com/data/product_image/noimage.png""></a><h6>" + productDescription + "</h6><h6><b>R " + productCost + "</b></h6>"

                Dim diiiiv As HtmlGenericControl = New HtmlGenericControl("div")
                Dim DS99 As New DS_Review
                Dim TA99 As New DS_ReviewTableAdapters.ProductReviewTableAdapter

                Dim rating As Integer = CInt(TA99.ScalarQuery(productID))
                Dim s As String = ""
                If rating > 0 Then

                    Dim ee As Integer = rating - 1
                    For f As Integer = 0 To ee Step 1
                        s = s + "<i class=""fa fa-star"" aria-hidden=""true""></i>"
                    Next
                    For h As Integer = 0 To ((5 - ee) - 2) Step 1
                        s = s + "<i class=""fa fa-star-o"" aria-hidden=""true""></i>"
                    Next
                    s = s + "<p> </p>"
                Else
                    s = "No Review<br /><br />"
                End If

                diiiiv.InnerHtml = s

                Dim lk As LinkButton = New LinkButton
                lk.ID = "prro_" + productName
                lk.Text = "View Product"
                AddHandler lk.Click, AddressOf move
                lk.ToolTip = productID

                Dim textBox As TextBox = New TextBox
                textBox.ID = "TextBox" + productID
                textBox.ToolTip = "Enter your quanity"
                AddHandler textBox.TextChanged, AddressOf SetQty

                Dim linkButton As LinkButton = New LinkButton
                linkButton.ID = "www" + productID
                linkButton.CssClass = "btn btn-success"
                linkButton.Text = "Add To Cart"
                AddHandler linkButton.Click, AddressOf test
                linkButton.ToolTip = productID

                Dim myspaceDiv55 As HtmlGenericControl = New HtmlGenericControl("div")
                myspaceDiv55.InnerHtml = "<p>Quantity</p>"

                Dim mySpacediv As HtmlGenericControl = New HtmlGenericControl("div")
                mySpacediv.InnerHtml = "<p> </p>"

                Dim mySpacediv88 As HtmlGenericControl = New HtmlGenericControl("div")
                mySpacediv88.Controls.Add(lk)

                productDiv.Controls.Add(mySpacediv88)
                productDiv.Controls.Add(diiiiv)
                productDiv.Controls.Add(myspaceDiv55)
                productDiv.Controls.Add(textBox)
                productDiv.Controls.Add(mySpacediv)
                productDiv.Controls.Add(linkButton)

                Dim mySpacediv2 As HtmlGenericControl = New HtmlGenericControl("div")
                mySpacediv2.InnerHtml = "<p> </p><hr />"

                productDiv.Controls.Add(mySpacediv2)

                foodDiv.Controls.Add(productDiv)

            Next
        Catch ex As Exception

        End Try

        Try

            Dim DS4 As New DS_Group3DataSet
            Dim TA4 As New DS_Group3DataSetTableAdapters.FreshlyMade_ProductTableAdapter

            TA4.FillByActiveBeverage(DS4.FreshlyMade_Product)

            For k As Integer = 0 To DS4.FreshlyMade_Product.Rows.Count - 1 Step 1
                Dim productID As String = DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_ID").ToString
                Dim productName As String = DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_Name").ToString
                Dim productDescription As String = DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_Description").ToString
                Dim pc As Integer = CInt(DS4.FreshlyMade_Product.Rows(k).Item("fmproduct_UnitPrice").ToString)
                Dim productCost As String = CStr(pc)

                Dim productDiv As HtmlGenericControl = New HtmlGenericControl("div")
                productDiv.Style.Add(HtmlTextWriterStyle.Width, "50%")
                productDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25%")
                productDiv.ID = productName
                productArray.Add(productName)

                productDiv.InnerHtml = productDiv.InnerHtml + "<h4>" + productName + "</h4><a href=""https://placeholder.com""><img src=""http://www.qualityexcipients.com/data/product_image/noimage.png""></a><h6>" + productDescription + "</h6><h6><b>R " + productCost + "</b></h6>"

                Dim lk As LinkButton = New LinkButton
                lk.ID = "prro_" + productName
                lk.Text = "View Product"
                AddHandler lk.Click, AddressOf move
                lk.ToolTip = productID

                Dim textBox As TextBox = New TextBox
                textBox.ID = "TextBox" + productID
                textBox.ToolTip = "Enter your quanity"
                AddHandler textBox.TextChanged, AddressOf SetQty

                Dim linkButton As LinkButton = New LinkButton
                linkButton.ID = "www" + productID
                linkButton.CssClass = "btn btn-success"
                linkButton.Text = "Add To Cart"
                AddHandler linkButton.Click, AddressOf test
                linkButton.ToolTip = productID

                Dim myspaceDiv55 As HtmlGenericControl = New HtmlGenericControl("div")
                myspaceDiv55.InnerHtml = "<p>Quantity</p>"

                Dim mySpacediv As HtmlGenericControl = New HtmlGenericControl("div")
                mySpacediv.InnerHtml = "<p> </p>"

                Dim mySpacediv88 As HtmlGenericControl = New HtmlGenericControl("div")
                mySpacediv88.Controls.Add(lk)

                productDiv.Controls.Add(mySpacediv88)
                productDiv.Controls.Add(myspaceDiv55)
                productDiv.Controls.Add(textBox)
                productDiv.Controls.Add(mySpacediv)
                productDiv.Controls.Add(linkButton)

                Dim mySpacediv2 As HtmlGenericControl = New HtmlGenericControl("div")
                mySpacediv2.InnerHtml = "<p> </p><hr />"

                productDiv.Controls.Add(mySpacediv2)

                bevDiv.Controls.Add(productDiv)

            Next
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub move(sender As Object, e As System.EventArgs)
        Dim button As LinkButton = sender

        Try
            Dim productID As Integer = CInt(button.ToolTip)

            Dim DS1 As New DS_Group3DataSet
            Dim TA1 As New DS_Group3DataSetTableAdapters.FreshlyMade_ProductTableAdapter

            TA1.FillID(DS1.FreshlyMade_Product, productID)

            Session.Add("temp_productID", productID)
            Session.Add("temp_productName", DS1.FreshlyMade_Product.Rows(0).Item("fmproduct_Name"))
            Session.Add("temp_productDescr", DS1.FreshlyMade_Product.Rows(0).Item("fmproduct_Description"))
            Session.Add("temp_productPrice", DS1.FreshlyMade_Product.Rows(0).Item("fmproduct_UnitPrice"))

            Response.Redirect("~\Product.aspx")

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub test(sender As Object, e As System.EventArgs)

        If Session.Item("loggin_Flag") = Nothing Then
            Response.Redirect("~\SignIn.aspx")
        End If

        Dim button As LinkButton = sender
        Try
            Dim productID As Integer = CInt(button.ToolTip)

            If CheckIngredients(productID, CInt(qty)) Then

                Dim DS1 As New DS_Group3DataSet
                Dim TA1 As New DS_Group3DataSetTableAdapters.FreshlyMade_ProductTableAdapter

                TA1.FillID(DS1.FreshlyMade_Product, productID)

                cart.Add("<h5>" + qty + "x " + DS1.FreshlyMade_Product.Rows(0).Item(0).ToString + "</h5>")

                Dim l As Dictionary(Of String, Integer) = Session.Item("list_cart")
                l.Add(DS1.FreshlyMade_Product.Rows(0).Item(0).ToString, CInt(qty))
                Session.Item("list_cart") = l

                Session.Item("runningTotal") = Session.Item("runningTotal") + (CInt(DS1.FreshlyMade_Product.Rows(0).Item(2).ToString) * CInt(qty))

                Dim s As String = ""

                For w As Integer = 0 To cart.Count - 1 Step 1
                    s = s + cart.Item(w)
                Next

                cartList.InnerHtml = cartList.InnerHtml + s
                Session("prim") = cartList.InnerHtml
            Else
                MsgBox("Not Enough Ingredients", MsgBoxStyle.Exclamation, "Cannot Add")
            End If


        Catch ex As Exception
            MsgBox("Please enter a valid quantity", MsgBoxStyle.Critical, "Invalid Input")
        End Try

        ClearTextBox(Me)
        qty = String.Empty
    End Sub

    Protected Sub SetQty(sender As Object, e As System.EventArgs)
        Dim textbox As TextBox = sender
        qty = textbox.Text
    End Sub

    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub

    Public Function CheckIngredients(ByVal productID As Integer, ByVal quantity As Integer) As Boolean
        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.CheckValidTableAdapter

        TA.FillProductID(DS.CheckValid, productID)

        For i As Integer = 0 To DS.CheckValid.Rows.Count - 1 Step 1
            If (CInt(DS.CheckValid.Rows(i).Item(0).ToString) * qty) >= (CInt(DS.CheckValid.Rows(i).Item(1))) Then
                Return False
            End If
        Next

        Return True
    End Function

    Protected Function GetPrice() As String
        Return CStr(Session.Item("runningTotal"))
    End Function

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        If Session.Item("loggin_Flag") = Nothing Then
            Response.Redirect("~\SignIn.aspx")
        End If
        If Session("runningTotal") = 0 Then
            MsgBox("Please add products to your cart before you checkout!", MsgBoxStyle.Information, "No products in cart")
        Else
            Response.Redirect("~\Checkout.aspx")
        End If
    End Sub


    Protected Sub SearchButton_Click(sender As Object, e As System.EventArgs) Handles SearchButton.Click
        For Each w As String In productArray
            If w.Contains(SearchBox.Text) Then
                Dim dd As String = "~\Store.aspx#MainContent_" + w
                Response.Redirect(dd)
            End If
        Next

        MsgBox("Unable to find product", MsgBoxStyle.Exclamation, "No product found")
    End Sub
End Class
