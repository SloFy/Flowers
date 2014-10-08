<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="Flower.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"
   

    > 
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
    <form id="form2" runat="server">
    <div>
    
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
    <div style="margin-left: 200px">
        Заполните форму заказа(поля, отмеченные знаком &quot;*&quot; заполняются обязательно):</div>
        <div style="margin-left: 100px; width: 979px; " aria-disabled="False">
      
            <br />
            Выберите тип букета*<asp:TextBox ID="Type" runat="server" Width="216px" style="margin-left:9px" TextMode="Number" BorderWidth="1px"  ></asp:TextBox>
            <asp:Label ID="ErrFlower" runat="server" Width="415px" style="margin-left:22px" Visible="False"></asp:Label>
        <br />
        <br />
            ФИО*<asp:TextBox ID="Name" runat="server" Width="216px" style="margin-left: 116px" BorderWidth="1px"  ></asp:TextBox>
        <br />
        <br />
            Адрес получения*<asp:TextBox ID="Address" runat="server" Width="216px" style="margin-left: 35px" BorderWidth="1px"  ></asp:TextBox>
            <br />
            <asp:Label ID="Adress_label" runat="server" Text="Выберите адрес" Visible="False"></asp:Label>
            <asp:ListBox ID="AdressBox" runat="server" DataSourceID="AdressSource" DataTextField="adress" DataValueField="adress" Rows="1" style="margin-left: 50px" Visible="False" Width="223px" ></asp:ListBox>
            <asp:SqlDataSource ID="AdressSource" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="select adress from adress where id=-1"></asp:SqlDataSource>
        <br />
            Дата и время доставки*<asp:TextBox ID="Date_Time" runat="server" Width="216px" style="margin-left: 0px" TextMode="DateTimeLocal" BorderWidth="1px"  ></asp:TextBox>
            <br />
            <br />
            Телефон заказчика*<asp:TextBox ID="Phone_zak" runat="server" Width="216px" style="margin-left: 28px" TextMode="Phone" MaxLength="11" BorderWidth="1px"   ></asp:TextBox>
            <br />
            <br />
            Телефон получателя*<asp:TextBox ID="Phone_pol" runat="server" Width="216px" style="margin-left: 17px" TextMode="Phone" MaxLength="11" BorderWidth="1px"  ></asp:TextBox>
            <br />
            <br />
            Подпись к букету<asp:TextBox ID="Note" runat="server" Width="216px" style="margin-left: 46px" BorderWidth="1px"  ></asp:TextBox>
        
            <br />
        
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Оформить заказ" Width="216px" />
        <br />
            <asp:Label ID="UserList" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
    
       


          
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
