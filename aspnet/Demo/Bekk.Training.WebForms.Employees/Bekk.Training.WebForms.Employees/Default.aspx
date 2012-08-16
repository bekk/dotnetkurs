<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Bekk.Training.WebForms.Employees._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">    
    <asp:GridView ID="EmployeeGrid" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText = "Name" DataField="Name" />
            <asp:BoundField HeaderText = "Position" DataField="Position" />
            <asp:BoundField HeaderText = "Phone" DataField="Phone" />
            <asp:BoundField HeaderText = "Email" DataField="Email" />
        </Columns>
    </asp:GridView>
</asp:Content>
