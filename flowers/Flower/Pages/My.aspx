<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="Flower.Pages.My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            
    <div style="margin-left: 360px">
        <asp:Label ID="Welcome" runat="server" Text="Вход в личный кабинет" Width="185px" style="margin-left: 130px" Height="27px"></asp:Label>
    
    </div>
        
      
            <br />
            <asp:Label ID="lLogin" runat="server" style="margin-left: 15px" Text="Имя пользователя:" Width="140px"></asp:Label>
        <asp:TextBox  ID="Login" runat="server" style="margin-left: 0px" BorderWidth="1px"  ></asp:TextBox>
        <br />
        <asp:Label ID="lPassword" runat="server" style="margin-left: 94px" Text="Пароль:" Width="55px"></asp:Label>
         <asp:TextBox ID="Password" runat="server"  TextMode="Password" style="margin-left: 6px" BorderWidth="1px"></asp:TextBox>
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
       


        
</asp:Content>
