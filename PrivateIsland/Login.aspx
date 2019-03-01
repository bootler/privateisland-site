<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PrivateIsland.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="cont" runat="server">
            <div>
             User Name:<asp:TextBox ID="UserNametxtbox" runat="server"></asp:TextBox>
            </div>
            <div>
                Password:<asp:TextBox ID="Passwordtxtbox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="LogInbtn" runat="server" Text="Log In" OnClick="LogInbtn_Click" />
            </div>
            <div>
                <asp:Label ID="LogInLabel" runat="server"></asp:Label>
            </div>
        </div>
</asp:Content>
