<%@ Page Title="" Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="COMP228_GroupProject_PrivateIsland.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
                    Firstname:<asp:TextBox ID="Firstnametxt" runat="server"></asp:TextBox>
                </div>
                <div>
                    Lastname:<asp:TextBox ID="Lastnametxt" runat="server"></asp:TextBox>
                </div>
                <div>
                    Date Of Birth:<asp:DropDownList ID="Year" runat="server" >

                        <asp:ListItem Value="1991"> 1991 </asp:ListItem>
                        <asp:ListItem Value="1992"> 1992 </asp:ListItem>
                        <asp:ListItem Value="1993"> 1993 </asp:ListItem>
                        <asp:ListItem Value="1994"> 1994 </asp:ListItem>
                        <asp:ListItem Value="1995"> 1995 </asp:ListItem>
                        <asp:ListItem Value="1996"> 1996 </asp:ListItem>
                        <asp:ListItem Value="1997"> 1997</asp:ListItem>
                        <asp:ListItem Value="1999"> 1999 </asp:ListItem>
                        <asp:ListItem Value="2000"> 2000 </asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="Month" runat="server">

                        <asp:ListItem Value="January"> January </asp:ListItem>
                        <asp:ListItem Value="February"> February </asp:ListItem>
                        <asp:ListItem Value="March"> March </asp:ListItem>
                        <asp:ListItem Value="April"> April </asp:ListItem>
                        <asp:ListItem Value="May"> May </asp:ListItem>
                        <asp:ListItem Value="June"> June </asp:ListItem>
                        <asp:ListItem Value="July"> July </asp:ListItem>
                        <asp:ListItem Value="August"> August </asp:ListItem>
                        <asp:ListItem Value="September"> September </asp:ListItem>
                        <asp:ListItem Value="October"> October </asp:ListItem>
                        <asp:ListItem Value="November"> November </asp:ListItem>
                        <asp:ListItem Value="December"> December </asp:ListItem>

                    </asp:DropDownList>
                    <asp:DropDownList ID="Day" runat="server" >

                        <asp:ListItem Value="1"> 1 </asp:ListItem>
                        <asp:ListItem Value="2">2 </asp:ListItem>
                        <asp:ListItem Value="3"> 3 </asp:ListItem>
                        <asp:ListItem Value="4"> 4</asp:ListItem>
                        <asp:ListItem Value="5"> 5 </asp:ListItem>
                        <asp:ListItem Value="6"> 6 </asp:ListItem>
                        <asp:ListItem Value="7"> 7 </asp:ListItem>
                        <asp:ListItem Value="8"> 8 </asp:ListItem>
                        <asp:ListItem Value="9"> 9 </asp:ListItem>
                        <asp:ListItem Value="10"> 10 </asp:ListItem>
                        <asp:ListItem Value="11"> 11 </asp:ListItem>
                        <asp:ListItem Value="12"> 12 </asp:ListItem>
                        <asp:ListItem Value="13"> 13 </asp:ListItem>
                        <asp:ListItem Value="14"> 14 </asp:ListItem>
                        <asp:ListItem Value="15"> 15 </asp:ListItem>
                        <asp:ListItem Value="16"> 16 </asp:ListItem>
                        <asp:ListItem Value="17"> 17 </asp:ListItem>
                        <asp:ListItem Value="18"> 18 </asp:ListItem>
                        <asp:ListItem Value="19"> 19 </asp:ListItem>
                        <asp:ListItem Value="20"> 20 </asp:ListItem>
                        <asp:ListItem Value="21"> 21 </asp:ListItem>
                        <asp:ListItem Value="22"> 22</asp:ListItem>
                        <asp:ListItem Value="23"> 23 </asp:ListItem>
                        <asp:ListItem Value="24"> 24 </asp:ListItem>
                        <asp:ListItem Value="25"> 25 </asp:ListItem>
                        <asp:ListItem Value="26"> 26 </asp:ListItem>
                        <asp:ListItem Value="27"> 27 </asp:ListItem>
                        <asp:ListItem Value="28"> 28</asp:ListItem>
                        <asp:ListItem Value="29"> 29 </asp:ListItem>
                        <asp:ListItem Value="30"> 30 </asp:ListItem>
                        <asp:ListItem Value="31"> 31 </asp:ListItem>

                    </asp:DropDownList>
                </div>
                <div>
                    Email Address:<asp:TextBox ID="Emailtxt" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Emailtxt" ErrorMessage="must contain valid Email information" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                </div>
                <div>
                    Phone Number:<asp:TextBox ID="PhoneNumbertxt" runat="server"></asp:TextBox>
                </div>
                <div>
                    User Name:<asp:TextBox ID="UserNametxt" runat="server"></asp:TextBox>
                </div>
                <div>
                    Password:<asp:TextBox ID="Passwordtxt" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    Confirm Password:<asp:TextBox ID="ConfirmPasswordtxt" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:CompareValidator ID="ConfirmPasswordValidator" runat="server" ErrorMessage="Password does not match" ControlToCompare="Passwordtxt" ControlToValidate="ConfirmPasswordtxt" ForeColor="Red"></asp:CompareValidator>
                </div>
                <div>
                    <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" class="btn"/>
                    <br />
                </div>
              
                    <asp:TableRow ID="Table1" runat="server"></asp:TableRow>
                   <tr>
                <td>Name</td>
                <td>Task</td>
                <td>Hours</td>
            </tr>

    </asp:Content>
