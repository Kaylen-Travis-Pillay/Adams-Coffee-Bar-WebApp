<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CheckoutResult.aspx.vb" Inherits="CheckoutResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 align="center">Thank You <span id="spanCust" runat="server"></span></h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">Payment Successfully Made</h3>
            <hr />
            <p>
                We've recieved payment, and our worker bees are hard at work preparing your order!<br />
            </p>
            <br />
            <br />
        </div>
    </div>
    <meta http-equiv="refresh" content="4;url=Store.aspx" />
</asp:Content>

