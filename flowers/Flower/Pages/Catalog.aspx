﻿<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Flower.Catalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="CatalogContainer">
        <br />
        <asp:Label ID="Privet" runat="server" Text="В данный момент имеются букеты :" Style="margin-left: 442px" Width="269px"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Flw1" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" ImageUrl="~/Images/1.png" />
        <asp:Image ID="Flw2" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" ImageUrl="~/Images/2.png" />
        <asp:Image ID="Flw3" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" ImageUrl="~/Images/3.png" />
        <asp:Image ID="Flw4" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" ImageUrl="~/Images/4.png" />
        <br />
        <br />
        <asp:Label ID="LFlw1" runat="server" Style="margin-left: 75px" Width="170px">1</asp:Label>
        <asp:Label ID="LFlw2" runat="server" Style="margin-left: 115px" Width="170px">2</asp:Label>
        <asp:Label ID="LFlw3" runat="server" Style="margin-left: 115px" Width="170px">3</asp:Label>
        <asp:Label ID="LFlw4" runat="server" Style="margin-left: 115px" Width="170px">4</asp:Label>
        <br />
        <br />
        <asp:Image ID="Flw5" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" ImageUrl="~/Images/5.png" />
        <asp:Image ID="Flw6" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw7" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw8" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <br />
        <br />
        <asp:Label ID="LFlw5" runat="server" Style="margin-left: 75px" Width="170px">5</asp:Label>
        <asp:Label ID="LFlw6" runat="server" Style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw7" runat="server" Style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw8" runat="server" Style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Flw9" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw10" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw11" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw12" runat="server" Height="220px" Width="220px" Style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <br />
        <br />
        <asp:Label ID="LFlw9" runat="server" Style="margin-left: 75px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw10" runat="server" Style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw11" runat="server" Style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw12" runat="server" Style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>   
        </div>   
</asp:Content>
