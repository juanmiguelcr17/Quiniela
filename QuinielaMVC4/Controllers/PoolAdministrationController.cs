using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuinielaMVC4.Controllers
{
    public class PoolAdministrationController : Controller
    {
        //
        // GET: /PoolAdministration/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData.Add("IsAdmin", User.IsInRole("administrator"));
            }
            return View();
        }

    }
}
