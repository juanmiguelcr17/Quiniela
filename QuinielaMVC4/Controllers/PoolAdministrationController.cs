using QuinielaMVC4.Models;
using QuinielaMVC4.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuinielaMVC4.Controllers
{
    [Authorize (Roles="Administrador")]
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
            ViewData["id"] = id;
            return View(seasons);
        }

        public ActionResult SeasonList()
        {
            var seasons = db.Seasons.ToList();
            return View(seasons);
        }

        public ActionResult LeagueEdit(Guid id)
        {
            var league = db.Leagues.Find(id);
            return View(league);
        }

        [HttpPost]
        public ActionResult LeagueEdit(League league)
        {
            if(ModelState.IsValid)
            {
                db.Entry(league).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LeagueList");
            }
            return View(league);
        }

        public ActionResult LeagueDelete(Guid id)
        {
            League league = db.Leagues.Find(id);
            return View(league);
        }

        [HttpPost, ActionName("LeagueDelete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            League league = db.Leagues.Find(id);
            db.Leagues.Remove(league);
            db.SaveChanges();
            return RedirectToAction("LeagueList");
        }

        public ActionResult LeagueCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LeagueCreate(League league)
        {
            if (ModelState.IsValid)
            {
                league.LeagueId = Guid.NewGuid();
                db.Leagues.Add(league);
                db.SaveChanges();
                return RedirectToAction("LeagueList");
            }
            return View(league);
        }

        public ActionResult SeasonCreate(Guid id)
        {
            if (id != null)
                ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult SeasonCreate(Season season)
        {
            if (ModelState.IsValid)
            {
                season.SeasonId = Guid.NewGuid();
                db.Seasons.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(season);
        }

        public ActionResult SeasonDetails(Guid id)
        {
            var season = db.Seasons.Find(id);
            return View(season);
        }

        public ActionResult SeasonTeams(Guid seasonId)
        {
            var teamsId = db.SeasonTeams.Where(st => st.SeasonId == seasonId).ToList();
            List<Team> teams = new List<Team>();
            foreach (var team in teamsId)
            {
                teams.Add(db.Teams.Find(team.TeamId));
            }
            return View(teams);
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            fn.VerifyIfIsAdmin(this);
            base.EndExecute(asyncResult);
        }

    }
}
