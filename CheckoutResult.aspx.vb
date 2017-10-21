
Partial Class CheckoutResult
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session.Remove("prim")
    End Sub
End Class
