<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NewReview.aspx.vb" Inherits="NewReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container-fluid">
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">YEEEAAH! Post a review</h3>
            <hr />
            <h4>
                Blog Post Title:
            </h4>
            <asp:TextBox ID="TextBox1" runat="server" Width="60%"></asp:TextBox>
            <br />
            <br />
            <h4>
                Rating:
            </h4>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <h4>
                Share some of your thoughts
            </h4>
            <textarea id="userThoughts" runat="server" cols="80" rows="10"></textarea>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Post" CssClass="btn btn-lg btn-success" />
        </div>
    </div>
</asp:Content>

