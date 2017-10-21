<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ContactUs.aspx.vb" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container" id="info-container">
        <div class="row">
            <div class="col-md-12">
                <h2 style="text-align:center">Contact Us</h2>
                <hr />
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12" id="contact-box">
                <p id="contact-text">Send us a message and one of our friendly staff will get back to you ASAP</p>
                <div class="info-box"><i class="glyphicon glyphicon-map-marker my-info-icons"></i><span class="text-uppercase text-info">Address: </span><span>UKZN, Westville, 3629, South Africa</span></div>
                <div class="info-box"><i class="glyphicon glyphicon-envelope my-info-icons"></i><span class="text-uppercase text-info">Email: </span><span>info@adams.co.za </span></div>
                <div class="info-box"><i class="glyphicon glyphicon-phone-alt my-info-icons"></i><span class="text-uppercase text-info">Phone: </span><span>+27 31 319 4440 </span></div>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12 site-form">
                <form id="my-form">
                    <div class="form-group has-feedback">
                        <label class="control-label sr-only" for="firstname">First Name</label>
                        <input class="form-control" type="text" name="firstname" placeholder="First Name" autofocus="" id="firstname" runat="server"><i class="form-control-feedback fa fa-user" aria-hidden="true"></i></div>
                    <div class="form-group has-feedback">
                        <label class="control-label sr-only" for="lastname">Last Name</label>
                        <input class="form-control" type="text" name="lastname" placeholder="Last Name" id="lastname" runat="server"><i class="form-control-feedback fa fa-user" aria-hidden="true"></i></div>
                    <div class="form-group has-feedback">
                        <label class="control-label sr-only" for="phonenumber">Phone Number</label>
                        <input class="form-control" type="text" name="phonenumber" required="" placeholder="Phone" id="kk" runat="server"><i class="form-control-feedback fa fa-phone" aria-hidden="true"></i></div>
                    <div class="form-group has-feedback">
                        <label class="control-label sr-only" for="email">Email Address</label>
                        <input class="form-control" type="text" name="email" required="" placeholder="Email" id="email" runat="server"><i class="form-control-feedback fa fa-envelope" aria-hidden="true"></i></div>
                    <div class="form-group has-feedback">
                        <label class="control-label sr-only" for="messages">Last Name</label>
                        <textarea class="form-control" rows="8" name="messages" required="" placeholder="Message" id="data" runat="server"></textarea><i class="form-control-feedback fa fa-pencil" aria-hidden="true"></i></div>
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-default btn-lg" Text="SEND" />
                </form>
            </div>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>

