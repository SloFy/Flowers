using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;



namespace Flower.Pages
{
    public partial class Test : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.TextBox CodeNumberTextBox;
        protected System.Web.UI.WebControls.Button SubmitButton;
        protected System.Web.UI.WebControls.Label MessageLabel;
       
        
        string connectionString = @"Data Source=" + Environment.MachineName + ";Initial Catalog=Flower_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        protected void autoimp()
        {
            
            

            
            
            if ((Session["user_id"]) != null)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string command = "select first_name from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        SqlCommand select = new SqlCommand(command, connection);
                        Name.Text = select.ExecuteScalar().ToString();
                        select.CommandText = "select last_name from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        Name.Text += " " + select.ExecuteScalar().ToString();
                        select.CommandText = "select phone from Users where id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        Sender_Phone.Text = select.ExecuteScalar().ToString();
                        AdressSource.SelectCommand = "select Street + ','+ Building +'-'+Korpus+'-'+Flat as Адрес from Adress_New where user_id=" + "'" + ((Session["user_id"]).ToString()) + "'";
                        AdressBox.Visible = Adress_label.Visible = true;
                        if (Session["id_array"] != null)
                            SqlDataRequest_Flowers.SelectCommand = "select f.name as Букет,r_f.count as Количество from request_flowers r_f,flowers f where r_f.flower_id=f.id AND r_f.id in (" + Session["id_array"] + ")";


                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)

