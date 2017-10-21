<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Register.aspx.vb" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 align="center">Join Us On The Coffee Revolution!</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">Register With Us Today</h3>
            <hr />
            <div style="margin-left:auto;margin-right:auto; width:auto; height:auto; text-align:center;">
                <h5 align="center">Name</h5>
                <asp:TextBox ID="txt_Name" runat="server" Width="50%"></asp:TextBox>
                <h5 align="center">Surname</h5>
                <asp:TextBox ID="txt_Surname" runat="server" Width="50%"></asp:TextBox>
                <h5 align="center">Email</h5>
                <asp:TextBox ID="txt_Email" runat="server" Width="50%"></asp:TextBox>
                <h5 align="center">Cell Number (+27)</h5>
                <h6 align="center">Enter your number without the initial '0'.</h6>
                <asp:TextBox ID="txt_CellNumber" runat="server" Width="50%"></asp:TextBox>
                <h5 align="center">Address</h5>
                <asp:TextBox ID="txt_Addr_Street" runat="server" Width="50%"></asp:TextBox>
                <h5 align="center">City</h5>
                <asp:TextBox ID="txt_Addr_City" runat="server" Width="50%"></asp:TextBox>
                <h5 align="center">Area Code</h5>
                <asp:TextBox ID="txt_AreaCode" runat="server" Width="50%"></asp:TextBox>
                <h5 align="center">Password</h5>
                <asp:TextBox ID="txt_Password" runat="server" Width="50%"></asp:TextBox>
                <br />
                <asp:Button ID="btn_Register" runat="server" Text="Register" style="margin-top:2%;" CssClass="btn btn-success" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        const swal = require('sweetalert2')
    </script>
</asp:Content>

