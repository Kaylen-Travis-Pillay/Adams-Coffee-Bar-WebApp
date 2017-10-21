<% @Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Store.aspx.vb" Inherits="Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container-fluid">
    <div class="row">
        <div id="TOP" class="col-md-12 jumbotron" style="background:#D3D3D3; height:auto; margin-bottom:2%">
            <h1 align="center">
                Take your pick of freshly made food and beverages :)
            </h1>
            <hr />
            <h4 align="center">
                <a href="#FOOD">Food</a></h4>
            <h4 align="center">
                    <a href="#BEV">Beverage</a></h4>
            
        <div style="text-align:center">
            <br />
            <br />
            <hr />
            <h4>
                Search for a product
            </h4>
            <asp:TextBox ID="SearchBox" runat="server" Width="240px"></asp:TextBox>
            <asp:LinkButton ID="SearchButton" runat="server"><i class="fa fa-search fa-lg" aria-hidden="true"></i></asp:LinkButton>
            

  </div>

        </div>
    </div>
   <div class="row">
        <div class="col-md-9" style=" height:auto; top: 0px; left: 0px;">
            <h2 align="center">Our Selection</h2>
            <hr />
            <h3 align="center" id ="FOOD">Food</h3>
            <hr style="width:70%" />
            <div runat="server" id="foodDiv" style="text-align:center">
                
           </div>
           <h3 align="center" id ="BEV">Beverage</h3>
           <hr style="width:70%" />
           <div runat="server" id="bevDiv" style="text-align:center">
                
           </div>
        </div>
        <div class="col-md-3" style="background:#D3D3D3; height:auto;" data-spy="affix" data-offset-top="100">
            <h3 align="center"><b>
                Your Cart</b>
            </h3>
            <hr style="width:50%" />
            <div runat="server" id="cartList">
                
            </div>
            <hr style="width:50%" />
            <h4 align="center">Total: R <%= GetPrice()%></h4>
            <div style="text-align:center">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success">Checkout</asp:LinkButton>
                <br />
                <h6>
                    <a href="#TOP">Return To Start</a></h6>
            </div>
        </div>
   </div>
   </div>
</asp:Content>

