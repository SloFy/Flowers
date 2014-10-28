using System;
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
        public static string GetPass(int x)
        {
            string pass="";
            var r=new Random();
            while (pass.Length < x)
            {
                Char c = (char)r.Next(33, 125);
                if (Char.IsLetterOrDigit(c))
                    pass += c;
            }
            return pass;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["user_id"]) != null)
            {

                Back_Pass.Visible = Back_Pass.Visible = Login.Visible = Password.Visible = Sign.Visible = lLogin.Visible = lPassword.Visible = false;
                Badress.Visible = Brequests.Visible = Exit.Visible = GridAdress.Visible = GridRequest.Visible = Change_Pass.Visible = New_Pass.Visible = LNew_Pass.Visible = true;
                Welcome.Text = "Личный кабинет";
            }
        }

        protected void Sign_Click(object sender, EventArgs e)
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
                    //password = Flower.CS.RC4.Encript_string(password, "Key");
                    if (password== Flower.CS.RC4.Encript_string(Password.Text.ToString(), "Key"))
                    {
                        select = new SqlCommand("select id from Users where login="+"'"+Login.Text+"'", connection);
                        Session["user_id"] = select.ExecuteScalar().ToString();
                        Login.Visible = Password.Visible = Sign.Visible = lLogin.Visible = lPassword.Visible=Back_Pass.Visible = false;
                        Badress.Visible = Brequests.Visible = Exit.Visible = GridAdress.Visible = GridRequest.Visible = Change_Pass.Visible = New_Pass.Visible = LNew_Pass.Visible = true;
                        Welcome.Text = "Личный кабинет";
                        Back_Pass.Visible=false;
                        
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
            
            Back_Pass.Visible = Login.Visible = Password.Visible = Sign.Visible = lLogin.Visible = lPassword.Visible = true;
                Badress.Visible = Brequests.Visible = Exit.Visible = GridAdress.Visible = GridRequest.Visible = Change_Pass.Visible = New_Pass.Visible = LNew_Pass.Visible = false;
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
        protected void Back_Pass_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string newPass = GetPass(15);
                    string send = "Новый пароль: " + newPass+"     Рекомендуем поменять пароль при первой же возможности";
                    newPass = Flower.CS.RC4.Encript_string(newPass, "Key");
                  SqlCommand command=new SqlCommand("update users set pass='"+newPass+"' where login=" + "'" + Login.Text + "'",connection);
                 command.ExecuteNonQuery();
                
                   command.CommandText="select mail from users where login=" + "'" + Login.Text + "'";
                   string mail=command.ExecuteScalar().ToString();
                   Registration.SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488",mail , "Восстановление пароля BlackFlowerPower", send);
                    connection.Close();
                    

                }
                catch (Exception )
                {

                }

            }
        }
        protected void Change_Pass_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {                  
                    connection.Open();
                    SqlCommand command = new SqlCommand("update users set pass='" + Flower.CS.RC4.Encript_string(New_Pass.Text, "Key") + "' where id="+ Session["user_id"].ToString(), connection);
                    command.ExecuteNonQuery();
                   /// string send = "Новый пароль: " + New_Pass.Text;
                 //   command.CommandText = "select mail from users where id=" + Session["user_id"].ToString();
                   // string mail = command.ExecuteScalar().ToString();
                  //  Registration.SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", mail, "Смена пароля BlackFlowerPower", send);
                    connection.Close();
                }
                catch (Exception)
                {

                }

            }
        }
        
        

        
    }
}