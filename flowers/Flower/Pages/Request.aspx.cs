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
        string connectionString = @"Data Source="+Environment.MachineName+";Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
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
                        command = "select last_name from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        select = new SqlCommand(command, connection);
                        Name.Text += " "+select.ExecuteScalar().ToString();
                        command = "select phone from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        select = new SqlCommand(command, connection);
                        Sender_Phone.Text = select.ExecuteScalar().ToString();
                        command = "select Adress from Adress where user_id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        AdressSource.SelectCommand = command;
                        AdressBox.Visible = true;
                        Adress_label.Visible = true;
                    }
                    catch (Exception ex)
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
     

        protected void Insert_Adress(int user_id,string adress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string command = "select count(*) from adress";
                    SqlCommand select = new SqlCommand(command, connection);
                    int id = Convert.ToInt32(select.ExecuteScalar().ToString());
                    command = "Insert into Adress values(" + id + "," + user_id + ",'" + adress+"')";
                    SqlCommand insert = new SqlCommand(command, connection);
                    insert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }
        }
        protected void insert_request(string user_id,int flower_id,string adress,DateTime date,string user_phone,string Receiver_Phone,string note)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                { 
                    connection.Open();
                    string command = "select count(*)from Request";
                    SqlCommand select = new SqlCommand(command, connection);
                    int id = Convert.ToInt32(select.ExecuteScalar());
                    command = "select price from Flowers where id=" + flower_id;
                    select = new SqlCommand(command, connection);
                    int money = Convert.ToInt32(select.ExecuteScalar());
                    DateTime now = DateTime.Now;
                    command = "INSERT INTO Request VALUES ("
                        + id + "," + user_id + "," + flower_id + ",'" + adress + "','" + now +"','"
                        + date + "'," + user_phone + "," + Receiver_Phone + ",'" + note + "'," + money + ")";
                    SqlCommand insert = new SqlCommand(command, connection);
                    insert.ExecuteNonQuery();
                   
                    if (user_id!="null")
                    {
                        select.CommandText = "select mail from users where id=" + Convert.ToInt32(user_id);
                        string Mail = select.ExecuteScalar().ToString();
                        string send = "Вы сделали заказ на сате достаки букетов Black Flower Power: Букет №"
                            + flower_id + ", Адрес: " + adress + ", доставить к " + date.ToString() + ", Телефон заказчика :" + user_phone + ", Телефон принимающего: " + Receiver_Phone + ", Сумма к оплате: " + money;
                         WebForm1.SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488",Mail, "Ваш заказ ", send);
                    }
                   
                  
                }
                catch (Exception ex)
                {
                   
                }
            }
        }
        protected string  check_user(string Sender_Phone)
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
                        return "null";
                }
                catch (Exception )
                {
                    return "null";
                }
            }
        }
        protected bool check_flower(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string check = "select count(*) from flowers WHERE id =" + id;
                    SqlCommand select = new SqlCommand(check, connection);
                     
                    if (select.ExecuteScalar().ToString() != "0")
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    return false;
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
        protected void Button1_Click(object sender, EventArgs e)
        {

            UserList.Text = "";
            if (!check_flower(Convert.ToInt32(Type.Text)))
            {
                ErrFlower.Text = "Выбран несуществующий тип букета";
                ErrFlower.Visible = true;                
                Type.BorderColor = Color.Red;
            }
            else
                
            {
                ErrFlower.Visible = false;
                Type.BorderColor = Color.Black;
                if ((Address.Text == "") && (AdressBox.SelectedValue != ""))
                {
                    Address.Text = AdressBox.SelectedValue;
                }
                else if (AdressBox.Visible == true)
                {
                    Insert_Adress(Convert.ToInt32(Session["user_id"]), Address.Text);
                }


                if (Type.Text != "" && Name.Text != "" && Address.Text != "" && Date_Time.Text != null
                     && Sender_Phone.Text != "" && Receiver_Phone.Text != "")
                {

                    if (check_date(Convert.ToDateTime(Date_Time.Text)))
                    {

                        insert_request(check_user(Sender_Phone.Text), Convert.ToInt32(Type.Text), Address.Text, Convert.ToDateTime(Date_Time.Text), Sender_Phone.Text, Receiver_Phone.Text, Note.Text);
                        UserList.Visible = true;
                        UserList.Text = "Заказ оформлен успешно!";
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

        }                  
        
    }
