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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DELL-PC;Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

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

                    string id;
                    string cnt;
                    string count = "select count(*)from Users";
                    SqlCommand select = new SqlCommand(count, connection);
                    id = select.ExecuteScalar().ToString(); 
                 Login.Text=null;
                    
                    string insert_users = "INSERT INTO Users VALUES ("+ id + ",'" 
                        + Login.Text + "','" + Password.Text + "','" + FirstName.Text + "','" + LastName.Text +
                        "','" + Mail.Text + "'," + Tel.Text + ")";


                    SqlCommand insert = new SqlCommand(insert_users, connection);
                    insert.ExecuteNonQuery();
                 //   string show="select*from users";
                   // SqlCommand show_users = new SqlCommand(show, connection);
                   // UserList.Text = show_users.ExecuteReader().ToString();
                    cnt = id = select.ExecuteScalar().ToString();
                  if (cnt==id)
                      UserList.Text="Успешная регистрация";
                    else
                      UserList.Text="провал";
                }
                catch (Exception ex)
                {
                   
                }
            }
        }                     
    }
}