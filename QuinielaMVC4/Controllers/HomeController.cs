using System.Web.Mvc;

namespace QuinielaMVC4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData.Add("IsAdmin", User.IsInRole("Administrador"));
            }
            return View();
        }

    }
}
