<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Flower.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
     <p style="margin-left: 200px">
&nbsp;&nbsp;&nbsp;
     <a class="btn btn-primary btn-lg" href="http://localhost:51550/Catalog.aspx">На главную</a>
     </p>
    <form id="form1" runat="server">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/Logo.png" Width="200px" style="margin-left: 50px"  AccessKey="p" PostBackUrl="~/Catalog.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" AlternateText="Перейти к каталогу букетов" />
        <asp:ImageButton ID="ImageButton3" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/Logo.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Catalog.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
        <asp:ImageButton ID="ImageButton2" runat="server" Height="100px" ImageUrl="~/Images/Logo.png" Width="200px" style="margin-left: 50px" AccessKey="p" PostBackUrl="~/Catalog.aspx" ToolTip="Перейти к каталогу букетов" ValidateRequestMode="Disabled" />
    <div style="margin-left: 360px">
        <asp:Label ID="First_label" runat="server" Text="Добро пожаловать на форму регистрации!" BackColor="#6699FF" Width="375px" style="margin-left: 0px" ForeColor="#6699FF" Height="27px"></asp:Label>
    
    </div>
        <div style="margin-left: 100px; width: 202px;" aria-disabled="False">
      
            <br />
        Введите логин<br />
        <asp:TextBox ID="Login" runat="server"  ></asp:TextBox>
        <br />
        <br />
        Введите&nbsp; пароль<br />
        <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        <br />
        <br />
        Введите имя<br />
        <asp:TextBox ID="FirstName" runat="server" ></asp:TextBox>
        <br />
        <br />
        Введите фамилию<br />
        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        <br />
        <br />
        Введите почту<br />
        <asp:TextBox ID="Mail" runat="server"></asp:TextBox>
        <br />
        <br />
        Введите телефон<br />
        <asp:TextBox ID="Tel" runat="server" ></asp:TextBox>
        
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Зарегистрироваться" />
        <br />
        <br />
    
       


          
        </div>
        <p>
            <asp:TextBox ID="UserList" runat="server" Height="173px" Width="1197px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
