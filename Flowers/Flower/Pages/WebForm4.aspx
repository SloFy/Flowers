<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Flower.Pages.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <body>
    <form id="form1" runat="server">
  

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <asp:Menu ID="Menu1" runat="server" CssClass="dynamic"  Orientation="Horizontal" style="margin-left: 165px">
            <Items>
                <asp:MenuItem ImageUrl="~/Images/My.png" NavigateUrl="~/Pages/My.aspx"  ></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/Images/Request.png" NavigateUrl="~/Pages/Request.aspx"  ></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/Images/Catalog.png" NavigateUrl="~/Pages/Catalog.aspx" ></asp:MenuItem>
                <asp:MenuItem ImageUrl="~/Images/Registration.png" NavigateUrl="~/Pages/Registration.aspx" ></asp:MenuItem>
            </Items>
        </asp:Menu>

        </form>
</body>

    </asp:Content>
