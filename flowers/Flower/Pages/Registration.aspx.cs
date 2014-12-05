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
    public partial class Registration : System.Web.UI.Page
    {
        string connectionString = @"Data Source=" + Environment.MachineName + ";Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
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
        protected void Insert_user(string login, string pass, string first_name, string last_name, string mail, string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string count = "select count(*)from Users";
                    SqlCommand select = new SqlCommand(count, connection);
                    int id = Convert.ToInt32(select.ExecuteScalar());
                    string cripted_pass = Flower.CS.RC4.Encript_string(pass, "Key");
                    string insert_user = "INSERT INTO Users VALUES (" + id + ",'"
                      + login + "','" + cripted_pass + "','" + first_name + "','" + last_name +
                      "','" + mail + "','" + phone + "')";
                    SqlCommand insert = new SqlCommand(insert_user, connection);
                    insert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                this.Session["CaptchaImageText"] = Flower.Request.GenerateRandomCode();
            Login_error.Visible = false;
            Phone_error.Visible = false;
            Mail_error.Visible = false;
            Add_Attributes();

        }
        protected bool check_input(string login, string mail, string phone)
        {
            if (login == "1")
            {
                Login_error.Visible = true;
                Login_error.Text = "Введенный логин уже занят другим пользователем";
                UserList.Text = "Провал";
                Login.BorderColor = Color.Red;
                return false;
            }

            else if (phone == "1")
            {
                Phone_error.Visible = true;
                Phone_error.Text = "Пользователь с таким телефоном уже зарегистрирован";
                UserList.Text = "Провал";
                Phone.BorderColor = Color.Red;
                return false;
            }

            else if (mail == "1")
            {
                Mail_error.Visible = true;
                Mail_error.Text = "Пользователь с такой почтой уже зарегистрирован";
                UserList.Text = "Провал";
                Mail.BorderColor = Color.Red;
                return false;
            }
            else if (Password.Text != Password2.Text)
            {
                Pass_error1.Visible = Pass_error2.Visible = true;
                Pass_error2.Text = Pass_error1.Text = "Несовпадение паролей";
                UserList.Text = "Провал";
                Password.BorderColor = Password2.BorderColor = Color.Red;
                return false;
            }
            else
                return true;
        }
        private void default_color()
        {
          Person.ForeColor=CodeNumberTextBox.BorderColor=  Login.BorderColor = Mail.BorderColor = Password.BorderColor = Password2.BorderColor = Phone.BorderColor = Color.Black;
        }
        private bool check_text_boxes()
        {
            bool person_data = Person.Checked;
            bool captcha = check_captcha();
            bool output = (Login.Text != "" && Password.Text != "" && FirstName.Text != "" && Mail.Text != "" && Phone.Text != "" && Password2.Text != "");
            if (output)
                return output;

            if (Login.Text.Trim() == "") Login.BorderColor = Color.Red;
            if (Password.Text.Trim() == "") Password.BorderColor = Color.Red;
            if (FirstName.Text.Trim() == "") FirstName.BorderColor = Color.Red;
            if (Mail.Text.Trim() == "") Mail.BorderColor = Color.Red;
            if (Phone.Text.Trim() == "") Phone.BorderColor = Color.Red;
            if (Password2.Text.Trim() == "") Password2.BorderColor = Color.Red;
            if (!person_data) Person.ForeColor = Color.Red;
            UserList.Text = "Заполните все поля, помеченные знаком *";
            if (!captcha)
            {
                MessageLabel.Text = "Неправильный код с картинки";
                CodeNumberTextBox.BorderColor = Color.Red;
            }
            return output;
        }
        public bool check_captcha()
        {
            if (this.CodeNumberTextBox.Text == this.Session["CaptchaImageText"].ToString())
                return true;
            else
                return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
             default_color();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (check_text_boxes())
                    {
                    connection.Open();
                    UserList.Text = "";
                    string new_login = "";
                    string new_Phone = "";
                    string new_mail = "";
                    //Проверка на ввод
                    
                    string login_cnt = "select count(*) from Users WHERE Login = '" + Login.Text + "'";
                    string Phone_cnt = "select count(*) from Users WHERE Phone = " + Phone.Text ;
                    string mail_cnt = "select count(*) from Users WHERE Mail = '" + Mail.Text + "'";


                    SqlCommand select_login = new SqlCommand(login_cnt, connection);
                    new_login = select_login.ExecuteScalar().ToString();

                    SqlCommand select_Phone = new SqlCommand(Phone_cnt, connection);
                    new_Phone = select_Phone.ExecuteScalar().ToString();

                    SqlCommand select_mail = new SqlCommand(mail_cnt, connection);
                    new_mail = select_mail.ExecuteScalar().ToString();

                    
                        if (check_input(new_login, new_mail, new_Phone) == true)
                        {
                            Login_error.Visible = Phone_error.Visible = Pass_error1.Visible = Pass_error2.Visible = Mail_error.Visible = false;
                            Insert_user(Login.Text, Password.Text, FirstName.Text, LastName.Text, Mail.Text, Phone.Text);
                            UserList.Text = "Успешная регистрация";
                            string send = FirstName.Text + ", Вы зарегистрировались на сате достаки букетов Black Flower Power Со следющими личными данными: Логин: "
                            + Login.Text + " , Пароль: " + Password.Text + " , Имя: " + FirstName.Text + " , Фамилия: " + LastName.Text +
                            " , Почта: " + Mail.Text + " , Телефон: " + Phone.Text;
                            SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", Mail.Text, "Поздравляем с регистрацией! ", send);

                        }
                        else
                        {

                            UserList.Text = "Провал";
                        }


                    }
                    

                }

                catch (Exception)
                {
                }

            }
        }

        protected void Login_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string login_cnt = "select count(*) from Users WHERE Login = '" + Login.Text + "'";
                    SqlCommand select_login = new SqlCommand(login_cnt, connection);
                    string new_login = select_login.ExecuteScalar().ToString();
                    if (new_login == Login.Text.ToString())
                        Login.BorderColor = Color.Red;
                }
                catch
                {

                }
            }

        }
        protected void Add_Attributes()
        {
            string ev = "onkeypress";
            string num = "return numeralsOnly(event)";
            string sym = "return symbolsOnly(event)";
            Phone.Attributes.Add(ev, num);
            FirstName.Attributes.Add(ev, sym);
            LastName.Attributes.Add(ev, sym);


        }
    }
}
