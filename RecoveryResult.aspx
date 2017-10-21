<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RecoveryResult.aspx.vb" Inherits="RecoveryResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 align="center">Hoorah!</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">Password Recovery</h3>
            <hr />
            <p>
                We've sent your password to your provided email address :)<br />
            </p>
        </div>
    </div>
    <meta http-equiv="refresh" content="4;url=SignIn.aspx" />
</asp:Content>

