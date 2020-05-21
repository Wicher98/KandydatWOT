using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Mvc;

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
            if (btnClick == "Login")
            {
                string userName = Request["username"];
                string password = Request["password"];

                Session["userName"] = userName;
                Session["password"] = password;
                
            }
            else
            {
                Session["userName"] = "dupa";
            }
            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "dwot.database.windows.net"; 
            builder.UserID = "patryk";            
            builder.Password = "C3AIo*8s?tUq?d#*as8g";     
            builder.InitialCatalog = "kandydaci";
            
            try 
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * from Kandydaci.dbo.Uzytkownicy ");
                    /*sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    sb.Append("JOIN [SalesLT].[Product] p ");
                    sb.Append("ON pc.productcategoryid = p.productcategoryid;");*/
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString() + "blad sql");
            }
            Console.ReadLine();

            return View();
        }
    
   
    }
}