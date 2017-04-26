using QuinielaMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuinielaMVC4.Controllers
{
    public class PoolAdministrationController : Controller
    {
        QuinielaEntities db = new QuinielaEntities();
        Functions fn = new Functions();
        //
        // GET: /PoolAdministration/

        public ActionResult Index()
        {
            //fn.VerifyIfIsAdmin(this);
            return View();
        }

        public ActionResult LeagueList()
        {
            //fn.VerifyIfIsAdmin(this);
            var leagues = db.Leagues.ToList();
            return View(leagues);
        }

        public ActionResult LeagueDetails(Guid id)
        {
            
            var seasons = db.Seasons.Where(s => s.LeagueId == id).ToList();
            
            return View(seasons);
        }
        protected override void EndExecute(IAsyncResult asyncResult)
        {
            fn.VerifyIfIsAdmin(this);
            base.EndExecute(asyncResult);
        }

    }
}
