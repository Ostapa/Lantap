<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="Comp229_Project.Appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div> <%# Eval("AppointmentID") %>
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
                    <td><%# Eval("Date") %></td>      
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
    <div ID="newAppForm" runat="server" Visible="false">
        <%-- Assuming our patient is enough to input valid information --%>
        <div class="row">
            <label class="col-md-4 col-xs-12" for="date">Pick the date for your appointment: </label>
            <asp:TextBox ID="apointmentDate" CssClass="form-control col-md-4 col-xs-12" TextMode="Date" runat="server"></asp:TextBox>
        </div>
        <div class="row">
            <label for="Symptoms">Choose your symptoms:</label><br />
            <asp:ListBox ID="symptomsListBox" runat="server" SelectionMode="Multiple" Height="300"/>
        </div>
    </div>
           <asp:Button  ID="addSymptomBtn" 
                        runat="server" 
                        CssClass="btn btn-info"
                        Text="Add Symptom"
                        Visible="false"
                        OnClick="addSymptomBtn_Click"/>  
        </div>
    </div>
</asp:Content>
