<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="Flower.Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
   
 <script type="text/javascript" src="Scripts/Check.js"> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 200px">
        Заполните форму заказа(поля, отмеченные знаком &quot;*&quot; заполняются обязательно):
    </div>
    <div style="margin-left: 100px; width: 979px;" aria-disabled="False">

        <br />
        Выберите&nbsp; букеты*
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;в количестве
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Selected="True">0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
&nbsp;шт.<br />
        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name" Style="margin-left: 135px" >
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;в количестве
        <asp:DropDownList ID="DropDownList9" runat="server">
            <asp:ListItem Selected="True">0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
&nbsp;шт.<br />
        <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name" Style="margin-left: 135px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;в количестве
        <asp:DropDownList ID="DropDownList10" runat="server">
            <asp:ListItem Selected="True">0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
&nbsp;шт.<br />
        <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name" DataValueField="Name" Style="margin-left: 135px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;в количестве
        <asp:DropDownList ID="DropDownList11" runat="server">
            <asp:ListItem Selected="True">0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
&nbsp;шт.<br />
&nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="SELECT [Name] FROM [Flowers]"></asp:SqlDataSource>
        <br />
        <asp:TextBox ID="Type" runat="server" Width="250px" Style="margin-left: 41px" TextMode="Number" BorderWidth="1px"></asp:TextBox>
        <asp:Label ID="ErrFlower" runat="server" Width="415px" Style="margin-left: 22px" Visible="False"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        ФИО*<asp:TextBox ID="Name" runat="server" Width="250px" Style="margin-left: 122px" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Адрес получения*<asp:TextBox ID="Street" runat="server" Width="125px" Style="margin-left: 40px" BorderWidth="1px" ></asp:TextBox>
        <asp:TextBox ID="Building" runat="server" Width="30px" Style="margin-left: 5px" BorderWidth="1px"></asp:TextBox>
        <asp:TextBox ID="Korpus" runat="server" Width="30px" Style="margin-left: 5px" BorderWidth="1px"></asp:TextBox>
        <asp:TextBox ID="Flat" runat="server" Width="30px" Style="margin-left: 5px" BorderWidth="1px"></asp:TextBox>
        <br />
        <asp:Label ID="LStreet" runat="server" Text="Улица" Style="margin-left: 200px"></asp:Label>
        <asp:Label ID="LBuilding" runat="server" Text="Дом" Style="margin-left: 60px"></asp:Label>
        <asp:Label ID="LKorpus" runat="server" Text="Корпус" Style="margin-left: 5px"></asp:Label>
        <asp:Label ID="Lflat" runat="server" Text="Квартира" Style="margin-left: 5px"></asp:Label>
        <br />
        <asp:Label ID="Adress_label" runat="server" Text="Выберите адрес" Visible="False"></asp:Label>
        <asp:ListBox ID="AdressBox" runat="server" DataSourceID="AdressSource" DataTextField="Адрес" DataValueField="Адрес" Rows="1" Style="margin-left: 55px" Visible="False" Width="255px"></asp:ListBox>
        <asp:SqlDataSource ID="AdressSource" runat="server" ConnectionString="<%$ ConnectionStrings:Flower_DBConnectionString %>" SelectCommand="select Street + ','+ Building +'-'+Korpus+'-'+Flat as Адрес from Adress_New where id=-1"></asp:SqlDataSource>
        <br />
        Дата и время доставки*<asp:TextBox ID="Date_Time" runat="server" Width="250px" Style="margin-left: 0px" TextMode="DateTimeLocal" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Телефон заказчика*<asp:TextBox ID="Sender_Phone" runat="server" Width="250px" Style="margin-left: 28px" TextMode="Phone" MaxLength="11" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Телефон получателя*<asp:TextBox ID="Receiver_Phone" runat="server" Width="250px" Style="margin-left: 17px" TextMode="Phone" MaxLength="11" BorderWidth="1px"></asp:TextBox>
        <br />
        <br />
        Имя получателя <asp:TextBox ID="Receiver_Name" runat="server" Width="250px" Style="margin-left: 50px"  BorderWidth="1px" ></asp:TextBox>
        

                <br />
        <br />
        Подпись к букету<asp:TextBox ID="Note" runat="server" Width="250px" Style="margin-left: 46px" BorderWidth="1px"></asp:TextBox>

        <br />

        <br />
        Способ Оплаты* :
        <asp:RadioButtonList ID="PayList" runat="server">
            <asp:ListItem>Оплата по карте on-line</asp:ListItem>
            <asp:ListItem>Оплата наличными при получении</asp:ListItem>
            <asp:ListItem>Оплата по карте при получении</asp:ListItem>
        </asp:RadioButtonList>
        

        <br />
        <asp:Button ID="Button1" runat="server"  Text="Оформить заказ" Width="216px" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="UserList" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />





    </div>
   
</asp:Content>

