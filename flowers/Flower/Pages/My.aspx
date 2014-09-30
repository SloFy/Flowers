<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="Flower.Pages.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


  * {
    color: #000 !important;
    text-shadow: none !important;
    background: transparent !important;
    box-shadow: none !important;
  }
    
* {
  -webkit-box-sizing: border-box;
     -moz-box-sizing: border-box;
          box-sizing: border-box;
}

        .новыйСтиль1 {
            margin-top: 0px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
   
        <asp:ImageButton ID="ImageButton4" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/logo (1).png" Width="200px" style="margin-left: 375px" AccessKey="p" PostBackUrl="~/Pages/Request.aspx" ToolTip="Перейти к заказу букетов" ValidateRequestMode="Disabled" />
        <br />
        <br />
    
    </div>
        
        <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/Logo.png" Width="200px" style="margin-left: 117px"  AccessKey="p" PostBackUrl="~/Pages/Registration.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" AlternateText="Перейти к каталогу букетов" />
        <asp:ImageButton ID="ImageButton3" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/Logo.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Pages/Catalog.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
        <asp:ImageButton ID="ImageButton2" runat="server" Height="100px" ImageUrl="~/Images/Logo.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Pages/Request.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
        <asp:ImageButton ID="ImageButton5" runat="server" Height="100px" ImageUrl="~/Images/Logo.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Pages/My.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
    <div style="margin-left: 360px">
        <asp:Label ID="First_label" runat="server" Text="Добро пожаловать на форму регистрации!" BackColor="#6699FF" Width="375px" style="margin-left: 0px" ForeColor="#6699FF" Height="27px"></asp:Label>
    
    </div>
        <div style="margin-left: 100px; width: 1035px; height: 511px;" aria-disabled="False">
      
            <br />
            Имя пользователя:<asp:TextBox  ID="Login" runat="server" style="margin-left: 0px"  ></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Пароль:<asp:TextBox ID="Password" runat="server"  TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server"  Text="Вывести предыдущие заказы"  Width="250px" />
            <br />
        <br />
        <asp:Button ID="Button2" runat="server"  Text="Вывести список адресов"  Width="250px" />
        <br />
       


          
        </form>
</body>
</html>
