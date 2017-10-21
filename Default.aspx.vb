
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim CustomerName As String
    Dim CustomerID As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CustomerID = Session.Item("Cust_ID")
        CustomerName = Session.Item("Cust_Name")

        If Not CustomerID = Nothing And Not CustomerName = Nothing Then
            Dim logginText As LinkButton = Me.Master.FindControl("btn_LogginStatus")
            Dim signinText As LinkButton = Me.Master.FindControl("btn_SignIn")

            logginText.Text = "Welcome " + CustomerName + "!"
            signinText.Text = "Sign Out"
        End If
    End Sub
End Class
