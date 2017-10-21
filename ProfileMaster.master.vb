
Partial Class ProfileMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim status As LinkButton = Me.Master.FindControl("btn_LogginStatus")
        Dim signIn As LinkButton = Me.Master.FindControl("btn_SignIn")

        status.Text = "Welcome " + Session.Item("Cust_Name") + "!"
        signIn.Text = "Sign Out"
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("~\Profile.aspx")
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("~\OrderHistory.aspx")
    End Sub
End Class

