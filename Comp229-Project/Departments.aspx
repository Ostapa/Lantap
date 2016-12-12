<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Departments.aspx.cs" Inherits="Comp229_Project.Departments" %>


<%-- © LanTap Clinic Ostap Hamarnyk--%>
<%-- Comp229 Team Project --%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
            <div class="jumbotron">
    <asp:Repeater ID="departmentList" runat="server">  
        <HeaderTemplate>
            <table class="table">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Department ID</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr>
                    <td><%# Eval("DepartmentTitle") %></td>
                    <td><%# Eval("DepartmentID") %></td>                                 
            </tbody>
        </ItemTemplate> 
        <FooterTemplate>
            </table>
        </FooterTemplate>                                                 
    </asp:Repeater>
    </div>
        </div>
</asp:Content>
