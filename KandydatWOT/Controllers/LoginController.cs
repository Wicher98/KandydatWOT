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
        // GET
        public ActionResult Login_Page()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            string btnClick = Request["LoginBtn"];
            string userName;
            string password;
            if (btnClick == "Login")
            {
                userName = Request["username"];
                password = Request["password"];

                Session["userName"] = userName;
                Session["password"] = password;
                
            }
            else
            {
                Session["userName"] = "dupa";
            }
            
            DbConnector connector = new DbConnector();
            
                if (connector.try_login(Session["userName"].ToString() , Session["password"].ToString()))
                {
                    Console.Write("Mamy usera");
                }
                else
                {
                    Console.Write("Nie masz konta");
                }
            
            

            return View();
        }
    
   
    }
}