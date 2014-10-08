<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="Flower.Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 200px">
        Заполните форму заказа(поля, отмеченные знаком &quot;*&quot; заполняются обязательно):
    </div>
    <div style="margin-left: 100px; width: 979px;" aria-disabled="False">

        <br />
        Выберите тип букета*<asp:TextBox ID="Type" runat="server" Width="216px" Style="margin-left: 15px" TextMode="Number" BorderWidth="1px"></asp:TextBox>
        <asp:Label ID="ErrFlower" runat="server" Width="415px" Style="margin-left: 22px" Visible="False"></asp:Label>
        <br />
        <br />
        ФИО*<asp:TextBox ID="Name" runat="server" Width="216px" Style="margin-left: 130px" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Адрес получения*<asp:TextBox ID="Address" runat="server" Width="216px" Style="margin-left: 40px" BorderWidth="1px"></asp:TextBox>
        <br />
        <asp:Label ID="Adress_label" runat="server" Text="Выберите адрес" Visible="False"></asp:Label>
        <asp:ListBox ID="AdressBox" runat="server" DataSourceID="AdressSource" DataTextField="adress" DataValueField="adress" Rows="1" Style="margin-left: 55px" Visible="False" Width="223px"></asp:ListBox>
        <asp:SqlDataSource ID="AdressSource" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="select adress from adress where id=-1"></asp:SqlDataSource>
        <br />
        Дата и время доставки*<asp:TextBox ID="Date_Time" runat="server" Width="216px" Style="margin-left: 0px" TextMode="DateTimeLocal" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Телефон заказчика*<asp:TextBox ID="Phone_zak" runat="server" Width="216px" Style="margin-left: 28px" TextMode="Phone" MaxLength="11" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Телефон получателя*<asp:TextBox ID="Phone_pol" runat="server" Width="216px" Style="margin-left: 17px" TextMode="Phone" MaxLength="11" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Подпись к букету<asp:TextBox ID="Note" runat="server" Width="216px" Style="margin-left: 46px" BorderWidth="1px"></asp:TextBox>

        <br />

        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Оформить заказ" Width="216px" />
        <br />
        <asp:Label ID="UserList" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />





    </div>
   
</asp:Content>
