<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Flower.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
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
    
    </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="UserList" runat="server" Height="173px" Width="1197px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
