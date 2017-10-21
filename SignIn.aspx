<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SignIn.aspx.vb" Inherits="SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 align="center">We're glad you're back!</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">Sign in to your account</h3>
            <hr />
            <div style="margin-left:auto;margin-right:auto; width:auto; height:auto; text-align:center;">
                <h5 align="center">Username</h5>
                <asp:TextBox ID="txt_Username" runat="server" Width="50%"></asp:TextBox>
                <br />
                <h5 align="center">Password</h5>
                <asp:TextBox ID="txt_Password" runat="server" Width="50%"></asp:TextBox>
                <br />
                <asp:Button ID="btn_Login" runat="server" Text="Login" style="margin-top:2%;" CssClass="btn btn-success" />
                <div style="margin-left:auto;margin-right:auto; margin-top:4%; width:50%; height:auto; text-align:center;">
                    <div style="margin-left:auto;margin-right:auto; width:55%; height:auto; text-align:center;">
                        <asp:LinkButton ID="btn_ForgotPassword" runat="server">Forgot your password?</asp:LinkButton>
                    </div>
                    <div style="margin-left:auto;margin-right:auto; width:100%; height:auto; text-align:center;">
                        <asp:LinkButton ID="btn_Register" runat="server">Not Registered? Join Us Here</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

