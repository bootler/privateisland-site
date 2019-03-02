<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PrivateIsland.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="App_Themes/CartPage.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    
    <h1 id="pageTitle">Your Island Selection</h1>
    <div id="container" class="row">
        <div id="orderItemsDiv" class="col-md-7">
            <h2 id="items">Order Items</h2>
            <asp:PlaceHolder ID="itemsPlaceHolder" runat="server">
            </asp:PlaceHolder>
        </div>
        <div id="emptydiv" class="col-md-1">
            <%--buffer column--%>
        </div>
        <div id="summary" runat="server" class="col-md-4 summary">
            <h2>Order Summary</h2>
            <hr />   
            <asp:PlaceHolder ID="summaryPlaceHolder" runat="server">
            </asp:PlaceHolder>
            <div class="row">
                <div class="col-md-8">
                    <p>Estimated fees:</p>
                </div>
                <div class="col-md-4">
                    <p id="fees" runat="server"></p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8">
                    <p style ="font-weight: bold;">TOTAL:</p>
                </div>
                <div class="col-md-4">
                    <p id="grandtotal" runat ="server"></p>
                </div>
            </div>
            <hr />
            <asp:button id="btnCheckout" CssClass="btn btn-block btn-warning" runat="server" text="Checkout" />
            <asp:Panel ID="payments" runat="server" Visible="false">
                <hr />
                <p><asp:Label ID="cname" runat="server" ForeColor="White" Text="Cardholder Name: "></asp:Label></p>
                <asp:Textbox ID="txtCName" runat="server" Width="100%"></asp:Textbox>
                <br />
                <br />
                <p><asp:Label ID="ccn" runat="server" ForeColor="White" Text="Credit Card #: "></asp:Label></p>
                <asp:Textbox ID="txtCCN" runat="server" Width="100%"></asp:Textbox>
                <hr />
                <asp:Button ID="btnProceed" CssClass="btn btn-block btn-success" OnClick="btnProceed_Click" runat="server" Text="Proceed with Payment" />
                <hr />
            </asp:Panel>
            <div class="row" style="padding-top: 15px;">
                <!-- make the container symmetrical -->
            </div>
        </div>
    </div>
    <asp:Button ID="btnReset" runat="server" CssClass="btn btn-block btn-danger" OnClick="btnReset_Click" Text="Put All Islands Up For Sale" />
</asp:Content>
