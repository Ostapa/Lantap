<%@ Page Title="Contacts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactPage.aspx.cs" Inherits="Comp229_Project.ContactPage" %>

<%-- © LanTap Clinic - Aslan Mirsakiyev, Ostap Hamarnyk--%>
<%-- Comp229 Team Project --%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <%--Contact Form--%>
    <div class="container">
        <div class="col-md-10 col-md-offset-1 col-sm-16 col-xs-12 well">
            <table>
                <tr>
                    <td>
                        <%--Name--%>
                        <label for="nameLabel">Name:</label>
                        <asp:TextBox    ID="txtName" 
                                        CssClass="form-control" 
                                        runat="server" />
                        <div>
                            <asp:RequiredFieldValidator     ID="txtNameReqFieldValidator"
                                                            runat="server"
                                                            CssClass="validationError"
                                                            ControlToValidate="txtName"
                                                            ErrorMessage="* Please enter your Name" 
                                                            ValidationGroup="Contact"
                                                            required="true"/>
                        </div>

                        <div>
                            <%--Email--%>
                            <label for="emailLabel">Email:</label>
                            <asp:TextBox    ID="txtEmail" 
                                            CssClass="form-control" 
                                            runat="server" />
                        </div>
                        <div>
                            <asp:RequiredFieldValidator     ID="txtEmailReqFieldValidator"
                                                            runat="server"
                                                            CssClass="validationError"
                                                            ControlToValidate="txtEmail"
                                                            ErrorMessage="* Please enter your Email" 
                                                            ValidationGroup="Contact"
                                                            required="true"/><br />
            
                            <asp:RegularExpressionValidator ID="regexEmailValidator" 
                                                            runat="server" 
                                                            CssClass="validationError"
                                                            ControlToValidate="txtEmail"
                                                            ValidationGroup="Contact"
                                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"                                              
                                                            ErrorMessage="* Invalid Email format"/>
                        </div>

                        <div>                       
                            <%--Comments--%>
                            <div>
                                <label for="commentsLabel">Comments:</label>
                                <asp:TextBox    ID="txtComments" 
                                                TextMode="multiline" 
                                                Columns="55" 
                                                Rows="7" 
                                                CssClass="sizeLock"
                                                runat="server" />
                            </div>
                            <div>
                                <asp:RequiredFieldValidator     ID="txtCommentsReqFieldValidator"
                                                                runat="server"
                                                                CssClass="validationError"
                                                                ControlToValidate="txtComments"
                                                                ErrorMessage="* Please enter your Comments" 
                                                                ValidationGroup="Contact"
                                                                required="true"/><br />
                            </div>                           
                        </div>

                        <%--Submit button--%>
                        <div>
                            <asp:Button ID="submitBtn" 
                                        CssClass="btn btn-info" 
                                        Text="Send" 
                                        ValidationGroup="Contact"                        
                                        runat="server" 
                                        OnClick="submitBtn_Click" />
                        </div>
                    </td>
                    <td>
                        <div class="jumbotron">
                            <h2>
                                Our contacts:
                            </h2>             
                            <p>
                                 Email:<br /><a href="mailto:support@lantap.azurewebsites.net">support@lantap.azurewebsites.net</a>
                            </p>
                            <p>
                                 Mobile Phone:<br /> <a href="tel:+16477777777">(647)-777-7777</a>
                            </p>
                            <asp:HyperLink    ID="hlFacebook" 
                                              ImageUrl="Assets/Images/facebookLogo.png"
                                              NavigateUrl="https://www.facebook.com/groups/1/"
                                              Text="Facebook Group"
                                              runat="server"/>  

                            <asp:HyperLink    ID="hlTwitter" 
                                              ImageUrl="Assets/Images/twitterLogo.png"
                                              NavigateUrl="https://twitter.com/lantap_clinic"
                                              Text="Twitter account"
                                              runat="server"/>

                            <asp:HyperLink    ID="hlInstagram" 
                                              ImageUrl="Assets/Images/instagramLogo.png"
                                              NavigateUrl="https://www.instagram.com/lantap_clinic/"
                                              Text="Instagram account"
                                              runat="server"/>

                            <asp:HyperLink    ID="hlGithub" 
                                              ImageUrl="Assets/Images/githubLogo.png"
                                              NavigateUrl="https://github.com/mirsakiyev/Comp229-TeamProject"
                                              Text="GitHub Repo"
                                              runat="server"/>                                                     
                        </div>
                    </td>
                </tr>                
            </table>
         </div>
    </div>
</asp:Content>
