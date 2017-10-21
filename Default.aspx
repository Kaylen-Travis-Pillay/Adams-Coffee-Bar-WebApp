<% @Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container-fluid">
    
<div class="jumbotron">
            <h1 class="display-3" style="text-align:center">Welcome To Adams Coffee Bar!</h1>
    <hr />
    
        
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner">

      <div class="item active">
        <img src="https://irp-cdn.multiscreensite.com/c1eae712/dms3rep/multi/desktop/coffee2-1000x250.jpg" alt="Fresh" style="width:100%;">
        <div class="carousel-caption">
          <h3>Fresh</h3>
          <p>Here at Adams we always use the most fresh ingrediants</p>
        </div>
      </div>

      <div class="item">
        <img src="http://districtoldsac.com/wp-content/uploads/2016/10/web_main_breakfast-1000x250.jpg" alt="Food" style="width:100%;">
        <div class="carousel-caption">
          <h3>Great Food All The Time</h3>
          <p>We use premium ingrediants to produce quality food</p>
        </div>
      </div>
    
      <div class="item">
        <img src="https://www.niles-hs.k12.il.us/world-languages/wp-content/uploads/sites/17/2017/05/FullSizeRender-1000x250.jpg" alt="Squad" style="width:100%;">
        <div class="carousel-caption">
          <h3>The Coffee Squad</h3>
          <p>Join the Coffee Squad and become part of a coffee family!</p>
        </div>
      </div>
  
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
  </div>
  <div class="team-boxed">
        <div class="container-fluid">
            <div class="row people">
                <div class="col-md-4 col-sm-6 item">
                    <div class="box"><img class="img-circle" src="https://www.juliancharles.co.uk/media/storepickup/market-store-icon.jpg">
                        <h3 class="name">Store </h3>
                        <p class="title">Check out our store</p>
                        <p class="description">Check out our menu and grab some awesome food and drink! </p>
                        <div class="social"><a class="btn btn-link" role="button" href="Store.aspx">Take me to the STORE</a></div>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6 item">
                    <div class="box"><img class="img-circle" src="https://www.theblogstarter.com/wp-content/uploads/2014/02/4.jpg">
                        <h3 class="name">Community </h3>
                        <p class="title">Join the coffee Squad</p>
                        <p class="description">The Coffee Squad is our little community of people who just seriously LOVE coffee. Join today and become part of the family</p>
                        <div class="social"><a class="btn btn-link" role="button" href="Reviews.aspx"> Take me to the COMMUNITY</a></div>
                    </div>
                </div>
                <div class="col-md-4 col-sm-6 item">
                    <div class="box"><img class="img-circle" src="https://www.practicepanther.com//wp-content/uploads/2014/11/legal-case-management-software.png">
                        <h3 class="name">Ask Us!</h3>
                        <p class="title">Got a question?</p>
                        <p class="description">Have a question to ask or just something to share with us, send us a message here</p>
                        <div class="social"><a class="btn btn-link" role="button" href="ContactUs.aspx">Take me to CONTACT</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  <div class="map-clean">
        <div class="container">
            <div class="intro">
                <h2 class="text-center">Location </h2>
                <p class="text-center">We cannot wait to serve you! Find us here</p>
            </div>
        </div>
        <iframe allowfullscreen="" frameborder="0" width="100%" height="450" src="https://www.google.com/maps/embed/v1/place?key=AIzaSyAIdrjMC_bjBOAYQZbNKdalQFSE5-2VCoc+&amp;q=Adams+Book+Store%2C+UKZN&amp;zoom=15"></iframe>
    </div>
    </div>


</asp:Content>