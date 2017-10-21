<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Product.aspx.vb" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        /* Style the Image Used to Trigger the Modal */
#myImg {
    border-radius: 5px;
    cursor: pointer;
    transition: 0.3s;
}

#myImg:hover {opacity: 0.7;}

/* The Modal (background) */
.modal {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 100px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
}

/* Modal Content (Image) */
.modal-content {
    margin: auto;
    display: block;
    width: 80%;
    max-width: 700px;
}

/* Caption of Modal Image (Image Text) - Same Width as the Image */
#caption {
    margin: auto;
    display: block;
    width: 80%;
    max-width: 700px;
    text-align: center;
    color: #ccc;
    padding: 10px 0;
    height: 150px;
}

/* Add Animation - Zoom in the Modal */
.modal-content, #caption { 
    -webkit-animation-name: zoom;
    -webkit-animation-duration: 0.6s;
    animation-name: zoom;
    animation-duration: 0.6s;
}

@-webkit-keyframes zoom {
    from {-webkit-transform:scale(0)} 
    to {-webkit-transform:scale(1)}
}

@keyframes zoom {
    from {transform:scale(0)} 
    to {transform:scale(1)}
}

/* The Close Button */
.close {
    position: absolute;
    top: 80px;
    right: 35px;
    color: #f1f1f1;
    font-size: 40px;
    font-weight: bold;
    transition: 0.3s;
}

.close:hover,
.close:focus {
    color: #bbb;
    text-decoration: none;
    cursor: pointer;
}

/* 100% Image Width on Smaller Screens */
@media only screen and (max-width: 700px){
    .modal-content {
        width: 100%;
    }
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div class="container-fluid" style="margin-top:0; margin-bottom:2%">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-success pull-left btn-fyi" Style="margin-top:1%"><span class="glyphicon glyphicon-chevron-left"></span> RETURN</asp:LinkButton>
        </div>
    <div class="container-fluid">
        <div class="row product">
    <div class="col-md-5 col-md-offset-0"><img id="myImg" alt="Adams Coffee Bar" class="img-responsive" src="https://www.dailydot.com/wp-content/uploads/362/7f/a82bcb296b2fa9981d9db5d41b0d5ab9-500x250.jpg" /></div>
    <!-- The Modal -->
<div id="myModal" class="modal">

  <!-- The Close Button -->
  <span class="close">&times;</span>

  <!-- Modal Content (The Image) -->
  <img class="modal-content" id="img01">

  <!-- Modal Caption (Image Text) -->
  <div id="caption"></div>
</div>
    <div class="col-md-7">
        <h2><%= getName()%></h2>
        <p><%= getDescription()%></p>
        <div id="ratingDiv" runat="server">
        </div>
        Quantity <asp:TextBox ID="quantityTXB" runat="server" Columns="2">1</asp:TextBox>
        <h3>R <%= getPrice()%> </h3>
        <div style="margin-bottom:1%">
            <a href="#writeareview">Write a review</a>
        </div>

        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Add to cart" />
    </div>
    </div>
    <div style="margin-top:2%">
        <hr />
        <h3 style="margin-bottom:4%">
            <b><u>Product Reviews</u></b>
        </h3>
        <div id="reviewDiv" runat="server">
            
        </div>
        <div style="text-align:center; margin-top:5%">
            <hr />
            <h3 id="writeareview">
                <i>Write a review!</i>
            </h3>
            <br />
            Title
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Rating
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Comment
            <br />
            <textarea id="TextArea1" cols="50" rows="3" style="resize:none" runat="server"></textarea>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Post" CssClass="btn btn-warning" />
        </div>
    </div>
</div>

<script>
    // Get the modal
    var modal = document.getElementById('myModal');

    // Get the image and insert it inside the modal - use its "alt" text as a caption
    var img = document.getElementById('myImg');
    var modalImg = document.getElementById("img01");
    var captionText = document.getElementById("caption");
    img.onclick = function () {
        modal.style.display = "block";
        modalImg.src = this.src;
        captionText.innerHTML = this.alt;
    }

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }
</script>
</asp:Content>

