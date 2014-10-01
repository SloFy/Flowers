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
                    
                    for (int i = 1; i < 5; i++)
                    {
                        string photo;
                        string ph = "select Photo from Flowers where ID=" + i;
                        string text = "select Name from Flowers where ID=" + i;
                        SqlCommand select = new SqlCommand(ph, connection);
                        photo = select.ExecuteScalar().ToString();
                        select = new SqlCommand(text, connection);
                        text = select.ExecuteScalar().ToString()+" (Букет №"+i+")";
                        if (i==1)
                        { 
                        Flw1.ImageUrl="~/Images/"+photo+".jpg";
                        Flw1.Visible = true;
                        LFlw1.Text = text;
                        LFlw1.Visible = true;
                        }
                        if (i == 2)
                        {
                            Flw2.ImageUrl = "~/Images/" + photo + ".jpg";
                            Flw2.Visible = true;
                            LFlw2.Text = text;
                            LFlw2.Visible = true;
                        }
                        if (i == 3)
                        {
                            Flw3.ImageUrl = "~/Images/" + photo + ".jpg";
                            Flw3.Visible = true;
                            LFlw3.Text = text;
                            LFlw3.Visible = true;
                        }
                        if (i == 4)
                        {
                            Flw4.ImageUrl = "~/Images/" + photo + ".jpg";
                            Flw4.Visible = true;
                            LFlw4.Text = text;
                            LFlw4.Visible = true;
                        }
                        
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