﻿using System;
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
                    UserList.Text = ""; 
                    string id;
                    string cnt;
                    string count = "select count(*)from Users";
                    SqlCommand select = new SqlCommand(count, connection);
                    id = select.ExecuteScalar().ToString();
                    double tel;
                        string insert_users = "INSERT INTO Users VALUES ("+ id + ",'" 
                        + Login.Text + "','" + Password.Text + "','" + FirstName.Text + "','" + LastName.Text +
                        "','" + Mail.Text + "','" + Tel.Text + "')";


                    SqlCommand insert = new SqlCommand(insert_users, connection);
                 //   insert.ExecuteNonQuery();
                  //  UserList.Text = "Успешная регистрация";


                    if (Login.Text != "" && Password.Text != "" && FirstName.Text != "" && Mail.Text != "")
                    {
                        
                        insert.ExecuteNonQuery();
                        UserList.Text = "Успешная регистрация";
                    }
                    else
                    {
                        UserList.Text = "провал"; 
                    }                
                        //  cnt = select.ExecuteScalar().ToString();
                  //if (cnt==id)
                  //    UserList.Text="Успешная регистрация";
                  //  else
                  //    UserList.Text="провал";
                }
                catch (Exception ex)
                {
                   ////
                }
            
            }
        }                     
    }
    
}