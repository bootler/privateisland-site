<%@ Page Language="C#" MasterPageFile="~/PrivateIslands.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PrivateIsland.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <p>
            <asp:Label ID="lblTitle" runat="server" Text="Private Islands"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblDescription" runat="server" Text="Do you enjoy hiking, camping, swimming or other outdoor activities? Private islands are all about being able to do whatever you enjoy whenever you want. We guarantee the highest quality in our private island selection that you will find nowhere else. We offer the most varied selection all across the world at the most affordable prices. Decorate your own island howver you like and do whatever you want; your imagination is the limit!"></asp:Label>
        </p>
    </div>
    <div>
        <p>
            <asp:Label ID="lblStaff" runat="server" Text="Staff Information"></asp:Label>
        </p>
        <p>
            <asp:BulletedList ID="BulletedList1" runat="server">
                <asp:ListItem Value="Neil Johnson was just a young boy when he dreamed about having his own property. He wanted to be limited by his own imagination rather than being confined by the land he lived on that belonged to others. Thus, he worked hard and established Private Islands to allow others make their dreams come true."></asp:ListItem>
                <asp:ListItem Value="Bobby Joe believed he had everything he would ever want when he befriended Neil Johnson at a young age. However, when he experienced a private island for the first time, he was determined to bring this happy experience to people around the world."></asp:ListItem>
            </asp:BulletedList>
        </p>
        <p>
            <asp:Label ID="lblEnding" runat="server" Text="Find the perfect private island for you now!"></asp:Label>
        </p>
        <p>
            <asp:HyperLink runat="server" NavigateUrl="https://google.com">
            <asp:Image runat="server" ImageUrl="https://media1.popsugar-assets.com/files/thumbor/wUEMa3RXbiTFzacFXBzrJAjSmbI/fit-in/1024x1024/filters:format_auto-!!-:strip_icc-!!-/2017/08/16/889/n/43806392/d63e1b845994a915ebf415.03791968_edit_img_cover_file_18910047_1502912208/i/Private-Islands-You-Can-Rent.jpg" Style="-webkit-user-select: none;" Width="1024"/>
            </asp:HyperLink>
        </p>
    </div>
</asp:Content>