
Partial Class Reviews
    Inherits System.Web.UI.Page

    Dim commentField As New Dictionary(Of Integer, HtmlTextArea)

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim DS1 As New DS_Review
        Dim TA1 As New DS_ReviewTableAdapters.ReviewTableAdapter

        TA1.FillReviews(DS1.Review)

        For i As Integer = 0 To DS1.Review.Rows.Count - 1 Step 1
            Dim review_ID As Integer = DS1.Review.Rows(i).Item("Review_ID")
            Dim cust_ID As Integer = DS1.Review.Rows(i).Item("Customer_ID")

            Dim DS2 As New DS_Review
            Dim TA2 As New DS_ReviewTableAdapters.TEMP_GetterTableAdapter

            TA2.FillbyID(DS2.TEMP_Getter, cust_ID)

            Dim cust_name As String = DS2.TEMP_Getter.Rows(0).Item("cust_FirstName").ToString
            Dim review_Date As String = DS1.Review.Rows(i).Item("Review_PostDate").ToString
            Dim review_Time As String = DS1.Review.Rows(i).Item("Review_Time").ToString
            Dim review_Data As String = DS1.Review.Rows(i).Item("Review_Data").ToString
            Dim review_Title As String = DS1.Review.Rows(i).Item("Review_Title").ToString
            Dim review_Likes As Integer = DS1.Review.Rows(i).Item("Review_TotalLikes")
            Dim review_Comments As Integer = DS1.Review.Rows(i).Item("Review_TotalComments")
            Dim review_Rating As Integer = DS1.Review.Rows(i).Item("Review_Rating")

            Dim ReviewDiv As HtmlGenericControl = New HtmlGenericControl("div")
            ReviewDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#EBEBEB")
            ReviewDiv.Style.Add(HtmlTextWriterStyle.Width, "50%")
            ReviewDiv.Style.Add(HtmlTextWriterStyle.BorderWidth, "medium")
            ReviewDiv.Style.Add(HtmlTextWriterStyle.BorderStyle, "double")
            ReviewDiv.Style.Add(HtmlTextWriterStyle.BorderColor, "Black")
            ReviewDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "25%")
            ReviewDiv.Style.Add(HtmlTextWriterStyle.MarginBottom, "5%")
            ReviewDiv.ID = review_ID

            Dim div1 As New HtmlGenericControl("div")
            div1.Style.Add(HtmlTextWriterStyle.TextAlign, "Center")
            Dim h1 As New HtmlGenericControl("h1")
            h1.Style.Add(HtmlTextWriterStyle.MarginLeft, "1px")
            h1.InnerText = review_Title
            div1.Controls.Add(h1)
            Dim div444 As New HtmlGenericControl("div")
            Dim s As String = ""
            Dim ee As Integer = review_Rating - 1
            For f As Integer = 0 To ee Step 1
                s = s + "<i class=""fa fa-star"" aria-hidden=""true""></i>"
            Next
            For h As Integer = 0 To ((5 - ee) - 2) Step 1
                s = s + "<i class=""fa fa-star-o"" aria-hidden=""true""></i>"
            Next

            div444.InnerHtml = s
            div1.Controls.Add(div444)
            Dim p1 As New HtmlGenericControl("p")
            p1.Style.Add(HtmlTextWriterStyle.MarginLeft, "1px")
            p1.InnerText = "by " + cust_name + ", " + review_Date.Substring(0, 10) + "  @ " + review_Time.Substring(0, 8)
            div1.Controls.Add(p1)

            

            Dim div2 As New HtmlGenericControl("div")
            div2.Style.Add(HtmlTextWriterStyle.MarginLeft, "5%")
            div2.Style.Add(HtmlTextWriterStyle.MarginRight, "5%")
            div2.Style.Add(HtmlTextWriterStyle.MarginTop, "5px")
            div2.Style.Add(HtmlTextWriterStyle.MarginBottom, "5px")
            Dim data As New HtmlGenericControl("p")
            data.InnerText = review_Data
            div2.Controls.Add(data)

            Dim div3 As New HtmlGenericControl("div")
            div3.Style.Add(HtmlTextWriterStyle.TextAlign, "Center")
            div3.Style.Add(HtmlTextWriterStyle.MarginLeft, "1px")
            div3.InnerHtml = "<span>Likes: " + CStr(review_Likes) + "</span><span> &nbsp &nbsp &nbsp Comments: " + CStr(review_Comments) + "</span><br /><br />"
            Dim btn As New Button
            btn.ID = "btn" + CStr(review_ID)
            btn.Text = "Like!"
            btn.CssClass = "btn btn-danger"
            AddHandler btn.Click, AddressOf likeButtonClicked
            div3.Controls.Add(btn)

            Dim hr As New HtmlGenericControl("hr")
            hr.Style.Add(HtmlTextWriterStyle.Width, "70%")
            hr.Style.Add(HtmlTextWriterStyle.BackgroundColor, "green")
            hr.Style.Add(HtmlTextWriterStyle.BorderWidth, "3px")
            hr.Style.Add(HtmlTextWriterStyle.BorderStyle, "single")


            Dim div4 As New HtmlGenericControl("div")
            div4.Style.Add(HtmlTextWriterStyle.Width, "75%")
            div4.Style.Add(HtmlTextWriterStyle.MarginLeft, "12.5%")

            Dim DS10 As New DS_Review
            Dim TA10 As New DS_ReviewTableAdapters.CommentsTableAdapter

            TA10.FillComments(DS10.Comments, review_ID)

            For w As Integer = 0 To DS10.Comments.Rows.Count - 1 Step 1
                Dim comment_ID As Integer = DS10.Comments.Rows(w).Item("Customer_ID")
                Dim comment_Date As String = DS10.Comments.Rows(w).Item("Comment_Date").ToString.Substring(0, 10)
                Dim comment_Time As String = DS10.Comments.Rows(w).Item("Comment_Time").ToString
                Dim comment_Data As String = DS10.Comments.Rows(w).Item("Comment_Data").ToString

                Dim DS11 As New DS_Review
                Dim TA11 As New DS_ReviewTableAdapters.TEMP_GetterTableAdapter

                TA11.FillbyID(DS11.TEMP_Getter, comment_ID)

                Dim comment_name As String = DS11.TEMP_Getter.Rows(0).Item("cust_FirstName").ToString

                Dim divw As New HtmlGenericControl("div")
                divw.Style.Add(HtmlTextWriterStyle.MarginBottom, "3%")

                Dim hh As New HtmlGenericControl("h5")
                hh.InnerText = "Comment by " + comment_name + ", " + comment_Date + " " + comment_Time

                Dim innerDiv As New HtmlGenericControl("div")
                innerDiv.Style.Add(HtmlTextWriterStyle.MarginLeft, "5%")
                innerDiv.Style.Add(HtmlTextWriterStyle.MarginRight, "5%")
                innerDiv.Style.Add(HtmlTextWriterStyle.MarginTop, "5px")
                innerDiv.Style.Add(HtmlTextWriterStyle.MarginBottom, "5px")

                Dim pp As New HtmlGenericControl("p")
                pp.InnerText = comment_Data

                Dim hrr As New HtmlGenericControl("hr")

                innerDiv.Controls.Add(pp)
                divw.Controls.Add(hh)
                divw.Controls.Add(innerDiv)
                divw.Controls.Add(hrr)
                div4.Controls.Add(divw)
            Next

            Dim hr4 As New HtmlGenericControl("hr")
            hr4.Style.Add(HtmlTextWriterStyle.Width, "70%")

            Dim div5 As New HtmlGenericControl("div")
            div5.Style.Add(HtmlTextWriterStyle.Width, "75%")
            div5.Style.Add(HtmlTextWriterStyle.MarginLeft, "12.5%")
            div5.Style.Add(HtmlTextWriterStyle.MarginBottom, "10%")
            Dim ppp As New HtmlGenericControl("p")
            ppp.InnerText = "Leave a comment!"
            Dim textArea As New HtmlTextArea
            textArea.Cols = 52
            textArea.Rows = 4
            textArea.ID = "txt" + CStr(review_ID)
            textArea.Style.Add(HtmlTextWriterStyle.MarginLeft, "10%")
            textArea.Style.Add(HtmlTextWriterStyle.MarginBottom, "3%")
            commentField.Add(review_ID, textArea)
            Dim divbb As New HtmlGenericControl("div")
            divbb.Style.Add(HtmlTextWriterStyle.TextAlign, "Center")
            Dim bbtn As New Button
            bbtn.ID = "btnww" + CStr(review_ID)
            bbtn.Text = "Post"
            bbtn.CssClass = "btn btn-primary"
            bbtn.ToolTip = CStr(review_ID)
            AddHandler bbtn.Click, AddressOf PostComment
            divbb.Controls.Add(bbtn)
            div5.Controls.Add(ppp)
            div5.Controls.Add(textArea)
            div5.Controls.Add(divbb)


            ReviewDiv.Controls.Add(div1)
            ReviewDiv.Controls.Add(div2)
            ReviewDiv.Controls.Add(div3)
            ReviewDiv.Controls.Add(hr)
            ReviewDiv.Controls.Add(div4)
            ReviewDiv.Controls.Add(hr4)
            ReviewDiv.Controls.Add(div5)
            generationDiv.Controls.Add(ReviewDiv)
        Next

    End Sub

    Protected Sub likeButtonClicked(sender As Object, e As System.EventArgs)
        If Session.Item("loggin_Flag") = Nothing Then
            Response.Redirect("~\SignIn.aspx")
        End If
        Dim btn As Button = sender
        Dim reviewID As Integer = CInt(btn.ID.Substring(3, (btn.ID.Length - 3)))

        Dim DS As New DS_Review
        Dim TA As New DS_ReviewTableAdapters.ReviewTableAdapter

        TA.IncrementReviewLikes(reviewID)
        Response.Redirect("~\Reviews.aspx")
    End Sub

    Protected Sub PostComment(sender As Object, e As System.EventArgs)
        If Session.Item("loggin_Flag") = Nothing Then
            Response.Redirect("~\SignIn.aspx")
        End If
        
        Dim btn As Button = sender
        Dim reviewID As Integer = CInt(btn.ToolTip)
        Dim commentData As String = commentField.Item(reviewID).Value
        Dim customerID As Integer = Session("Cust_ID")
        Dim nDate As String = Now.Date.ToString
        Dim nTime As String = Now.TimeOfDay.ToString.Substring(0, 8)

        If commentField.Item(reviewID).Value = "" Then
            MsgBox("You must type a comment to post", MsgBoxStyle.Exclamation, "No Comment Detected")
        Else
            Dim DS As New DS_Review
            Dim TA As New DS_ReviewTableAdapters.CommentsTableAdapter

            TA.AddComment(reviewID, customerID, commentData, nDate, nTime)

            Dim DS1 As New DS_Review
            Dim TA1 As New DS_ReviewTableAdapters.ReviewTableAdapter

            TA1.IncrementComments(reviewID)

            Response.Redirect("~\Reviews.aspx")
        End If
    End Sub
End Class
