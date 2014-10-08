<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Flower.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="/scripts/check.js" ></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">


   #form1 {
            width: 1135px;
            height: 1500px;
        }
  </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1135px">    
   
   <asp:ImageButton ID="ImageButton4" runat="server" Height="100px" ImageAlign="Top" ImageUrl="~/Images/logo (1).png" Width="200px" style="margin-left: 468px" AccessKey="p" PostBackUrl="~/Pages//Main.aspx" ToolTip="Перейти к заказу букетов" ValidateRequestMode="Disabled" />
        <br />
        <br />

        <asp:Menu ID="Menu1" runat="server" CssClass="dynamic"  Orientation="Horizontal" style="margin-left: 163px">
            <Items>
                <asp:MenuItem ImageUrl="~/Images/My.png" NavigateUrl="~/Pages/My.aspx"  ></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/Images/Request.png" NavigateUrl="~/Pages/Request.aspx"  ></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/Images/Catalog.png" NavigateUrl="~/Pages/Catalog.aspx" ></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/Images/Registration.png" NavigateUrl="~/Pages/Registration.aspx" ></asp:MenuItem>
            </Items>
        </asp:Menu>

        <br />

        <br />
    </div>
        
    <div style="margin-left: 360px">
        <asp:Label ID="First_label" runat="server" Text="Добро пожаловать на форму регистрации!" Width="375px" style="margin-left: 0px" Height="27px"></asp:Label>
    
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
            <asp:TextBox ID="UserList" runat="server" Height="16px" Width="366px"></asp:TextBox>
        </p>
    </form>
</body>
</html>
