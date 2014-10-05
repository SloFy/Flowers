﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Flower.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="/scripts/check.js" ></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


.btn-lg {
  padding: 10px 16px;
  font-size: 18px;
  line-height: 1.33;
  border-radius: 6px;
    height: 23px;
    width: 106px;
}

.btn-primary {
  color: #ffffff;
  background-color: #428bca;
  border-color: #357ebd;
}

.btn {
  display: inline-block;
  padding: 6px 12px;
  margin-bottom: 0;
  font-size: 14px;
  font-weight: normal;
  line-height: 1.428571429;
  text-align: center;
  white-space: nowrap;
  vertical-align: middle;
  cursor: pointer;
  border: 1px solid transparent;
  border-radius: 4px;
  -webkit-user-select: none;
     -moz-user-select: none;
      -ms-user-select: none;
       -o-user-select: none;
          user-select: none;
            margin-left: 2px;
        }

a {
  color: #428bca;
  text-decoration: none;
}

  a {
    text-decoration: underline;
  }
  
* {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}

  * {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    box-shadow: none !important;
  }
  </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
   
  <asp:ImageButton ID="ImageButton4" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/logo (1).png" Width="200px" style="margin-left: 468px" AccessKey="p" PostBackUrl="~/Pages//Main.aspx" ToolTip="Перейти к заказу букетов" ValidateRequestMode="Disabled" />
        <br />
        <br />

        <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/Registration.png" Width="200px" style="margin-left: 91px"  AccessKey="p" PostBackUrl="~/Pages/Registration.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" AlternateText="Перейти к каталогу букетов" />
        <asp:ImageButton ID="ImageButton3" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/Catalog.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Pages/Catalog.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
        <asp:ImageButton ID="ImageButton2" runat="server" Height="100px" ImageUrl="~/Images/Request.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Pages/Request.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
    
        <asp:ImageButton ID="ImageButton5" runat="server" Height="100px" ImageUrl="~/Images/My.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Pages/My.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
    
        <br />
        <br />
        <br />
        <br />
    
    </div>
        
    <div style="margin-left: 360px">
        <asp:Label ID="First_label" runat="server" Text="Добро пожаловать на форму регистрации!" BackColor="#6699FF" Width="375px" style="margin-left: 0px" ForeColor="#6699FF" Height="27px"></asp:Label>
    
    </div>
        <div style="margin-left: 100px; width: 1035px; height: 511px;" aria-disabled="False">
      
            <br />
        Введите логин*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox  ID="Login" runat="server" BorderWidth="1px"  ></asp:TextBox>
            <asp:TextBox ID="Login_error" runat="server" BorderStyle="None" style="margin-left: 40px" Width="370px"></asp:TextBox>
            <br />
        <br />
        <br />
        Введите&nbsp; пароль*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Password" runat="server"  TextMode="Password" BorderWidth="1px"></asp:TextBox>
            <br />
        <br />
        <br />
        Введите имя*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="FirstName" runat="server" BorderWidth="1px" ></asp:TextBox>
            <br />
        <br />
        <br />
        Введите фамилию&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="LastName" runat="server" BorderWidth="1px"></asp:TextBox>
            <br />
        <br />
        <br />
        Введите почту*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Mail" runat="server" TextMode="Email" ForeColor="#FF3300" BorderWidth="1px"></asp:TextBox>
            <asp:TextBox ID="Mail_error" runat="server" BorderStyle="None" style="margin-left: 40px" Width="370px" Height="17px"></asp:TextBox>
            <br />
        <br />
        <br />
        Введите телефон*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Phone" runat="server"  TextMode="Phone" BorderWidth="1px" MaxLength="11" ></asp:TextBox>
        
            <asp:TextBox ID="Phone_error" runat="server" BorderStyle="None" style="margin-left: 40px" Width="370px"></asp:TextBox>
        
            <br />
        
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Зарегистрироваться"  />
        <br />
        <br />
    
       


          
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
        <p>
            <asp:TextBox ID="UserList" runat="server" Height="173px" Width="1197px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
