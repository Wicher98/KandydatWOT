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
        
        public ActionResult Dashboard(Account acc)
        {
            acc.Email = Request["username"];
            acc.Password = Request["password"];
            
            var connector = new DbConnector();
            con.ConnectionString = connector.Connect_String();
            
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from Accounts where Email="+"'"+acc.Email+"' and Password='"+acc.Password+"'"; 
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                acc.Type = dr.GetInt32(6);
                acc.Degree = dr.GetString(1);
                acc.Name = dr.GetString(2);
                acc.Surname = dr.GetString(3);
                
                Session["userName"] = acc.Email;
                Session["Name"] = acc.Name;
                Session["Surname"] = acc.Surname;
                Session["Degree"] = acc.Degree;
                Session["Type"] = acc.Type;
                con.Close();
                switch (acc.Type)
                {
                    case 1:
                        return View("../Dashboard/Dashboard_Admin");
                    
                    case 2:
                        return View("../Dashboard/Dashboard_DWOT");
                    
                    case 3:
                        return View("../Dashboard/Dashboard_Kandydat");
                    
                    case 4:
                        return View("../Dashboard/Dashboard_Rekruter");
                    
                    case 5:
                        return View("../Dashboard/Dashboard_WKU");
                }
            }
            else
            {
                Session["userName"] = "Nie ma usera";
                con.Close();
                return View("Login_Failed");
            }

            return null;
        }
        
        public ActionResult Log_out()
        {
            Session.Abandon();
            Session.Clear();
            return View($"../Home/Index");
        }
    }
}