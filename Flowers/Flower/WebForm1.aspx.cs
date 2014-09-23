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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ALEX-PC;Initial Catalog=Flower_DB;Integrated Security=True";
                   
    
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    int id = 1;
                    connection.Open();
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