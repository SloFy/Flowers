using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Drawing;

namespace Flower
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DELL-PC;Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        public static void SendMail(string smtpServer, string from, string password, string mailto, string caption, string message, string attachFile = null)
        {
            try
            {
                
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(mailto));
                mail.Subject = caption;
                mail.Body = message;
                if (!string.IsNullOrEmpty(attachFile))
                    mail.Attachments.Add(new Attachment(attachFile));
                SmtpClient client = new SmtpClient();
                client.Host = smtpServer;
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(from.Split('@')[0], password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Login_error.Visible = false;
            Phone_error.Visible = false;
            Mail_error.Visible = false;

            Phone.Attributes.Add("onkeypress", "return numeralsOnly(event)");
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {        
                 
          using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    UserList.Text = "";                    
                    int id;
                    string new_login="";
                    string new_Phone="";
                    string new_mail="";
                    //Проверка на ввод

                    string login_cnt = "select count(*) from Users WHERE Login = '" + Login.Text + "'";
                    string Phone_cnt = "select count(*) from Users WHERE Phone = " + Phone.Text;
                    string mail_cnt = "select count(*) from Users WHERE Mail = '" + Mail.Text + "'";

                     SqlCommand select_login = new SqlCommand(login_cnt, connection);
                     new_login = select_login.ExecuteScalar().ToString();
                    

                     SqlCommand select_Phone = new SqlCommand(Phone_cnt, connection);
                     new_Phone = select_Phone.ExecuteScalar().ToString();

                     SqlCommand select_mail = new SqlCommand(mail_cnt, connection);
                     new_mail = select_mail.ExecuteScalar().ToString();

                        string count = "select count(*)from Users";
                        SqlCommand select = new SqlCommand(count, connection);
                        id = Convert.ToInt32(select.ExecuteScalar());
                    
                        string insert_users = "INSERT INTO Users VALUES (" + id + ",'"
                        + Login.Text + "','" + Password.Text + "','" + FirstName.Text + "','" + LastName.Text +
                        "','" + Mail.Text + "','" + Phone.Text + "')";


                        SqlCommand insert = new SqlCommand(insert_users, connection);

                        if (Login.Text != "" && Password.Text != "" && FirstName.Text != "" && Mail.Text != ""&& Phone.Text!="")
                        {
                           if(new_login=="0" && new_Phone == "0" && new_mail == "0")
                           {
                                Login_error.Visible = false;
                                Phone_error.Visible = false;
                                Mail_error.Visible = false;

                                insert.ExecuteNonQuery();
                                UserList.Text = "Успешная регистрация";
                                string send = FirstName.Text+", Вы зарегистрировались на сате достаки букетов Black Flower Power Со следющими личными данными: Логин: "
                                + Login.Text + " , Пароль: " + Password.Text + " , Имя: " + FirstName.Text + " , Фамилия: " + LastName.Text +
                                " , Почта: " + Mail.Text + " , Телефон: " + Phone.Text;
                           SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", Mail.Text, "Поздравляем с регистрацией! ", send);
                                  
                           }

                           if (new_login == "1")
                           {
                               Login_error.Visible = true;
                               Login_error.Text = "Введенный логин уже занят другим пользователем";
                               UserList.Text = "Провал";
                               Login.BorderColor = Color.Red;
                           }

                           if (new_Phone == "1")
                           {
                               Phone_error.Visible = true;
                               Phone_error.Text = "Пользователь с таким телефоном уже зарегистрирован";
                               UserList.Text = "Провал";
                               Phone.BorderColor = Color.Red;
                           }

                           if (new_mail == "1")
                           {
                               Mail_error.Visible = true;
                               Mail_error.Text = "Пользователь с такой почтой уже зарегистрирован";
                               UserList.Text = "Провал";
                               Mail.BorderColor = Color.Red;
                           }


                        }
                        else
                        {
                            UserList.Text = "Провал";
                        }

                    }
               
                catch (Exception ex)
                {                    
                }
            
            }
        }

                       
    }
    
}
