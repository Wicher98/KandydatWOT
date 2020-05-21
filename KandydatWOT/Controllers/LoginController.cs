using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Mvc;
using KandydatWOT.Models;

namespace KandydatWOT.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        
        // GET
        public ActionResult Login_Page()
        {
            return View();
        }
        
        void connectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dwot.database.windows.net";
            builder.UserID = "patryk";
            builder.Password = "C3AIo*8s?tUq?d#*as8g";
            builder.InitialCatalog = "Kandydaci";

            con.ConnectionString = builder.ToString();
        }
        
        public ActionResult Dashboard(Account acc)
        {
            acc.Email = Request["username"];
            acc.Password = Request["password"];
            
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from uzytkownicy where email="+"'"+acc.Email+"' and haslo='"+acc.Password+"'"; 
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                Session["userName"] = acc.Email;
                con.Close();
                return View("Dashboard");
            }
            else
            {
                Session["userName"] = "Nie ma usera";
                con.Close();
                return View("Login_Failed");

            }
           
        }
    
   
    }
}