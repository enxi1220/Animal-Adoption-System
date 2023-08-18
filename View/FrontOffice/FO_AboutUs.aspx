<%@ Page Title="" Language="C#" MasterPageFile="~/FO_MasterPage.Master" AutoEventWireup="true" CodeBehind="FO_AboutUs.aspx.cs" Inherits="AnimalAdoptionSystem.View.FrontOffice.FO_AboutUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/FrontOffice/aboutus.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/a6bc3098ca.js" crossorigin="anonymous"></script>
    <style type="text/css">
        .auto-style1 {
            left: -557px;
            top: -445px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content">

            <section class="container-cover" style="font-family: 'Poppins', sans-serif" ; font-weight: 500>
                <div class="cover">

                    <div class="cover-text"><span style="font-size: 66px;">Who Are We<span style="font-family: 'Poppins', sans-serif;">
                                </span></span>
                        <p style="font-size: 30px; font-weight: 300; color: #ffffff; font-family: 'Poppins', sans-serif;">
                            About Adopt Me</p>
                    </div>
                </div>
            </section>
            <div class="section-divider"></div>
            
            <section class="container">
                <h1>Our Story</h1>
                <p>We were creating a sanctuary for homeless and special-needs animals literally from the ground up.</p>
                <div class="section-divider"></div>

                <div class="card">
                    <div class="imgBox">
                        <img src="../../Images/about2.png">
                        <img src="../../Images/about3.png" class="auto-style1">

                    </div>
                    <div class="details">
                        <div class="content2">
                            <h1 style="color: rgba(50, 157, 135, 255)"><br>Pet Adopt<span>&#174;</span></h1><br>
                            <h2 style="color: rgba(46, 222, 186, 255)">We absolutely love animals</h2>
                            <p>and we think humans are pretty swell, too. That’s why we’ve got people around the country working to make the world a kinder and more compassionate place.</p><br>
                            <h2 style="color: rgba(46, 222, 186, 255)">We started with little fanfare</h2><br>
                            <p>And even fewer resources. We were creating a sanctuary for homeless and special-needs animals literally from the ground up. We were forging roadways and erecting buildings with our bare hands.</p>
                            <br />
                        </div>
                    </div>
                </div>
            </section>
            
            <div class="section-divider"></div>
            <!--Section Breaker-->
            <div class="section-divider"></div>
            
            <section>
                <div class="row-1">
                    <div class="col">
                        <a href="#"><img src="../../Images/about4.png"
                                style="box-shadow: 1px 3px 30px rgba(30, 30, 30, 0.25);"></a>
                    </div>

                    <div class="col" style="text-align: left; padding: 50px; padding-left: 10px; padding-right: 100px;">
                        <h2 style="font-size: 20px; font-weight: 200;">
                            <b>Our mission</b></h2>
                            <ul class="core">
                                <li><span class="fa-li"><i class="fa-solid fa-thumbs-up"></i></span>Increase public awareness of the availability of high-quality adoptable pets</li>
                                <li><span class="fa-li"><i class="fa-solid fa-thumbs-up"></i></span>Increase the overall effectiveness of pet adoption programs across North America to the extent that the euthanasia of adoptable pets is eliminated</li>
                                <li><span class="fa-li"><i class="fa-solid fa-thumbs-up"></i></span>Elevate the status of pets to that of family member</li>
                            </ul>
                        <br><br>
                    </div>
                </div>
            </section>
   
        </section>
        <div class="section-divider"></div>
        <!--Section Breaker-->
        <div class="section-divider"></div>
        <div class="maps">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15964978.963638429!2d80.0786775762154!3d12.335971770372343!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31cc495557945317%3A0xd85d610957e55ffe!2sPet%20Lovers%20Centre%20-%20SS2%20Central!5e0!3m2!1sen!2smy!4v1663833820892!5m2!1sen!2smy" width="600" height="450" style="border:0; display: block; margin-right: auto; margin-left:auto;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
        <div class="section-divider"></div>
        <!--Section Breaker-->
        <div class="section-divider"></div>
        <div id="footer">
            <!--FOOTER INCLUDED-->
        </div>
</asp:Content>
