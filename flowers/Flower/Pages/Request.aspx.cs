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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DELL-PC;Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
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
                        Phone_zak.Text = select.ExecuteScalar().ToString();
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

            Phone_pol.Attributes.Add("onkeypress", "return numeralsOnly(event)");
            Phone_zak.Attributes.Add("onkeypress", "return numeralsOnly(event)");
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
        protected void insert_request(string user_id,int flower_id,string adress,DateTime date,string user_phone,string phone,string note)
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
                   
                    command = "INSERT INTO Request VALUES ("
                        + id + "," + user_id + "," + flower_id + ",'" + adress + "','"
                        + date + "'," + user_phone + "," + phone + ",'" + note + "'," + money + ")";
                    SqlCommand insert = new SqlCommand(command, connection);
                    insert.ExecuteNonQuery();
                  
                }
                catch (Exception ex)
                {
                   
                }
            }
        }
        protected string  check_user(string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string check_cnt = "select id from Users WHERE Phone =" + phone;
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
                     && Phone_zak.Text != "" && Phone_pol.Text != "")
                {

                    if (Convert.ToDateTime(Date_Time.Text).Hour >= DateTime.Now.Hour + 2.0f &&
                        Convert.ToDateTime(Date_Time.Text).Date == DateTime.Now.Date ||
                        Convert.ToDateTime(Date_Time.Text).Day <= DateTime.Now.Day + 10.0f &&
                        Convert.ToDateTime(Date_Time.Text).Date != DateTime.Now.Date)
                    {

                        insert_request(check_user(Phone_zak.Text), Convert.ToInt32(Type.Text), Address.Text, Convert.ToDateTime(Date_Time.Text), Phone_zak.Text, Phone_pol.Text, Note.Text);
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
