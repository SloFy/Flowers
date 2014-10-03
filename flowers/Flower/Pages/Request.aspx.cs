using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

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
            autoimp();
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();
                    UserList.Text = "";
                    string id;
                    int money;
                    string User_ID = null;
                    string command = "select count(*)from Request";

                    SqlCommand select = new SqlCommand(command, connection);
                    id = select.ExecuteScalar().ToString();
                    command = "select price from Flowers where id=" + Type.Text;
                    select = new SqlCommand(command, connection);
                    money =Convert.ToInt32(select.ExecuteScalar());
                    
                    if (Type.Text != "" && Name.Text != "" && Address.Text != "" && Date_Time.Text != null
                         && Phone_zak.Text != "" && Phone_pol.Text != "")
                    {
                        string check_cnt = "select count(*) from Users WHERE Phone =" + Phone_zak.Text;
                        SqlCommand select_cnt = new SqlCommand(check_cnt, connection);

                        if (select_cnt.ExecuteScalar().ToString() == "1") //если такой пользователь есть
                        {
                            string check = "select ID from Users WHERE Phone =" + Phone_zak.Text;
                            SqlCommand select_user = new SqlCommand(check, connection);
                            User_ID = select_user.ExecuteScalar().ToString();

                            string insert_users_withid = "INSERT INTO Request VALUES ("
                    + id + "," + User_ID + "," + Convert.ToDouble(Type.Text) + ",'" + Address.Text + "','"
                    + Convert.ToDateTime(Date_Time.Text) + "'," + Phone_zak.Text + "," + Phone_pol.Text + ",'" + Note.Text + "'," + money + ")";

                            SqlCommand insert_withid = new SqlCommand(insert_users_withid, connection);
                            insert_withid.ExecuteNonQuery();

                        }
                        else //если пользователя нету
                        {
                            string insert_users = "INSERT INTO Request (ID,Flower_ID,Name,Adress,Date,User_Phone,Phone,Note,Money) VALUES ("
                    + id + "," + Convert.ToDouble(Type.Text) + ",'" + Address.Text + "','"
                    + Convert.ToDateTime(Date_Time.Text) + "'," + Phone_zak.Text + "," + Phone_pol.Text + ",'" + Note.Text + "'," + money + ")";

                            SqlCommand insert = new SqlCommand(insert_users, connection);
                            insert.ExecuteNonQuery();
                        }

                        UserList.Visible = true;
                        UserList.Text = "Заказ оформлен успешно!";
                    }
                    else
                    {
                  
                        UserList.Visible = true;
                        UserList.Text = "Заполните все поля, помеченные знаком *";
                    }
                    
                }
                catch (Exception ex)
                {
                    ////
                }

            }


        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            
        }
       
           
        
    }
}