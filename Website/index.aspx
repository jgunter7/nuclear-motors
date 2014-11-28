<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="slideshow" id="slideshow">
            <ol class="slides">
                <li class="current">
                    <div class="description">
                        <h2>Welcome</h2>
                        <p>With fancy 3D transitions between each slide. There is also a fallback implemented when js is disabled.</p>

                        <p>Bacon ipsum dolor amet alcatra pastrami beef ribs filet mignon cow shoulder chicken ball tip tongue hamburger turducken porchetta short loin. Tenderloin jerky leberkas, drumstick salami meatloaf beef ribs rump brisket turkey shankle ribeye venison beef. Chuck short loin pancetta, beef ribeye shank pastrami pork chop. </p>
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
                        <p>Bacon ipsum dolor amet alcatra pastrami beef ribs filet mignon cow shoulder chicken ball tip tongue hamburger turducken porchetta short loin. Tenderloin jerky leberkas, drumstick salami meatloaf beef ribs rump brisket turkey shankle ribeye venison beef.</p>
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
                        <p>Bacon ipsum dolor amet alcatra pastrami beef ribs filet mignon cow shoulder chicken ball tip tongue hamburger turducken porchetta short loin. Tenderloin jerky leberkas, drumstick salami meatloaf beef ribs rump brisket turkey shankle ribeye venison beef.</p>
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
                        <p>Bacon ipsum dolor amet alcatra pastrami beef ribs filet mignon cow shoulder chicken ball tip tongue hamburger turducken porchetta short loin. Tenderloin jerky leberkas, drumstick salami meatloaf beef ribs rump brisket turkey shankle ribeye venison beef.</p>
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
                        <p>Bacon ipsum dolor amet alcatra pastrami beef ribs filet mignon cow shoulder chicken ball tip tongue hamburger turducken porchetta short loin. Tenderloin jerky leberkas, drumstick salami meatloaf beef ribs rump brisket turkey shankle ribeye venison beef.</p>
                    </div>
                    <div class="tiltview col">
                        <a href="#">
                            <img src="img/banner/3_screen.jpg" /></a>
                        <a href="#">
                            <img src="img/banner/4_screen.jpg" /></a>
                    </div>
                </li>
                <li>
                    <div class="description">
                        <h2>Product Promo Link #2</h2>
                        <p>Bacon ipsum dolor amet alcatra pastrami beef ribs filet mignon cow shoulder chicken ball tip tongue hamburger turducken porchetta short loin. Tenderloin jerky leberkas, drumstick salami meatloaf beef ribs rump brisket turkey shankle ribeye venison beef.</p>
                    </div>
                    <div class="tiltview row">
                        <a href="#">
                            <img src="img/banner/5_mobile.jpg" /></a>
                        <a href="#">
                            <img src="img/banner/6_mobile.jpg" /></a>
                    </div>
                </li>
            </ol>
        </div>
        <!-- /slideshow -->
    </div>
    <!-- /container -->
    <script src="js/classie.js"></script>
    <script src="js/tiltSlider.js"></script>
    <script>
        new TiltSlider(document.getElementById('slideshow'));
		</script>
    <script src="js/cbpHorizontalSlideOutMenu.min.js"></script>
    <!-- SLIDE CONTROL FOR MENU-->
    <script>
        var menu = new cbpHorizontalSlideOutMenu(document.getElementById('cbp-hsmenu-wrapper'));
		</script>
</asp:Content>
