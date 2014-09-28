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
                    string count = "select count(*)from Request";

                    SqlCommand select = new SqlCommand(count, connection);
                    id = select.ExecuteScalar().ToString();

                    
                    string insert_users = "INSERT INTO Request VALUES (" + id + ","
                    + FIO.Text + "," + Type.Text  + ",'" + Address.Text + "','" + Data.Text + "','" 
                     + Time.Text + "'," + TelZak.Text + "," + TelPol.Text + ",'" + Note.Text+ "')";


                    SqlCommand insert = new SqlCommand(insert_users, connection);


                    if (Type.Text != "" && FIO.Text != "" && Address.Text != "" && Data.Text != "" 
                        && Time.Text != "" && TelZak.Text != "" && TelPol.Text != "")
                    {

                        insert.ExecuteNonQuery();
                        UserList.Text = "Заказ оформлен успешно!";
                    }
                    else
                    {
                        UserList.Text = "Заполните все поля, помеченные знаком *";
                    }
                    
                }
                catch (Exception ex)
                {
                    ////
                }

            }


        }
    }
}