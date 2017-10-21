<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ContactConfirmation.aspx.vb" Inherits="ContactConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1 align="center">Thank You <span id="spanCust" runat="server"></span></h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">You've made contact</h3>
            <hr />
            <p>
                We've recieved your message, one of our friendly staff will be in contact soon!<br />
            </p>
            <br />
            <br />
        </div>
    </div>
    <meta http-equiv="refresh" content="4;url=Default.aspx" />
</asp:Content>

