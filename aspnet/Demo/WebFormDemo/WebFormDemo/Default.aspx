<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebFormDemo._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="InformationLabel" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="EventHandlerButton" runat="server" Text="Click to update label" 
        onclick="EventHandlerButton_Click" />
</asp:Content>
