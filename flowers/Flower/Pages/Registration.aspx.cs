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
        string connectionString = @"Data Source=DELL-PC;Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        protected void Page_Load(object sender, EventArgs e)
        {

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
                    /*
                    string check_phone = "select id from Users where tel=" + Tel.Text;
                    string check_login = "select id from Users where login=" + Login.Text;
                    string check_mail = "select id from Users where mail=" + Mail.Text;
                    SqlCommand select = new SqlCommand(check_phone, connection);
                    string s_check_phone = select.ExecuteScalar().ToString();
                    select = new SqlCommand(check_login, connection);
                   string s_check_login = select.ExecuteScalar().ToString();
                    select = new SqlCommand(check_mail, connection);
                   string s_check_mail = select.ExecuteScalar().ToString();
                    bool c_mail = (s_check_mail == "");
                    bool c_login = (s_check_login == "");
                    bool c_phone = (s_check_phone == "");
                     * */
                    /*
                    if ((!(c_mail)) || !(c_login) || !(c_phone))
                    {
                        if (!(c_mail))
                        {
                         Mail.Text = "Такой E-mail уже существует";
                        }
                        if (!(c_login))
                        {
                            Login.Text = "Такой Логин уже существует";
                        }
                        if (!(c_phone))
                        {
                            Tel.Text = "Такой номер уже существует";
                        }
                    }
                    else
                    {
                     * */
                        string count = "select count(*)from Users";
                        SqlCommand select = new SqlCommand(count, connection);
                        id = select.ExecuteScalar().ToString();

                        string insert_users = "INSERT INTO Users VALUES (" + id + ",'"
                        + Login.Text + "','" + Password.Text + "','" + FirstName.Text + "','" + LastName.Text +
                        "','" + Mail.Text + "','" + Tel.Text + "')";

                        SqlCommand insert = new SqlCommand(insert_users, connection);

                        if (Login.Text != "" && Password.Text != "" && FirstName.Text != "" && Mail.Text != ""&& Tel.Text!="")
                        {
                            insert.ExecuteNonQuery();
                            UserList.Text = "Успешная регистрация";
                            SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", Mail.Text, "Поздравляем с регистрацией", "Поздравляем с регистрацией");
                          //  SendMail("smtp.gmail.com", "mikopytin@gmail.com", "3150315VbIf", Mail.Text, "Поздравляем с регистрацией", "Поздравляем с регистрацией", "C:\\1.txt");
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
