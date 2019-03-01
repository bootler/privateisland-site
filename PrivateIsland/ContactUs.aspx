<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="PrivateIsland.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes/ContactPage.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <br />
            Please complete the form below, choosing the category that best describes the nature of your inquiry. You will be contacted by our staff as soon as possible. Or send to <a href="mailto:csun28@my.centennialcollege.ca">csun28@my.centennialcollege.ca</a><br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:Label ID="LabelFirstName" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelLastName" runat="server" Text="Last Name"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelPhone" runat="server" Text="Phone"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelTypeofInquiry" runat="server" Text="Type of Inquiry"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelPreferredMethodContact" runat="server" Text="Preferred Method of Contact"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:DropDownList ID="DropDownListInquiry" runat="server">
                            <asp:ListItem>General Inquiry</asp:ListItem>
                            <asp:ListItem>Rental Inquiry</asp:ListItem>
                            <asp:ListItem>Media Inquiry</asp:ListItem>
                            <asp:ListItem>Consultation Inquiry</asp:ListItem>
                            <asp:ListItem>Advertising Inquiry</asp:ListItem>
                            <asp:ListItem>Island Hunters Inquiry</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style2">
                        <asp:RadioButtonList ID="RadioButtonListMethod" runat="server">
                            <asp:ListItem>Phone</asp:ListItem>
                            <asp:ListItem>Email</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LabelMessage" runat="server" Text="Message"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TextBoxMessage" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="LabelDB" runat="server" Text="DB view"></asp:Label>
            <br />
        </div>
</asp:Content>
