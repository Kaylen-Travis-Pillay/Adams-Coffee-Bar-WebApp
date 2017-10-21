
Partial Class NewReview
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click

        If (Not TextBox1.Text = "") And (Not userThoughts.Value = "") Then
            Dim DS As New DS_Review
            Dim TA As New DS_ReviewTableAdapters.ReviewTableAdapter

            Dim title As String = TextBox1.Text
            Dim data As String = userThoughts.Value
            Dim rating As Integer = DropDownList1.SelectedIndex + 1

            TA.AddNewReview(title, rating, data, Now.Date, Now.TimeOfDay.ToString, Session("Cust_ID"))
            Response.Redirect("~\SuccessfulPost.aspx")
        Else
            MsgBox("Please provide required details!", MsgBoxStyle.Exclamation, "Error")
        End If
       


    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Session("Loggin_Flag") = Nothing Then
            Response.Redirect("~\SignIn.aspx")
        End If
    End Sub
End Class
