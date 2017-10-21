<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Reviews.aspx.vb" Inherits="Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    textarea {
    resize: none;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container-fluid" runat="server" id="generationDiv">
        <div class="jumbotron" style="text-align:center">
            <h1>Hear what others have to say!</h1>
            <p>Share your experience with Adams, or view the thoughts of our customers. AKA the coffee squad!</p>
            <p><a href="NewReview.aspx" class="btn btn-primary btn-lg">Post your own experience :)</a></p>
        </div>
        <div style="background:#EBEBEB; width:50%; border-width: medium; border-style:double; border-color:Black; margin-left: 25%; margin-bottom: 5%" > 
            <div style="text-align:center">
                <h1 style="margin-left:1px;">
                    Join the Coffee Community
                </h1>
                <p style="margin-left:1px">
                    by Kaylen, 2017-10-12 17:38
                </p>
            </div>
            <div style="margin-left: 5%; margin-top: 5px; margin-bottom:5px; margin-right: 5%">
                <p>
                    Hi! Welcome to YOUR space.<br /><br />

This is a free space for you to share your thoughts and options on everything Adams.
Communicate with old coffee buddies or make new ones :) We encourage you to post as
much as possible and truly become part of the Coffee Squad!<br /><br />

Enjoy<br />
                    <br />
<b>NB:</b> We love free speech, and we'd hate to limit your coffee game, but remember this 
	forum is moderated and is family friendly!
                </p>
            </div>
        </div>
    </div>
</asp:Content>

