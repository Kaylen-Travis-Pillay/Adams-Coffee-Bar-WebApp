<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ForgotPassword_Main.aspx.vb" Inherits="ForgotPassword_Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 align="center">Don't Fear! We've got your back</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">Recover your password</h3>
            <hr />
            <div style="margin-left:auto;margin-right:auto; width:auto; height:auto; text-align:center;">
                <h5 align="center">Enter your username</h5>
                <asp:TextBox ID="txt_Username" runat="server" Width="50%"></asp:TextBox>
                <br />
                <asp:Button ID="btn_Recover" runat="server" Text="Recover" style="margin-top:2%;" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
</asp:Content>

