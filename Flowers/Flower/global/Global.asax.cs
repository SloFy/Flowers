using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.SqlClient;

namespace modelling
{
    public class Item
    {
        ClassToWorckWhithSQL ctwwSQL = new ClassToWorckWhithSQL();
        public int id;
        public string photo;
        public double price;
        public string name;
        public static bool operator ==(Item first,Item second)
        {
            if (first.id==second.id)
                return true;
            return false;
        }
        public static bool operator !=(Item first, Item second)
        {
            if (first.id == second.id)
                return false;
            return true;
        }
        public Item() { ;}
        public Item(int productID)
        {
            id = productID;
            ctwwSQL.TextCommand = "SELECT name, price, photo FROM Item WHERE id=" + id.ToString() + ";";
            ctwwSQL.Reader.Read();
            name = ctwwSQL.GetStringValueReader(0);
            price = Convert.ToDouble(ctwwSQL.GetStringValueReader(1));
            photo = ctwwSQL.GetStringValueReader(2);
        }
    }

    public class Global : System.Web.HttpApplication
    {
        
        void Application_Start(object sender, EventArgs e)
        {
            
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Код, выполняемый при завершении работы приложения

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Код, выполняемый при возникновении необрабатываемой ошибки

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске нового сеанса
            List<Item> itemsInBag = new List<Item>();
            Session["itemsInBag"] = itemsInBag;

        }

        void Session_End(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения. 
            // Примечание: Событие Session_End вызывается только в том случае, если для режима sessionstate
            // задано значение InProc в файле Web.config. Если для режима сеанса задано значение StateServer 
            // или SQLServer, событие не порождается.

        }

    }
}
