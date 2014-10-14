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

            using (SqlConnection connection = new SqlConnection("Data Source=" + Environment.MachineName + ";Initial Catalog=Flower_DB;Integrated Security=True"))
            {
                try
                {
                    connection.Open();
                    ContentPlaceHolder Cont = (ContentPlaceHolder)Master.FindControl("MainContent");  
                  
                    string select_flower_count = "select count(*) from flowers";
                    SqlCommand select = new SqlCommand(select_flower_count, connection);
                    int flower_count = Convert.ToInt32(select.ExecuteScalar().ToString());
                    Flw1.ToolTip = "Test";
                    for (int i = 1; i <= flower_count; i++)
                    {                    
                        string ph = "select Photo from Flowers where ID=" + i;
                        string text = "select Name from Flowers where ID=" + i;
                         select = new SqlCommand(ph, connection);
                         string photo = select.ExecuteScalar().ToString();
                         string Info = "select Info from Flowers where ID=" + i; ;
                         select = new SqlCommand(Info, connection);
                         Info = select.ExecuteScalar().ToString();
                         select = new SqlCommand(text, connection);
                        
                        if (photo != "")
                        {
                            text = select.ExecuteScalar().ToString() + " (Букет №" + i + ")";
                           string id  = "Flw" + i;
                           ((Image)(Cont.FindControl(id))).ImageUrl = "~/Images/" + photo + ".png";
                           ((Image)(Cont.FindControl(id))).Visible = ((Label)(Cont.FindControl("L"+id))).Visible = true;
                           ((Image)(Cont.FindControl(id))).ToolTip = Info; 
                             id = "LFlw" + i;                            
                           ((Label)(Cont.FindControl(id))).Text = text;                  
                            
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