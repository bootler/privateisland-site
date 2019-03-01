<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PrivateIsland.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="App_Themes/CartPage.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 id="pageTitle">Your Island Selection</h1>
    <div id="container" class="row">
        <div id="orderItemsDiv" class="col-md-7">
            <h2 id="items">Order Items</h2>
            <asp:PlaceHolder ID="itemsPlaceHolder" runat="server">
            </asp:PlaceHolder>
        </div>
        <div id="emptydiv" class="col-md-1">
    </div>
    <div id="summary" class="col-md-4">
            <h2>Order Summary</h2>
            <hr />   
            <asp:PlaceHolder ID="summaryPlaceHolder" runat="server">
            </asp:PlaceHolder>
        </div>
    </div>
    
</asp:Content>
