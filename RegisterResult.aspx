<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RegisterResult.aspx.vb" Inherits="RegisterResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 align="center">Welcome on board!</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">Successfully Registered</h3>
            <hr />
            <p>
                Welcome to the coffee squad! We've emailed you a confirmation, enjoy your experience :)<br />
            </p>
        </div>
    </div>
    <meta http-equiv="refresh" content="4;url=SignIn.aspx" />
</asp:Content>

