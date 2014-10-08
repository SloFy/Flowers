<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Flower.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <br />
        <asp:Label ID="Privet" runat="server" Text="В данный момент имеются букеты :" style="margin-left: 442px" Width="254px"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Image ID="Flw1" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw2" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw3" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw4" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <br />
        <br />
        <asp:Label ID="LFlw1" runat="server" style="margin-left: 75px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw2" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw3" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw4" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Flw5" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw6" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw7" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw8" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <br />
        <br />
        <asp:Label ID="LFlw5" runat="server" style="margin-left: 75px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw6" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw7" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw8" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Image ID="Flw9" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw10" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw11" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <asp:Image ID="Flw12" runat="server" Height="220px" Width="220px" style="margin-left: 50px" Visible="False" ImageUrl="~/Images/Black.jpg" />
        <br />
        <br />
        <asp:Label ID="LFlw9" runat="server" style="margin-left: 75px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw10" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw11" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
        <asp:Label ID="LFlw12" runat="server" style="margin-left: 115px" Width="170px" Visible="False"></asp:Label>
    </form>
</body>
</html>
