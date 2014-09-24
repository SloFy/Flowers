<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Flower.WebForm1" %>

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
    <div style="margin-left: 120px">
    
        Введите логин<br />
        <asp:TextBox ID="Login" runat="server"></asp:TextBox>
        <br />
        <br />
        Введите&nbsp; пароль<br />
        <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        <br />
        <br />
        Введите имя<br />
        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
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
        <asp:TextBox ID="Tel" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Зарегистрироваться" />
        <br />
        <br />
    
        <a class="btn btn-primary btn-lg" href="http://www.asp.net">Learn more »</a></div>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="UserList" runat="server" Height="173px" Width="1197px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
