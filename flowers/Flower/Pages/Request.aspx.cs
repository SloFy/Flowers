using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Flower
{
    public partial class Request : System.Web.UI.Page
    {
        
        
        string connectionString = @"Data Source=" + Environment.MachineName + ";Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        protected void autoimp()
        {
            if ((Session["user_id"]) != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string command = "select first_name from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        SqlCommand select = new SqlCommand(command, connection);
                        Name.Text = select.ExecuteScalar().ToString();
                        select.CommandText = "select last_name from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        Last_Name.Text = " " + select.ExecuteScalar().ToString();
                        select.CommandText = "select phone from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        Sender_Phone.Text = select.ExecuteScalar().ToString();
                        AdressSource.SelectCommand = "select Street + ','+ Building +'-'+Korpus+'-'+Flat as Адрес from Adress_New where user_id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        AdressBox.Visible = Adress_label.Visible = true;



                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Receiver_Phone.Attributes.Add("onkeypress", "return numeralsOnly(event)");
            Sender_Phone.Attributes.Add("onkeypress", "return numeralsOnly(event)");
            ErrFlower.Visible = false;
            autoimp();
        }
        protected int Insert_Adress(string street, string building, string korpus, string flat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string user_id;
                    if (Session["user_id"] == null)
                    {
                        user_id = "-1";
                    }
                    else
                    {
                        user_id = Session["user_id"].ToString();
                    }
                    connection.Open();
                    string command = "select count(*) from adress_new";
                    SqlCommand select = new SqlCommand(command, connection);
                    int id = Convert.ToInt32(select.ExecuteScalar().ToString());

                    command = "Insert into Adress_new values(" + id + "," + user_id + ",'" + street + "','" + building + "','" + korpus + "','" + flat + "')";
                    SqlCommand insert = new SqlCommand(command, connection);
                    insert.ExecuteNonQuery();
                    return id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        protected void insert_request(string user_id, int flower_id,int count,int adress_id, DateTime date, string user_phone, string Receiver_Phone, string note, int pay, string Receiver_Name, string note2,string name,string last_name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    int status = 1;
                    string command = "select count(*)from Request";
                    SqlCommand select = new SqlCommand(command, connection);
                    int id = Convert.ToInt32(select.ExecuteScalar());
                    command = "select price from Flowers where id=" + flower_id;
                    select = new SqlCommand(command, connection);
                    int money = count*Convert.ToInt32(select.ExecuteScalar());
                    DateTime now = DateTime.Now;
                    if (user_id == null)
                    {
                        user_id = "-1";
                        note2 += "Заказчик: " + name + " " + last_name;
                    }
                        
                    
                    command = "INSERT INTO Request VALUES ("
                        + id + "," + user_id + "," + flower_id + "," + adress_id + ",'" + now + "','"
                        + date + "'," + user_phone + "," + Receiver_Phone + ",'" + note + "'," + money + "," + pay + "," + status + ",'" + Receiver_Name + "'," + count + ",'" + note2 + "')";
                    SqlCommand insert = new SqlCommand(command, connection);
                    insert.ExecuteNonQuery();

                    if (user_id != "-1")
                    {
                        select.CommandText = "select mail from users where id=" + Convert.ToInt32(user_id);
                        string Mail = select.ExecuteScalar().ToString();
                        string send = "Вы сделали заказ на сате достаки букетов Black Flower Power: Букет №"
                            + flower_id + ", Адрес: " + adress_id + ", доставить к " + date.ToString() + ", Телефон заказчика :" + user_phone + ", Телефон принимающего: " + Receiver_Phone + ", Сумма к оплате: " + money;
                        WebForm1.SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", Mail, "Ваш заказ ", send);
                    }


                }
                catch (Exception )
                {

                }
            }
        }
        protected string check_user(string Sender_Phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string check_cnt = "select id from Users WHERE Phone =" + Sender_Phone;
                    SqlCommand select_cnt = new SqlCommand(check_cnt, connection);
                    string user_id = select_cnt.ExecuteScalar().ToString();
                    if (select_cnt.ExecuteScalar().ToString() != "")
                        return user_id;
                    else
                        return "-1";
                }
                catch (Exception)
                {
                    return "-1";
                }
            }
        }
      
        protected bool check_date(DateTime date)
        {
            return (Convert.ToDateTime(Date_Time.Text).Hour >= DateTime.Now.Hour + 2.0f &&
                        Convert.ToDateTime(date).Date == DateTime.Now.Date ||
                        Convert.ToDateTime(date).Day <= DateTime.Now.Day + 10.0f &&
                        Convert.ToDateTime(date).Date != DateTime.Now.Date);
        }
        protected int check_address(string street, string building, string korpus, string flat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string user_id;
                    if (Session["user_id"] == null)
                    {
                        user_id = "-1";
                    }
                    else
                    {
                        user_id = Session["user_id"].ToString();
                    }


                    int id;
                    connection.Open();
                    string check = "select id from adress_new where user_id='" + user_id + "' AND street='" + street + "' AND building='" + building + "' AND flat='" + flat + "' AND korpus='" + korpus + "'";
                    SqlCommand select = new SqlCommand(check, connection);
                    if (select.ExecuteScalar() == null)
                        id = -1;
                    else
                        id = Convert.ToInt32(select.ExecuteScalar().ToString());
                    return id;
                }

                catch (Exception)
                {
                    return -2;
                }
            }
        }
        protected int get_adress_id(string street, string building, string korpus, string flat)
        {
            int adress_id = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    int check_adress_result = check_address(street, building, korpus, flat);
                    if (check_adress_result == -1)
                    {
                        adress_id = Insert_Adress(street, building, korpus, flat);
                    }
                    else
                    {
                        adress_id = check_adress_result;


                    }
                    return adress_id;


                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        int Check_Clicked()
        {
            for (int i = 0; i < PayList.Items.Count; i++)
            {

                if (PayList.Items[i].Selected)
                {

                    return i + 1;

                }

            }
            return 0;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            UserList.Text = "";
            int pay = Check_Clicked();
            if (FlowerCountList_1.SelectedValue=="0")
            {
                ErrFlower.Text = "Неправильное количество!";
                ErrFlower.Visible = true;
                FlowerCountList_1.BorderColor = Color.Red;
                
            }
            else
            {
                ErrFlower.Visible = false;
                FlowerCountList_1.BorderColor = Color.Black;
                int adress_id;

                string s;
                if (AdressBox.SelectedValue.ToString() != "" && Street.Text == "")
                {
                    s = AdressBox.SelectedValue.ToString();

                    Street.Text = s.Substring(0, s.IndexOf(','));

                    s = s.Remove(0, Street.Text.Length + 1);

                    Building.Text = s.Substring(0, s.IndexOf('-'));

                    s = s.Remove(0, Building.Text.Length + 1);

                    Korpus.Text = s.Substring(0, s.IndexOf('-'));

                    s = s.Remove(0, Korpus.Text.Length + 1);

                    Flat.Text = s;
                }
                adress_id = get_adress_id(Street.Text, Building.Text, Korpus.Text, Flat.Text);



                if (Name.Text != "" && Street.Text != "" && Building.Text != "" && Date_Time.Text != ""
                       && Sender_Phone.Text != "" && Receiver_Phone.Text != "" && Check_Clicked() != 0)
                {

                    if (check_date(Convert.ToDateTime(Date_Time.Text)))
                    {
                        int flower_id = getFlower_id(FlowerNameList_1.SelectedValue);
                        insert_request(check_user(Sender_Phone.Text),flower_id, Convert.ToInt32(FlowerCountList_1.SelectedValue), adress_id, Convert.ToDateTime(Date_Time.Text), Sender_Phone.Text, Receiver_Phone.Text, Note.Text, pay, Receiver_Name.Text,Note_2.Text,Name.Text,Last_Name.Text);
                        UserList.Visible = true;
                        UserList.Text = "Заказ оформлен успешно!";

                        if (pay == 1)
                        {
                            Response.Redirect("Pay.aspx");
                        }
                    }

                    else
                    {
                        UserList.Text = "Необходимо указывать дату, отличающуюся от текущей не менее чем на 2 часа и не более чем на 10 дней";
                        UserList.Visible = true;

                    }
                }
                else
                {
                    UserList.Visible = true;
                    UserList.Text = "Заполните все поля, помеченные знаком *";


                }


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder Cont = (ContentPlaceHolder)Master.FindControl("MainContent");
            int i;
                for ( i = 2; i <= 4; i++)
                {
                    if ((((DropDownList)(Cont.FindControl("FlowerNameList_" + i))).Visible) != true)
                        break;
                }
                string ListName_id="FlowerNameList_"+i;
                string ListCount_id="FlowerCountList_"+i;
                string Lcount_id = "Lcount_" + i;
                string Lsht_id = "Lsht_" + i;
                ((DropDownList)(Cont.FindControl(ListName_id))).Visible = ((DropDownList)(Cont.FindControl(ListCount_id))).Visible = ((Label)(Cont.FindControl(Lcount_id))).Visible = ((Label)(Cont.FindControl(Lsht_id))).Visible = true;
                


        }
        protected int getFlower_id(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {                  
                    connection.Open();
                    string select = "select id from Flowers where name='" + name + "'";
                    SqlCommand getid = new SqlCommand(select, connection);
                   return Convert.ToInt32(getid.ExecuteScalar().ToString());                 
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

    }

}