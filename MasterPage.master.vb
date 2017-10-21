
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub btn_SignIn_Click(sender As Object, e As System.EventArgs) Handles btn_SignIn.Click
        If btn_SignIn.Text = "Sign In" Then
            Response.Redirect("~\SignIn.aspx")
        Else
            btn_SignIn.Text = "Sign In"
            btn_LogginStatus.Text = "Not Signed In!"
            Session.RemoveAll()
            Response.Redirect("~\Default.aspx")
        End If
    End Sub

    Public Sub SetLogginStatus(Optional ByVal name As String = "", Optional ByVal flag As Boolean = True)
        If flag = True Then
            btn_LogginStatus.Text = "Welcome " + name + "!"
            btn_SignIn.Text = "Sign Out"
        End If
    End Sub

    Protected Sub btn_LogginStatus_Click(sender As Object, e As System.EventArgs) Handles btn_LogginStatus.Click
        If Session.Item("loggin_Flag") = True Then
            Response.Redirect("~\MyProfileAdmin.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not (Session.Item("loggin_Flag") = Nothing) Then
            btn_LogginStatus.Text = "Welcome " + Session.Item("Cust_Name") + "!"
            btn_SignIn.Text = "Sign Out"
        End If
    End Sub
End Class

