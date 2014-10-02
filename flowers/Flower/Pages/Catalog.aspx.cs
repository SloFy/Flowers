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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection("Data Source=DELL-PC;Initial Catalog=Flower_DB;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    string photo;
                    string id;                                   
                    int count = 1;
                    while ((FindControl("Flw"+count))!= null)
                    {
                        count++;
                    }
                    for (int i = 1; i < count; i++)
                    {                    
                        string ph = "select Photo from Flowers where ID=" + i;
                        string text = "select Name from Flowers where ID=" + i;
                        SqlCommand select = new SqlCommand(ph, connection);
                        photo = select.ExecuteScalar().ToString();
                        select = new SqlCommand(text, connection);
                        if (photo != "")
                        {
                            text = select.ExecuteScalar().ToString() + " (Букет №" + i + ")";
                            id = "Flw" + i;
                            ((Image)FindControl(id)).ImageUrl = "~/Images/" + photo + ".jpg";
                            ((Image)FindControl(id)).Visible = ((Label)FindControl("L" + id)).Visible = true;
                            ((Label)FindControl("L" + id)).Text = text;
                        }              
                    }
                   
                }
                catch (Exception ex)
                {
                    
                }

            }
        }
    }
}