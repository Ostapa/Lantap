<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Comp229_Project.HomePage" %>

<%-- © LanTap Clinic - Aslan Mirsakiyev, Ostap Hamarnyk--%>
<%-- Comp229 Team Project --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="banner" class="carousel-banner hidden-xs" data-ride="carousel">

        <!-- buttons to switch between the slides -->
        <ol class="carousel-indicators">
            <li data-target="#banner" data-slide-to="0" class="active"></li>
            <li data-target="#banner" data-slide-to="1"></li>
            <li data-target="#banner" data-slide-to="2"></li>
        </ol>

        <!-- slides -->
        <div class="carousel-inner" role="listbox">
            <div id="nurse" class="item active">
                <img src="Assets/Images/banner_nurse.jpg" alt="Clinic" />
                <div class="carousel-caption centered">
                    <h1 class="display-1">Our clinic is considered to be one of the top five clinics in Canada</h1>
                    <p class="lead">Every year we help our patients with simple illnesses as we as chronical diseases</p>
                </div>
            </div>
            <div class="item">
                <img src="Assets/Images/banner_building.jpg" alt="Clinic" />
                <div class="carousel-caption centered">
                    <h1 class="display-1">Lantap Clinic employs more than 500 professional therapists</h1>
                    <p class="lead">We select only the best candidates, so patients can rely on our services</p>
                </div>
            </div>
            <div class="item">
                <img src="Assets/Images/cbanner_caring.jpg" alt="Clinic" />
                <div class="carousel-caption centered">
                    <h1 class="display-1">Our fully-quilified therapists treat patients as closest relatives</h1>
                    <p class="lead">We believe that these relationships between patients and staff make our patients recover faster</p>
                </div>
            </div>
        </div>

        <!-- Buttons(Controls) to switch between slides -->
        <a class="left carousel-control" href="#banner" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#banner" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <div class="container">
         <div class="row text-center">
            <div class="col-md-10 col-md-offset-1 col-sm-6 col-sm-offset-3 col-xs-12">
                <img src="Assets/Images/lantap_logo.png" alt="LanTap Logo" />
            </div>
            <div class="col-md-12">
                <h1 class="display-2 ">LanTap Clinic</h1>
                <p class="lead">Lantap clinic is downtown’s Toronto newest medical health care centre.<br /> It is one of the most popular due to its excellent customer service, great number of fully-qualified therapists and location.
                <p class="lead"> Thousands of customers attend clinic every day to get treatment, professional advice & medical support</p>
            </div>
        </div>  
        <div class="home">
            <div class="row">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-xs-12 desc">
                    <h1 class="display-3"><b>LanTap Clinic</b></h1>
                    <h1 class="display-5">We do our best to keep you healthy.</h1>
                    <p class="lead">Our therapists work hard every day to provide Lantap's patients with the best and the most suitable treatment.</p> 
                    <p class="lead">We examine up to 500 patients every day and 95&#37 of our patients leave our clinic with smile on their faces.</p>
                    <p class="lead">We are glad to welcome new patients, to take care of their health and nutrition. Professionals from different departments will do their best to provide you with the best treatment and prescription.</p>
                    <!-- add more text here, maybe iFrame with news, will see -->
                </div>
            </div>
        </div>
        <asp:Label ID="test" runat="server" />
    </div>

</asp:Content>
