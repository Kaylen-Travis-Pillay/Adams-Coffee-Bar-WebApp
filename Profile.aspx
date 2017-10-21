<%@ Page Title="" Language="VB" MasterPageFile="~/ProfileMaster.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 align="center">Manage Your Profile</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3 align="center">These are the details we have :)</h3>
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
            </div>
        </div>
    </div>
</asp:Content>

