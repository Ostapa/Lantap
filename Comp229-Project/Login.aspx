<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="Comp229_Project.Login" %>

<%-- background: linear-gradient(to left, #70e1f5 , #ffd194) --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="loginUser" runat="server" OnAuthenticate="loginUser_Authenticate">
        <LayoutTemplate>
            <a href="HomePage.aspx"><img src="Assets/Images/lantap_logo.png" alt="Lantap logo" /></a>
            <div class="container well">
                <div class="form-group">
                    <label for="UserName">Username</label>
                    <asp:TextBox ID="UserName" CssClass="form-control" runat="server" />
                    <p>
                        <asp:RequiredFieldValidator ID="UsernameReqFieldValidator"
                            runat="server"
                            CssClass="validationError"
                            ControlToValidate="UserName"
                            ValidationGroup="Login"
                            ErrorMessage="* Please enter username" />
                    </p>
                    <label for="Password">Password</label>
                    <asp:TextBox ID="Password" CssClass="form-control" TextMode="Password" runat="server" />
                    <asp:RequiredFieldValidator ID="PasswordReqFieldValidator"
                            runat="server"
                            CssClass="validationError"
                            ControlToValidate="Password"
                            ValidationGroup="Login"
                            ErrorMessage="* Please enter password<br/>" 
                            Display="Dynamic"/>
                    <p><small class="validationError"><asp:Literal ID="FailureText" runat="server"></asp:Literal></small</p>
                    <small class="text-muted"><a href="Recover" class="unstyled">Forgot password?</a></small><br />
                    <asp:Button ID="loginBtn"
                        CssClass="btn btn-info login-btn"
                        CommandName="Login"
                        ValidationGroup="Login"
                        Text="Login"
                        runat="server" />
                    <asp:Label ID="executeScalarTest" runat="server" />
                </div>
                <hr />
                <p class="small">Do not have an account yet? <a href="RegistrationPage">Join us today!</a></p>
            </div>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>


