<%@ Page Title="" Language="VB" MasterPageFile="~/ProfileMaster.master" AutoEventWireup="false" CodeFile="OrderHistory.aspx.vb" Inherits="OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 align="center">Your Order History</h1>
    <div>
        <div style="margin-left:auto;margin-right:auto; width:50%; height:auto; text-align:center">
            <h3>
                These are the awesome things you purchased!
            </h3>
            <hr />
            <div runat="server" id="orderDiv">
                
            </div>
        </div>
    </div>
</asp:Content>

