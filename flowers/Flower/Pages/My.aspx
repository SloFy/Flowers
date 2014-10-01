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
        <asp:Label ID="Welcome" runat="server" Text="Добро пожаловать на форму регистрации!" BackColor="#6699FF" Width="375px" style="margin-left: 0px" ForeColor="#6699FF" Height="27px"></asp:Label>
    
    </div>
        
      
            <asp:Image ID="logged" runat="server" ImageUrl="~/Images/Black.jpg" Visible="False" />
        
      
            <br />
            <asp:Label ID="lLogin" runat="server" style="margin-left: 15px" Text="Имя пользователя:" Width="130px"></asp:Label>
        <asp:TextBox  ID="Login" runat="server" style="margin-left: 0px"  ></asp:TextBox>
        <br />
        <asp:Label ID="lPassword" runat="server" style="margin-left: 87px" Text="Пароль:" Width="55px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Password" runat="server"  TextMode="Password" style="margin-left: -70px"></asp:TextBox>
        <br />
        <asp:Button ID="Sign" runat="server"  Text="Войти"  Width="250px" OnClick="Button1_Click" />
            <br />
        <br />
        <asp:Button ID="Badress" runat="server"  Text="Вывести список адресов"  Width="250px" Visible="False" />
        <br />
        <br />
        <asp:Button ID="Brequests" runat="server"  Text="Вывести предыдщие заказы"  Width="250px" Visible="False" />
        <br />
       


          
            <asp:Label ID="Label1" runat="server" Text="Label" Width="1009px" Height="237px" Visible="False"></asp:Label>
       


          
        </form>
</body>
</html>
