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
                    string count = "select count(*)from Users";
                    SqlCommand select = new SqlCommand(count, connection);
                    id = select.ExecuteScalar().ToString();                   

                    string strSQL = "INSERT INTO Users VALUES ("+ id + ",'" 
                        + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text +
                        "','" + TextBox5.Text + "'," + TextBox6.Text + ")";

                
                    SqlCommand command = new SqlCommand(strSQL, connection);
                    command.ExecuteNonQuery();
                  
                }
                catch (Exception ex)
                {
                   
                }
            }
        }                     
    }
}