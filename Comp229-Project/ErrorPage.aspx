<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ErrorPage.aspx.cs" Inherits="Comp229_Project.ErrorPage" %>

<%-- © LanTap Clinic - Aslan Mirsakiyev, Ostap Hamarnyk--%>
<%-- Comp229 Team Project --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div class="container">
        <div class="row">
            <img class="col-md-12" src="Assets/Images/404.png" alt="Error image" />
            <h1 class="display-1 col-md-12">Sorry, this page does not exist.</h1>
            <p class="lead"><a href="HomePage.aspx">Return to Lantap's main page</a></p>
        </div>
    </div>
</asp:Content>