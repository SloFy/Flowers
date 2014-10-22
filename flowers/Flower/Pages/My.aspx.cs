﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Data.SqlClient;

namespace Flower.Pages
{
    public partial class My : System.Web.UI.Page
    {
        string connectionString = @"Data Source=" + Environment.MachineName + ";Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        
              protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["user_id"]) != null)
            {
                
                Login.Visible = Password.Visible = Sign.Visible = lLogin.Visible = lPassword.Visible = false;
                Badress.Visible = Brequests.Visible = Exit.Visible = GridAdress.Visible = GridRequest.Visible = true;
                Welcome.Text = "Личный кабинет";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string password;
                    string command = "select pass from Users where login=" + "'" + Login.Text + "'";
                    SqlCommand select = new SqlCommand(command, connection);
                    password = select.ExecuteScalar().ToString();

                    if (password == (Password.Text.ToString()))
                    {
                        select = new SqlCommand("select id from Users where login="+"'"+Login.Text+"'", connection);
                        Session["user_id"] = select.ExecuteScalar().ToString();
                        Login.Visible = Password.Visible = Sign.Visible = lLogin.Visible = lPassword.Visible = false;
                        Badress.Visible = Brequests.Visible = Exit.Visible = GridAdress.Visible = GridRequest.Visible = true;
                        Welcome.Text = "Личный кабинет";
                        connection.Close();
                    }
              }
                catch (Exception )
                {                    
                }
            }
            

              
        }

        protected void Badress_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SAdress.SelectCommand = "select street as Улица ,building as Дом ,korpus as Корпус ,flat as Квартира from adress_new where user_id=" + Session["user_id"].ToString();
                    GridAdress.Visible = true;
                    connection.Close();
                }
                catch (Exception )
                {

                }

            }

        }
        protected void Exit_Click(object sender, EventArgs e)
        {
            Session["user_id"]=null;           
                Login.Visible = Password.Visible = Sign.Visible = lLogin.Visible = lPassword.Visible = true;
                Badress.Visible = Brequests.Visible = Exit.Visible = GridAdress.Visible=GridRequest.Visible=false;
                Welcome.Text = "Вход в личный кабинет";          
            
        }
        protected void Brequests_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SRequest.SelectCommand = "select a.Street + ','+ a.Building +'-'+a.Korpus+'-'+a.Flat as Адрес,r.reg_date as [Дата заказа],r.Receiver_Name as [Имя получателя],r.money as [К оплате],r.status as [Статус заказа] from Request_new r, Adress_New a where r.adress=a.id AND r.user_id=" + Session["user_id"].ToString();
                    GridRequest.Visible = true;
                    connection.Close();
                }
                catch (Exception )
                {

                }

            }
        }

        
    }
}