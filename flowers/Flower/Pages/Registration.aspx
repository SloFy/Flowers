<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Flower.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/Check.js"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 360px">
        <asp:Label ID="First_label" runat="server" Text="Добро пожаловать на форму регистрации!" Width="375px" Style="margin-left: 0px" Height="27px"></asp:Label>

    </div>
    <div style="margin-left: 100px; width: 1035px; height: 511px;" aria-disabled="False">

        <br />
        Введите логин*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Login" runat="server" BorderWidth="1px"></asp:TextBox>
        <asp:Label ID="Login_error" runat="server" BorderStyle="None" Style="margin-left: 40px" Width="370px"></asp:Label>
        <br />
        <br />
        <br />
        Введите&nbsp; пароль*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Password" runat="server" TextMode="Password" BorderWidth="1px"></asp:TextBox>
        <asp:Label ID="Pass_error1" runat="server" BorderStyle="None" Style="margin-left: 40px" Width="370px"></asp:Label>
        <br />
        <br />
        Подтвердите пароль*
        <asp:TextBox ID="Password2" runat="server" TextMode="Password" BorderWidth="1px" style="margin-left: 0px"></asp:TextBox>
        <asp:Label ID="Pass_error2" runat="server" BorderStyle="None" Style="margin-left: 40px" Width="370px"></asp:Label>
        <br />
        <br />
        Введите имя*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="FirstName" runat="server" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        <br />
        Введите фамилию&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="LastName" runat="server" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        <br />
        Введите почту*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Mail" runat="server" TextMode="Email" BorderWidth="1px"></asp:TextBox>
        <asp:Label ID="Mail_error" runat="server" BorderStyle="None" Style="margin-left: 40px" Width="370px" Height="17px"></asp:Label>
        <br />
        <br />
        <br />
        Введите телефон*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Phone" runat="server" TextMode="Phone" BorderWidth="1px" MaxLength="11"></asp:TextBox>

        <asp:Label ID="Phone_error" runat="server" BorderStyle="None" Style="margin-left: 40px" Width="370px"></asp:Label>

        <br />

        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Зарегистрироваться" />
        <br />
        <br />





        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <p>
        <asp:Label ID="UserList" runat="server" Height="16px" Width="366px"></asp:Label>
    </p>
</asp:Content>
