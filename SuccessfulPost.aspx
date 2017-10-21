<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SuccessfulPost.aspx.vb" Inherits="SuccessfulPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1 align="center">Your post is LIVE!</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">All set, thank you</h3>
            <hr />
            <p>
                Your post is now live. Thank you for helping grow the Coffee Squad<br />
            </p>
        </div>
    </div>
    <meta http-equiv="refresh" content="4;url=Reviews.aspx" />
</asp:Content>

