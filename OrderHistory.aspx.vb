
Partial Class OrderHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim DS As New DS_Group3DataSet
        Dim TA As New DS_Group3DataSetTableAdapters.TEMP_OrderTableAdapter
        Dim s As String = ""

        TA.FillByCustomerID(DS.TEMP_Order, CInt(Session.Item("Cust_ID")))

        
        For i As Integer = 0 To DS.TEMP_Order.Rows.Count - 1 Step 1
            Dim orderID As Integer = CInt(DS.TEMP_Order.Rows(i).Item(0).ToString)
            Dim DataOrdered As String = DS.TEMP_Order.Rows(i).Item(2).ToString
            Dim PricePaid As Integer = CInt(DS.TEMP_Order.Rows(i).Item(1).ToString)

            s = s + "<h5><b>Order No:</b>" + CStr(orderID) + "</h5><h5><b>Date Ordered:</b> " + DataOrdered + "</h5><h5 align=left><b>Products:</b></h5>"

            Dim DS1 As New DS_Group3DataSet
            Dim TA1 As New DS_Group3DataSetTableAdapters.TEMP_OrderHistoryTableAdapter

            TA1.FillOrderID(DS.TEMP_OrderHistory, orderID)

            For j As Integer = 0 To DS.TEMP_OrderHistory.Rows.Count - 1 Step 1
                Dim orderQTY As Integer = CInt(DS.TEMP_OrderHistory.Rows(j).Item(0).ToString)
                Dim productName As String = DS.TEMP_OrderHistory.Rows(j).Item(1).ToString

                s = s + "<h5 align=left>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp " + CStr(orderQTY) + "x " + productName + "</h5>"
            Next

            s = s + "<h5 align=left><b>Price:</b> R " + CStr(PricePaid) + "</h5><hr style=""width:50%;"" />"
        Next

        orderDiv.InnerHtml = s

    End Sub
End Class
