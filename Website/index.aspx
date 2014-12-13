<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="slideshow" id="slideshow">
            <ol class="slides">
                <li class="current">
                    <div class="description">
                        <h2>Welcome</h2>
                        <p>With fancy 3D transitions between each slide. There is also a fallback implemented when js is disabled.</p>

                        <p>You have reached the online shop of Nuclear Motors. Here, we sell car products ranging from the vehicles to car accessories. Feel free to browse and purchase products you may need for the future. Please note that you will be required to create an account to access the shopping cart.</p>
                    </div>
                    <div class="tiltview col">
                        <a href="#">
                            <img src="img/banner/cars-1.png" /></a>
                        <a href="#">
                            <img src="img/banner/cars-2.png" /></a>
                    </div>
                </li>
                <li>
                    <div class="description">
                        <h2>Frequently Asked Questions</h2>
                        <p>1. <b>I can't access the shopping cart?</b> Please create an account. Also your session may have timed out, so please login once again.</p>
                        <p>2. <b>Session Timeout?</b> Your session may have timed out, if it has been 10 minutes of inactivity.</p>
                        <p>3. <b>Why do you have so few products?</b> We are a small company, as the company grows more products will be available.</p>
                    </div>
                    <div class="tiltview row">
                        <a href="#">
                            <img src="img/banner/3_mobile.jpg" /></a>
                        <a href="#">
                            <img src="img/banner/4_mobile.jpg" /></a>
                    </div>
                </li>
                <li>
                    <div class="description">
                        <h2>About Us</h2>
                        <p>The people behind Nuclear Motors belong to COMP 229 : Advanced Web Application Development, Section 062, Group 2.</p>
                        <ul>
                        <li>John Dimitriadis</li>
                        <li>Jason Gunter</li>
                        <li>George Savchenko</li>
                        <li>Elaine Mae Villarino</li><br></ul>
                        <p>Professor : Joanne Filotti</p>
                        <p>Centennial College</p>
                        <p>Fall 2014</p>
                    </div>
                    <div class="tiltview col">
                        <a href="#">
                            <img src="img/banner/5_screen.jpg" /></a>
                        <a href="#">
                            <img src="img/banner/6_screen.jpg" /></a>
                    </div>
                </li>
                <li>
                    <div class="description">
                        <h2>Contact Us</h2>
                        <p>If you have any inquiries or general questions please contact us. We will strive to answer you as soon as possible.</p>
                        <p>You will be able to reach us via: <br><em>geninquiry@nuclearmotors.ca</em><br> or <br><em>accounthandle@nuclearmotors.ca</em></p>
                        
                    </div>
                    <div class="tiltview row">
                        <a href="#">
                            <img src="img/banner/1_mobile.jpg" /></a>
                        <a href="#">
                            <img src="img/banner/2_mobile.jpg" /></a>
                    </div>
                </li>
                <li>
                    <div class="description">
                        <h2>Product Promo Link #1</h2>
                        <p>We apologize there are no current available product promos. Please check back often, you never know that you may encounter a flash sale.</p>
                    </div>
                    <div class="tiltview col">
                        <a href="#">
                            <img src="img/banner/cars-1.png" /></a>
                        <a href="#">
                            <img src="img/banner/cars-2.png" /></a>
                    </div>
                </li>
                <li>
                    <div class="description">
                        <h2>Product Promo Link #2</h2>
                        <p>We apologize there are no current available product promos. Please check back often, you never know that you may encounter a flash sale.</p>
                    </div>
                    <div class="tiltview row">
                        <a href="#">
                            <img src="img/banner/cars-1.png" /></a>
                        <a href="#">
                            <img src="img/banner/cars-2.png" /></a>
                    </div>
                </li>
            </ol>
        </div>
        <!-- /slideshow -->  
    <script src="js/tiltSlider.js"></script>
    <script>
        new TiltSlider(document.getElementById('slideshow'));
    </script>
    </div>
    <!-- /container -->
</asp:Content>
