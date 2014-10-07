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
    
    </div>
        
    <div style="margin-left: 360px">
        <asp:Label ID="Welcome" runat="server" Text="Вход в личный кабинет" BackColor="#6699FF" Width="185px" style="margin-left: 130px" ForeColor="#6699FF" Height="27px"></asp:Label>
    
    </div>
        
      
            <br />
            <asp:Label ID="lLogin" runat="server" style="margin-left: 15px" Text="Имя пользователя:" Width="130px"></asp:Label>
        <asp:TextBox  ID="Login" runat="server" style="margin-left: 0px" BorderWidth="1px"  ></asp:TextBox>
        <br />
        <asp:Label ID="lPassword" runat="server" style="margin-left: 87px" Text="Пароль:" Width="55px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="Password" runat="server"  TextMode="Password" style="margin-left: -70px" BorderWidth="1px"></asp:TextBox>
        <br />
        <asp:Button ID="Sign" runat="server"  Text="Войти"  Width="250px" OnClick="Button1_Click" />
            <br />
        <br />
        <asp:Button ID="Badress" runat="server"  Text="Вывести список адресов"  Width="250px" Visible="False" OnClick="Badress_Click" />
        <br />
        <br />
        <asp:Button ID="Brequests" runat="server"  Text="Вывести предыдщие заказы"  Width="250px" Visible="False" OnClick="Brequests_Click" />
        <br />
        <br />
        <asp:Button ID="Exit" runat="server"  Text="Выйти"  Width="250px" Visible="False" OnClick="Exit_Click" />
        <br />
        <br />
       


          
            <asp:SqlDataSource ID="SAdress" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="select adress from adress where id=-1"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SRequest" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="select * from request where id=-1"></asp:SqlDataSource>
        <asp:GridView ID="GridAdress" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SAdress" Visible="False">
            <Columns>
                <asp:BoundField DataField="adress" HeaderText="adress" SortExpression="adress" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridRequest" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SRequest" Visible="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="User_ID" HeaderText="User_ID" SortExpression="User_ID" />
                <asp:BoundField DataField="Flower_ID" HeaderText="Flower_ID" SortExpression="Flower_ID" />
                <asp:BoundField DataField="Adress" HeaderText="Adress" SortExpression="Adress" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                <asp:BoundField DataField="User_Phone" HeaderText="User_Phone" SortExpression="User_Phone" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note" />
                <asp:BoundField DataField="Money" HeaderText="Money" SortExpression="Money" />
            </Columns>
        </asp:GridView>
       


          
        </form>
</body>
</html>
