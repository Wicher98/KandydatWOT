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
    }
}