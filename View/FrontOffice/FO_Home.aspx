<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_Home.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.FO_Home"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/FrontOffice/home.css" rel="stylesheet" />
    <link href="../../Css/FrontOffice/footer.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">
        <section class="container-cover" style="font-family: 'Nothing You Could Do', cursive;">
            <div class="cover" ">
           
                <img src="../../Images/home1.gif"
                    style="background-repeat: no-repeat; background-size: cover; width: 100%; height: 100vh;">
                
                    <div class="cover-text"><span style="font-size: 66px; color: black">Animals . Love . Home<span style="font-family: 'Poppins', sans-serif;">
                            </span></span>
                    <p style="font-size: 30px; font-weight: 300; color: black; font-family: 'Poppins', sans-serif; padding-top: 360px">
                        Looking to adopt a pet? Come visit us!</p>
                </div>
            </div>
        </section>
        <div class="section-divider"></div>
        <!--Section Breaker-->
        <div class="section-divider"></div>
        <section class="container">
            <h1>Find your new best friend!</h1>
           
            <div class="row-1">

                <div class="col">
                    <img src="../../Images/home2.gif" style="padding-left: 100px">
                </div>

                <div class="col" style="text-align: left; padding: 50px; padding-left: 50px; padding-right: 100px;">
                    <h2 style="font-size: 20px; font-weight: bold">Adopt a pet and save a life</h2>
                    <h2 style="font-size: 20px; font-weight: 200"> You can save the life of a dog or cat by choosing to adopt. In 2020, around 347,000 cats and dogs were killed in this country’s shelters, simply because they didn’t have a safe place to call home. </h2>

                    <button type="button" onclick="window.location = './Pet/FO_PetSummary.aspx'">View Pets &#10141;</button>
                </div>
            </div>

        </section>

        <div class="section-divider"></div>
        <!--Section Breaker-->
        <div class="section-divider"></div>


        <section class="container">
            <h1>Pet adoption tips</h1>

            <div class="row-1">
                <div class="col">
                    <img src="../../Images/home3.gif">
                </div>

                <div class="col" style="text-align: left; padding: 50px; padding-left: 50px; padding-right: 100px;">
                    <h2 style="font-size: 25px;font-weight: bold"><i>Why adoption over buying</i>
                    </h2>
                    <h2 style="font-size: 20px; font-weight: 200;">Did you know that over 1,000 people per hour run a search right here looking to adopt a pet? 
                        <br><br>Pet adoption is quickly becoming the preferred way to find a new dog or cat, and rightly so, there are many benefits to adopting a pet. 
                        <br><br>Pet adoption fees are usually much lower than buying from a breeder. You’re also likely to find a pet who’s already learned a few things. 
                        <br><br>Adoptable pets are often already housetrained, good with kids, and do well with other pets. And don’t forget the wonderful feeling you get from saving a life!</h2>
                </div>
            </div>
            <div class="row-1">
                <div class="col">
                    <img src="../../Images/home4.gif">
                </div>

                <div class="col" style="text-align: left; padding: 50px; padding-left: 50px; padding-right: 100px;">
                    <h2 style="font-size: 25px;font-weight: bold"><i>How to find the perfect pet</i>
                    </h2>
                    <h2 style="font-size: 20px; font-weight: 200;">Do you know what type of pet personality you’re looking for? 
                        <br><br>Finding the ideal pet for your home should start with understanding the personality that best fits your lifestyle, not necessarily a specific breed. 
                        <br><br>Consider this, do you need a dog that is low key? Perhaps a cat that gets along well with others? 
                        <br>The rescue professionals posting on our site are experts at matching you with the right pet. </h2>
                </div>
            </div>

        </section>

    </section>
    <div class="info-tab">
    <div class="info-row">
        <div class="info-column">
            <h1><span class="logo-text">Adopt Me</span><img style="height: 30px; width: 30px;"
                    src="https://img.icons8.com/ios/100/9D00FF/camellia.png" /></h1>

            <p>11-C, Adopt Me HQ</p>
            <p>Karpal Singh Drive</p>
            <p>Lebuh Sungai Pinang</p>
            <p>11600 Pulau Pinang</p>

            <br>
            <p>Email : adoptme.ewyv.noreply@gmail.com</p>
            <p>WhatsApp : +6012-345678</p>
        </div>

        <div class="info-column">
            <h1>Site Map</h1>
            <p><a href="FO_Home.aspx">Home</a></p>
            <p><a href="Pet/FO_PetSummary.aspx">Pet</a></p>
            <p><a href="Customer/FO_CustSignUp.aspx">Join Us</a></p>
            <p><a href="FO_AboutUs.aspx">About Us</a></p>
            <p><a href="Customer/FO_CustViewAcc.aspx">My Profile</a></p>
        </div>

        <div class="info-column">
            <h1>Support</h1>
            <p><a href="https://www.facebook.com/floralartforum/" target="_blank">Terms & Conditions</a></p>
            <p><a href="https://www.facebook.com/floralartforum/" target="_blank">Community</a></p>
            <p><a href="mailto:adoptme.ewyv.noreply@gmail.com">Email Us</a></p>
        </div>

        <div class="info-column">
            <h1>Follow Us Now</h1>
            <a href="https://www.facebook.com" target="_blank"><img class="sicon"
                    src="https://img.icons8.com/ios-glyphs/30/00000/facebook.png" /></a>
            <a href="https://www.instagram.com" target="_blank"><img class="sicon"
                    src="https://img.icons8.com/ios-glyphs/30/00000/instagram-new.png" /></a>
            <a href="https://www.twitter.com/" target="_blank"><img class="sicon"
                    src="https://img.icons8.com/ios-glyphs/30/00000/twitter.png" /></a>
            <a href="https://www.pinterest.com/" target="_blank"><img class="sicon"
                    src="https://img.icons8.com/ios-glyphs/30/00000/pinterest.png" /></a>
            <a href="https://www.linkedin.com/" target="_blank"><img class="sicon"
                    src="https://img.icons8.com/ios-glyphs/30/00000/linkedin-2--v1.png" /></a>

            <br>
        </div>
    </div>
</div>
</asp:Content>
