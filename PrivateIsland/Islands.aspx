<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="Islands.aspx.cs" Inherits="PrivateIsland.Islands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="App_Themes/IslandPage.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
   <h1 style="text-align:center; font-family:'Pacifico',cursive; color: #222; font-weight: bold;">Islands For Sale</h1>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
    </asp:PlaceHolder>
    <hr />
</asp:Content>

