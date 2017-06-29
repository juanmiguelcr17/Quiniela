using System.Web.Mvc;

namespace QuinielaMVC4.Controllers
{
    public class ErrorController : Controller
    {
        [HandleError]
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }

    }
}
