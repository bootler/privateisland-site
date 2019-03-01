<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="Islands.aspx.cs" Inherits="PrivateIsland.Islands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="App_Themes/IslandsPage.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h1 style="text-align:center;">Islands For Sale</h1>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
    </asp:PlaceHolder>
    <hr />
</asp:Content>
