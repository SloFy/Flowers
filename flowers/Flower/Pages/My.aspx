<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="Flower.Pages.My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div  style="margin-right: 1500px">    
    <div style="margin-left: 360px">
        <asp:Label ID="Welcome" runat="server" Text="Вход в личный кабинет" Width="185px" style="margin-left: 130px" Height="27px"></asp:Label>
    
    </div>
        
      
            <br />
            <asp:Label ID="lLogin" runat="server" style="margin-left: 15px" Text="Имя пользователя:" Width="140px"></asp:Label>
        <asp:TextBox  ID="Login" runat="server" style="margin-left: 15px" BorderWidth="1px"  ></asp:TextBox>
           <br />
        <br />
        <asp:Label ID="lPassword" runat="server" style="margin-left: 15px" Text="Пароль:" Width="55px"></asp:Label>
         <asp:TextBox ID="Password" runat="server"  TextMode="Password" style="margin-left: 15px" BorderWidth="1px"></asp:TextBox>
           <br />
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
       


          
        <asp:SqlDataSource ID="SAdress" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="select street as Улица ,building as Дом ,korpus as Корпус ,flat as Квартира from adress_new where user_id=-2"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SRequest" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="select a.Street + ','+ a.Building +'-'+a.Korpus+'-'+a.Flat as Адрес,r.reg_date as [Дата заказа], r.Receiver_Name as [Имя получателя],r.money as [К оплате],r.status as [Статус заказа] from Request_new r, Adress_New a where r.adress=a.id AND r.user_id=-1
"></asp:SqlDataSource>
        <asp:GridView ID="GridAdress" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SAdress" Visible="False">
            <Columns>
                <asp:BoundField DataField="Улица" HeaderText="Улица" SortExpression="Улица" />
                <asp:BoundField DataField="Дом" HeaderText="Дом" SortExpression="Дом" />
                <asp:BoundField DataField="Корпус" HeaderText="Корпус" SortExpression="Корпус" />
                <asp:BoundField DataField="Квартира" HeaderText="Квартира" SortExpression="Квартира" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="GridRequest" runat="server" AutoGenerateColumns="False" DataSourceID="SRequest" Visible="False">
            <Columns>
                <asp:BoundField DataField="Адрес" HeaderText="Адрес" ReadOnly="True" SortExpression="Адрес" />
                <asp:BoundField DataField="Дата заказа" HeaderText="Дата заказа" SortExpression="Дата заказа" />
                <asp:BoundField DataField="Имя получателя" HeaderText="Имя получателя" SortExpression="Имя получателя" />
                <asp:BoundField DataField="К оплате" HeaderText="К оплате" SortExpression="К оплате" />
                <asp:BoundField DataField="Статус заказа" HeaderText="Статус заказа" SortExpression="Статус заказа" />
            </Columns>
        </asp:GridView>
       </div>


        
</asp:Content>
