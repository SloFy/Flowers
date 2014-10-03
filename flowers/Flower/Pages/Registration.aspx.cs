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

namespace Flower
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString = @"Data Source=ALEX-PC;Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorBox1.Visible = false;
            ErrorBox2.Visible = false;
            ErrorBox3.Visible = false;

            Tel.Attributes.Add("onkeypress", "return numeralsOnly(event)");
        }
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

        protected void Button1_Click(object sender, EventArgs e)
        {        
                 
          using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    UserList.Text = "";
                    
                    string id;
                    string new_login="";
                    string new_tel="";
                    string new_mail="";
                    //Проверка на ввод

                    string login_cnt = "select count(*) from Users WHERE Login = '" + Login.Text + "'";
                    string tel_cnt = "select count(*) from Users WHERE Tel = " + Tel.Text;
                    string mail_cnt = "select count(*) from Users WHERE Mail = '" + Mail.Text + "'";

                     SqlCommand select_login = new SqlCommand(login_cnt, connection);
                     new_login = select_login.ExecuteScalar().ToString();
                     //Login.Text = select_login.ExecuteScalar().ToString();

                     SqlCommand select_tel = new SqlCommand(tel_cnt, connection);
                     new_tel = select_tel.ExecuteScalar().ToString();

                     SqlCommand select_mail = new SqlCommand(mail_cnt, connection);
                     new_mail = select_mail.ExecuteScalar().ToString();

                        string count = "select count(*)from Users";
                        SqlCommand select = new SqlCommand(count, connection);
                        id = select.ExecuteScalar().ToString();

                        string insert_users = "INSERT INTO Users VALUES (" + id + ",'"
                        + Login.Text + "','" + Password.Text + "','" + FirstName.Text + "','" + LastName.Text +
                        "','" + Mail.Text + "','" + Tel.Text + "')";

                        SqlCommand insert = new SqlCommand(insert_users, connection);

                        if (Login.Text != "" && Password.Text != "" && FirstName.Text != "" && Mail.Text != ""&& Tel.Text!="")
                        {
                           if(new_login=="0" && new_tel == "0" && new_mail == "0")
                           {
                                ErrorBox1.Visible = false;
                                ErrorBox2.Visible = false;
                                ErrorBox3.Visible = false;

                                insert.ExecuteNonQuery();
                                UserList.Text = "Успешная регистрация";
                                string send = "Логин: " + Login.Text + " , Пароль: " + Password.Text + " , Имя: " + FirstName.Text + " , Фамилия: " + LastName.Text +
                                " , Почта: " + Mail.Text + " , Телефон: " + Tel.Text;
                      ////      SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", Mail.Text, "Поздравляем с регистрацией", send);
                                   //  SendMail("smtp.gmail.com", "mikopytin@gmail.com", "3150315VbIf", Mail.Text, "Поздравляем с регистрацией", "Поздравляем с регистрацией", "C:\\1.txt");
                           }

                           if (new_login == "1")
                           {
                               ErrorBox1.Visible = true;
                               ErrorBox1.Text = "Введенный логин уже занят другим пользователем";
                               UserList.Text = "Провал";
                           }

                           if (new_tel == "1")
                           {
                               ErrorBox2.Visible = true;
                               ErrorBox2.Text = "Пользователь с таким телефоном уже зарегистрирован";
                               UserList.Text = "Провал";
                           }

                           if (new_mail == "1")
                           {
                               ErrorBox3.Visible = true;
                               ErrorBox3.Text = "Пользователь с такой почтой уже зарегистрирован";
                               UserList.Text = "Провал";
                           }


                        }
                        else
                        {
                            UserList.Text = "Провал";
                        }

                    }
               // }
                catch (Exception ex)
                {                    
                }
            
            }
        }

                       
    }
    
}