                // Create a random code and store it in the Session object.
                this.Session["CaptchaImageText"] = GenerateRandomCode();
            if (Session["id_array"]!=null)
            SqlDataRequest_Flowers.SelectCommand = "select f.name as Букет,r_f.count as Количество from request_flowers r_f,flowers f where r_f.flower_id=f.id AND r_f.id in (" + Session["id_array"] + ")";
            Receiver_Phone.Attributes.Add("onkeypress", "return numeralsOnly(event)");
            Sender_Phone.Attributes.Add("onkeypress", "return numeralsOnly(event)");
            ErrFlower.Enabled = false;
            autoimp();
        }
        protected int Insert_Adress(string street, string building, string korpus, string flat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string user_id;
                    if (Session["user_id"] == null)
                    {
                        user_id = "-1";
                    }
                    else
                    {
                        user_id = Session["user_id"].ToString();
                    }
                    connection.Open();
                    string command = "select count(*) from adress_new";
                    SqlCommand select = new SqlCommand(command, connection);
                    int id = Convert.ToInt32(select.ExecuteScalar().ToString());

                    command = "Insert into Adress_new values(" + id + "," + user_id + ",'" + street + "','" + building + "','" + korpus + "','" + flat + "')";
                    SqlCommand insert = new SqlCommand(command, connection);
                    insert.ExecuteNonQuery();
                    return id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        protected void insert_request(string user_id, string id_array,  int adress_id, DateTime date, string user_phone, string Receiver_Phone, string note, int pay, string Receiver_Name, string note2,string name,string last_name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    int status = 1;
                    string command = "select count(*)from Request";
                    SqlCommand select = new SqlCommand(command, connection);
                    int id = Convert.ToInt32(select.ExecuteScalar());
                    List<int> flower_request_list=new List<int>();  
                    List<int> money_array=new List<int>();
                     List<int> count_array=new List<int>();
                     string id_array_local = id_array;
                    while (id_array!="")
                    {
                        string add_id="";
                    if (id_array.IndexOf(",") != -1)
                    {
                        add_id = id_array.Substring(0, id_array.IndexOf(","));
                        flower_request_list.Add(Convert.ToInt32(add_id));
                        id_array = id_array.Remove(0, add_id.Length + 1);
                    }
                        
                    else
                    { 
                        add_id = id_array;
                        flower_request_list.Add(Convert.ToInt32(add_id));
                        id_array = id_array.Remove(0, add_id.Length);
                    }
                    }
                    SqlCommand update=new SqlCommand(command,connection);
                    update.CommandText = "update request_flowers set request_id=" + id + " where id in (" + id_array_local + ")";
                        update.ExecuteNonQuery();
                    int money=0;
                                        for (int i = 0; i < flower_request_list.Count;i++ )
                    {

                        select.CommandText = "select price from flowers where id=(select flower_id from request_flowers where id=" + flower_request_list[i]+")";
                        int a = Convert.ToInt32(select.ExecuteNonQuery());
                        select.CommandText = "select count from request_flowers where id=" + flower_request_list[i];
                        int b = Convert.ToInt32(select.ExecuteNonQuery());
                        money += a * b;
                    }
                 DateTime now = DateTime.Now;
                    if (user_id == null)
                    {
                        user_id = "-1";
                        note2 += "Заказчик: " + name + " " + last_name;
                    }
                    select.CommandText = "Select count(*) from request_new";
                    id = Convert.ToInt32(select.ExecuteScalar().ToString());

                    command = "INSERT INTO Request_New VALUES ("
                        + id + "," + user_id + ","+ adress_id + ",'" + now + "','"
                        + date + "'," + user_phone + "," + Receiver_Phone + ",'" + note + "'," + money + "," + pay + "," + status + ",'" + Receiver_Name + "','" + note2 + "')";
                    SqlCommand insert = new SqlCommand(command, connection);
                    insert.ExecuteNonQuery();
                    
                    if (user_id != "-1")
                    {
                        select.CommandText = "select mail from users where id=" + Convert.ToInt32(user_id);
                        string Mail = select.ExecuteScalar().ToString();
                        string send = "Вы сделали заказ на сате достаки букетов Black Flower Power: Букеты №"
                             + ", Адрес: " + adress_id + ", доставить к " + date.ToString() + ", Телефон заказчика :" + user_phone + ", Телефон принимающего: " + Receiver_Phone + ", Сумма к оплате: " + money;
                        WebForm1.SendMail("smtp.mail.ru", "black_flower_power@mail.ru", "black1488", Mail, "Ваш заказ ", send);
                    }


                }
                catch (Exception )
                {

                }
            }
        }
        protected int insert_requset_flowers(string name,int count)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string command = "select count(*) from request_flowers";
                    SqlCommand Sqlcomm = new SqlCommand(command, connection);
                    int id = Convert.ToInt32(Sqlcomm.ExecuteScalar().ToString());
                    int flower_id = getFlower_id(name);
                    Sqlcomm.CommandText="Insert into request_flowers(ID,flower_id,count) values(" + id + "," + flower_id + "," + count + ")";                    
                    Sqlcomm.ExecuteNonQuery();
                    return id;
                }
                catch (Exception)
                {
                    return -1;
                }
            }



        }

        protected string check_user(string Sender_Phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string check_cnt = "select id from Users WHERE Phone =" + Sender_Phone;
                    SqlCommand select_cnt = new SqlCommand(check_cnt, connection);
                    string user_id = select_cnt.ExecuteScalar().ToString();
                    if (select_cnt.ExecuteScalar().ToString() != "")
                        return user_id;
                    else
                        return "-1";
                }
                catch (Exception)
                {
                    return "-1";
                }
            }
        }      
        protected bool check_date(DateTime date)
        {
            return (Convert.ToDateTime(Date_Time.Text).Hour >= DateTime.Now.Hour + 2.0f &&
                        Convert.ToDateTime(date).Date == DateTime.Now.Date ||
                        Convert.ToDateTime(date).Day <= DateTime.Now.Day + 10.0f &&
                        Convert.ToDateTime(date).Date != DateTime.Now.Date);
        }
        protected int check_address(string street, string building, string korpus, string flat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string user_id;
                    if (Session["user_id"] == null)
                    {
                        user_id = "-1";
                    }
                    else
                    {
                        user_id = Session["user_id"].ToString();
                    }


                    int id;
                    connection.Open();
                    string check = "select id from adress_new where user_id='" + user_id + "' AND street='" + street + "' AND building='" + building + "' AND flat='" + flat + "' AND korpus='" + korpus + "'";
                    SqlCommand select = new SqlCommand(check, connection);
                    if (select.ExecuteScalar() == null)
                        id = -1;
                    else
                        id = Convert.ToInt32(select.ExecuteScalar().ToString());
                    return id;
                }

                catch (Exception)
                {
                    return -2;
                }
            }
        }
        int Check_Clicked()
        {
            for (int i = 0; i < PayList.Items.Count; i++)
            {

                if (PayList.Items[i].Selected)
                {

                    return i + 1;

                }

            }
            return 0;

        }
        public bool check_captcha()
        {
            if (this.CodeNumberTextBox.Text == this.Session["CaptchaImageText"].ToString())
                return true;
            else
                return false;
        }
        protected int get_adress_id(string street, string building, string korpus, string flat)
        {
            int adress_id = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    int check_adress_result = check_address(street, building, korpus, flat);
                    if (check_adress_result == -1)
                    {
                        adress_id = Insert_Adress(street, building, korpus, flat);
                    }
                    else
                    {
                        adress_id = check_adress_result;


                    }
                    return adress_id;


                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        protected int getFlower_id(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string select = "select id from Flowers where name='" + name + "'";
                    SqlCommand getid = new SqlCommand(select, connection);
                    return Convert.ToInt32(getid.ExecuteScalar().ToString());
                    connection.Close();

                }
                catch (Exception)
                {
                    return -1;
                }
                
            }
            
        }
     
        protected void Button1_Click(object sender, EventArgs e)
        {

            UserList.Text = "";
            MessageLabel.Text = "";
            CodeNumberTextBox.BorderColor = Color.Black;
            int pay = Check_Clicked();

                int adress_id;

                string s;
                if (AdressBox.SelectedValue.ToString() != "" && Street.Text == "")
                {
                    s = AdressBox.SelectedValue.ToString();
                    Street.Text = s.Substring(0, s.IndexOf(','));
                    s = s.Remove(0, Street.Text.Length + 1);
                    Building.Text = s.Substring(0, s.IndexOf('-'));
                    s = s.Remove(0, Building.Text.Length + 1);
                    Korpus.Text = s.Substring(0, s.IndexOf('-'));
                    s = s.Remove(0, Korpus.Text.Length + 1);
                    Flat.Text = s;
                }
                adress_id = get_adress_id(Street.Text, Building.Text, Korpus.Text, Flat.Text);
                if (!check_captcha())
                {
                    MessageLabel.Text = "Неправильный код с картинки";
                    CodeNumberTextBox.BorderColor = Color.Red;
                }

                if (Name.Text != "" && Street.Text != "" && Building.Text != "" && Date_Time.Text != ""
                       && Sender_Phone.Text != "" && Receiver_Phone.Text != "" && Check_Clicked() != 0 && check_captcha() && Session["id_array"]!=null)
                {
                    

                    if (check_date(Convert.ToDateTime(Date_Time.Text)))
                    {
                        int flower_id = getFlower_id(FlowerNameList_1.SelectedValue);
                        insert_request(check_user(Sender_Phone.Text), Session["id_array"].ToString(), adress_id, Convert.ToDateTime(Date_Time.Text), Sender_Phone.Text, Receiver_Phone.Text, Note.Text, pay, Receiver_Name.Text,Note_2.Text,Name.Text,Last_Name.Text);
                        UserList.Visible = true;
                        UserList.Text = "Заказ оформлен успешно!";
                        Session["id_array"] = null;
                        if (pay == 1)
                        {
                            Response.Redirect("Pay.aspx");
                        }
                    }

                    else
                    {
                        UserList.Text = "Необходимо указывать дату, отличающуюся от текущей не менее чем на 2 часа и не более чем на 10 дней";
                        UserList.Visible = true;

                    }
                }
                else if (Session["id_array"]==null)
                {
                    UserList.Visible = true;
                    UserList.Text = "Вы не выбрали цветы";
                }
                else
                {
                    UserList.Visible = true;
                    UserList.Text = "Заполните все поля, помеченные знаком *";


                }


            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if ((Convert.ToInt32(FlowerCountList_1.SelectedValue.ToString())) != 0)
            {
                ErrFlower.Enabled = false;
                ErrFlower.Visible = false;
                FlowerCountList_1.BorderColor = Color.Black;
                

                int request_flower_id = insert_requset_flowers(FlowerNameList_1.SelectedValue.ToString(), Convert.ToInt32(FlowerCountList_1.SelectedValue.ToString()));
                string id_array;
                if (Session["id_array"] != null)
                    id_array = (String)Session["id_array"];
                else
                    id_array = "";

                if (id_array == "")
                    id_array = request_flower_id.ToString();
                else
                    id_array += "," + request_flower_id.ToString();
                SqlDataRequest_Flowers.SelectCommand = "select f.name as Букет,r_f.count as Количество from request_flowers r_f,flowers f where r_f.flower_id=f.id AND r_f.id in (" + id_array + ")";
                Session["id_array"] = id_array;
            }
            else
            {
                ErrFlower.Text = "Неправильное количество!";
                ErrFlower.Enabled = true;
                ErrFlower.Visible = true;
                FlowerCountList_1.BorderColor = Color.Red;
            }
        }        
        
		

		// For generating random numbers.
		private Random random = new Random();
	/*
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!this.IsPostBack)

				// Create a random code and store it in the Session object.
				this.Session["CaptchaImageText"] = GenerateRandomCode();

			else
			{
				// On a postback, check the user input.
				if (this.CodeNumberTextBox.Text == this.Session["CaptchaImageText"].ToString())
				{
					// Display an informational message.
					this.MessageLabel.CssClass = "info";
					this.MessageLabel.Text = "Correct!";
				}
				else
				{
					// Display an error message.
					this.MessageLabel.CssClass = "error";
					this.MessageLabel.Text = "ERROR: Incorrect, try again.";

					// Clear the input and create a new random code.
					this.CodeNumberTextBox.Text = "";
					this.Session["CaptchaImageText"] = GenerateRandomCode();
				}
			}
		}
        */
		//
		// Returns a string of six random digits.
		//
		private string GenerateRandomCode()
		{
			string s = "";
			for (int i = 0; i < 6; i++)
				s = String.Concat(s, this.random.Next(10).ToString());
			return s;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



    }

}