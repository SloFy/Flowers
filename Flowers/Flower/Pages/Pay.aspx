<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Pay.aspx.cs" Inherits="Flower.Pages.Pay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="Privet" runat="server" Text="Оплата по карте:" Style="margin-left: 442px" Width="269px"></asp:Label>
        <br />
    <div style="margin-left: 100px; width: 1035px; height: 511px;" aria-disabled="False">

        <br />
        Номер карты
        <asp:TextBox ID="Login" runat="server" BorderWidth="1px"  Style="margin-left: 15px" Width="170px"></asp:TextBox>
           
        &nbsp;
           
        CVC/CVC2<asp:TextBox ID="CVC" runat="server" TextMode="Password" Style="margin-left: 10px" BorderWidth="1px"></asp:TextBox>
           
        <br />
        <br />
        Имя владельца<asp:TextBox ID="Name" runat="server" TextMode="Password" Style="margin-left: 5px" BorderWidth="1px"></asp:TextBox>
        <br />

        <br />

        <asp:Button ID="Button1" runat="server" Text="Опалатить" />
              </div>
    </asp:Content>
