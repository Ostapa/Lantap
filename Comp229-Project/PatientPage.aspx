<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PatientPage.aspx.cs" Inherits="Comp229_Project.PatientPage" %>

<%-- © LanTap Clinic - Aslan Mirsakiyev, Ostap Hamarnyk--%>
<%-- Comp229 Team Project --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="jumbotron">
            <div class="row">
                <div class="col-md-5 col-xs-12">
                    <img src="Assets/Images/profile_image.png" alt="Profile image" />
                </div>
                <div class="col-md-6 col-md-offset-1 well">
                    <h1>Personal Info</h1>
                    <asp:Label ID="test" runat="server" />
                    <asp:DataList ID="personalInfo" runat="server">
                                <ItemTemplate>
                                    <table class="table text-left">
                                        <tr>
                                            <td class="lead"><b>Patient ID: </b></td>
                                            <td class="lead">
                                                <asp:Label ID="PatientID" CssClass="textBox" Text=<%# Eval("PatientID")%> runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>First Name: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="FirstMidName" Text=<%# Eval("FirstMidName")%> runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Last Name: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="LastName" Text=<%# Eval("LastName")%> runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Email: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="Email" runat="server" Text=<%# Eval("Email")%>/></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Date of birth: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="DateOfBirth" runat="server" Text=<%# Eval("DateOfBirth")%>/></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Gender: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="Gender" runat="server" Text=<%# Eval("Gender")%>/></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Height: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="Height" runat="server" Text=<%# Eval("Height")%>/></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Weight: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="Weight" runat="server" Text=<%# Eval("Weight")%>/></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Address: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="Address" runat="server" Text=<%# Eval("Address")%>/>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>City: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="City" runat="server" Text=<%# Eval("City")%>/></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Postal Code: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="PostalCode" runat="server" Text=<%# Eval("PostalCode")%>/></td>
                                        </tr>
                                        <tr>
                                            <td class="lead"><b>Province: </b></td>
                                            <td class="lead">
                                                <asp:TextBox CssClass="textBox" ReadOnly="true" ID="Province" runat="server" Text=<%# Eval("Province")%>/></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                    </asp:DataList>
                    <asp:Button ID="updateBtn" CssClass="btn btn-info" runat="server" Text="Update" OnClick="updateBtn_Click"/>
                    <asp:Button ID="deleteBtn" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="deleteBtn_Click" />
                    <asp:Button ID="saveBtn" CssClass="btn btn-info" Visible="false" runat="server" Text="Save" OnClick="saveBtn_Click" />
                    <asp:Button ID="cancleBtn" CssClass="btn btn-danger" Visible="false" runat="server" Text="Cancel" OnClick="cancleBtn_Click" /> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>
