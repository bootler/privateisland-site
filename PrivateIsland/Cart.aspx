<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PrivateIsland.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="App_Themes/CartPage.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1 id="pageTitle">Your Island Selection</h1>
    <div id="container" class="row">
        <div id="orderItemsDiv" class="col-md-7">
            <h2 id="items">Order Items</h2>
            <%-- <div class="row">
                <div class="col-md-5"> 
                    <img class="preview" src="https://i.imgur.com/I5DkMRy.jpg" /> 
                </div>
                <div class="col-md-7" style="background-color:#EEEEEE;">
                    <h4>ISLAND NAME</h4>
                    <p>Some text</p>
                    <p>Some more text</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-5">
                    <img class="preview" src="https://i.imgur.com/I5DkMRy.jpg" />
                </div>
                <div class="col-md-7" style="background-color:#EEEEEE;">
                    <h4>ISLAND NAME</h4>
                    <p>Some text</p>
                    <p>Some more text</p>
                </div>
            </div>--%>
            <asp:PlaceHolder ID="itemsPlaceHolder" runat="server">
            </asp:PlaceHolder>
        </div>
        <div id="emptydiv" class="col-md-1">

        </div>
        <div id="summary" class="col-md-4">
            <h2>Order Summary</h2>
            <hr />   
            <%-- 
            <div class="row">
                <div class="col-md-8">
                    <p>Some text</p>
                </div>
                <div class="col-md-4">
                    <p>Some more text</p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <p>Some text</p>
                </div>
                <div class="col-md-4">
                    <p>Some more text</p>
                </div>
            </div>--%>
            <asp:PlaceHolder ID="summaryPlaceHolder" runat="server">
            </asp:PlaceHolder>
        </div>
    </div>
    
</asp:Content>
