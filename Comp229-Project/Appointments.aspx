<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="Comp229_Project.Appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
            <asp:Repeater ID="AppointmentList" runat="server">
                <HeaderTemplate>
            <table class="table">
        </HeaderTemplate>
        <ItemTemplate>
            <tbody>
                <tr>
                    <thead>
                    <tr>
                        <th>Appointment ID</th>
                        <th>Date</th>
                        <th>Employee ID</th>
                        <th>Department ID</th>
                    </tr>
                </thead>
                    <td><%# Eval("AppointmentsID") %></td>
                    <td><%# Eval("AppDate") %></td>      
                    <td><%# Eval("EmployeeID") %></td> 
                    <td><%# Eval("DepartmentID") %></td> 
            </tbody>
        </ItemTemplate> 
        <FooterTemplate>
            </table>
        </FooterTemplate>                                                 
    </asp:Repeater>
    
    <asp:Button ID="newAppBtn" 
                runat="server" 
                CssClass="btn btn-info"
                Text="Create new appointment"
                OnClick="newAppBtn_Click"/>
</asp:Content>
