<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Checkout.aspx.vb" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 align="center">We are ready to prepare you order!</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">Almost there, confirm your cart :)</h3>
            <hr />
            <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center;">
                <div id="cartDiv" runat="server">

                </div>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary">Confirm Order</asp:LinkButton>
                <asp:Button ID="Button1" runat="server" Text="Cancel Order" CssClass="btn btn-danger" />
                <hr />
            </div>
        </div>
    </div>
</asp:Content>

