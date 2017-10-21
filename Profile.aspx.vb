
Partial Class Profile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        isEnabled(False)
        Dim cust_ID As Integer = CInt(Session.Item("Cust_ID"))

        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.CustomerTableAdapter

        TA.FillByID(DS.Customer, cust_ID)

        If DS.Customer.Rows.Count > 0 Then
            txt_Name.Text = DS.Customer.Rows(0).Item(1).ToString
            txt_Surname.Text = DS.Customer.Rows(0).Item(2).ToString
            txt_Email.Text = DS.Customer.Rows(0).Item(3).ToString
            txt_CellNumber.Text = DS.Customer.Rows(0).Item(4).ToString
            txt_Addr_Street.Text = DS.Customer.Rows(0).Item(5).ToString
            txt_Addr_City.Text = DS.Customer.Rows(0).Item(6).ToString
            txt_AreaCode.Text = DS.Customer.Rows(0).Item(7).ToString
            txt_Password.Text = DS.Customer.Rows(0).Item(8).ToString
        End If
    End Sub

    Private Sub isEnabled(ByVal flag As Boolean)
        txt_Name.Enabled = flag
        txt_Surname.Enabled = flag
        txt_Email.Enabled = flag
        txt_CellNumber.Enabled = flag
        txt_Addr_Street.Enabled = flag
        txt_Addr_City.Enabled = flag
        txt_AreaCode.Enabled = flag
        txt_Password.Enabled = flag
    End Sub
End Class
