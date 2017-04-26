using System.Web.Mvc;

namespace QuinielaMVC4.Controllers
{
    public class Functions : Controller
    {
        public void VerifyIfIsAdmin(Controller controller)
        {
            if (controller.User.Identity.IsAuthenticated)
            {
                controller.ViewData.Add("IsAdmin", controller.User.IsInRole("administrator"));
            }
        }
    }
}