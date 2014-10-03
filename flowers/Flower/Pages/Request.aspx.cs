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
        string connectionString = @"Data Source=ALEX-PC;Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        
        protected void Page_Load(object sender, EventArgs e)
        {

            TelPol.Attributes.Add("onkeypress", "return numeralsOnly(event)");
            TelZak.Attributes.Add("onkeypress", "return numeralsOnly(event)");
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

                    if (Type.Text != "" && FIO.Text != "" && Address.Text != "" && Date_Time.Text != null
                         && TelZak.Text != "" && TelPol.Text != "")
                    {
                        string check_cnt = "select count(*) from Users WHERE Tel =" + TelZak.Text;
                        SqlCommand select_cnt = new SqlCommand(check_cnt, connection);

                        if (select_cnt.ExecuteScalar().ToString() == "1") //если такой пользователь есть
                        {
                            string check = "select ID from Users WHERE Tel =" + TelZak.Text;
                            SqlCommand select_user = new SqlCommand(check, connection);
                            User_ID = select_user.ExecuteScalar().ToString();

                            string insert_users_withid = "INSERT INTO Request VALUES ("
                    + id + "," + User_ID + "," + Convert.ToDouble(Type.Text) + ",'" + Address.Text + "','"
                    + Convert.ToDateTime(Date_Time.Text) + "'," + TelZak.Text + "," + TelPol.Text + ",'" + Note.Text + "'," + money + ")";

                            SqlCommand insert_withid = new SqlCommand(insert_users_withid, connection);
                            insert_withid.ExecuteNonQuery();

                        }
                        else //если пользователя нету
                        {
                            string insert_users = "INSERT INTO Request (ID,Flower_ID,Adress,Date,User_tel,Tel,Note,Money) VALUES ("
                    + id + "," + Convert.ToDouble(Type.Text) + ",'" + Address.Text + "','"
                    + Convert.ToDateTime(Date_Time.Text) + "'," + TelZak.Text + "," + TelPol.Text + ",'" + Note.Text + "'," + money + ")";

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