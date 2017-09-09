using QuinielaMVC4.Models;
using QuinielaMVC4.Models.Entities;
using QuinielaMVC4.Parsers;
using QuinielaMVC4.ViewModels;
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
        
        protected override void EndExecute(IAsyncResult asyncResult)
        {
            fn.VerifyIfIsAdmin(this);
            base.EndExecute(asyncResult);
        }

        public ActionResult Index()
        {
            //fn.VerifyIfIsAdmin(this);
            return View();
        }
        
        #region Ligas
        public ActionResult LeagueList()
        {
            var leagues = db.Leagues.ToList();
            return View(leagues);
        }

        public ActionResult LeagueDetails(Guid id)
        {
            var seasons = db.Seasons.Where(s => s.LeagueId == id).ToList();
            ViewData["id"] = id;
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
            if (ModelState.IsValid)
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

        [HttpPost, ActionName("LeagueDelete")]
        public ActionResult LeagueDeleteConfirmed(Guid id)
        {
            League league = db.Leagues.Find(id);
            db.Leagues.Remove(league);
            db.SaveChanges();
            return RedirectToAction("LeagueList");
        }
        #endregion

        #region Temporadas
        public ActionResult SeasonList()
        {
            var seasons = db.Seasons.ToList();
            return View(seasons);
        }

        public ActionResult SeasonCreate(Guid id)
        {
            if (id != Guid.Empty)
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
            ViewData["seasonId"] = seasonId;
            return View(teams);
        }

        [HttpPost, ActionName("AddToSeason")]
        public ActionResult SeasonAddTeam(Guid teamId, Guid seasonId)
        {
            try
            {
                var res = db.SeasonTeams.Where(a => a.SeasonId == seasonId).Where(b => b.TeamId == teamId).ToList();

                int count = res.Count();
                if (count > 0)
                {
                    return Json(new { data = new { MessageType = 2, Message = "El equipo ya está en esta temporada" } }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    SeasonTeams st = new SeasonTeams();
                    st.SeasonId = seasonId;
                    st.TeamId = teamId;
                    db.SeasonTeams.Add(st);
                    db.SaveChanges();
                    return Json(new { data = new { MessageType = 1, Message = "Se añadió el equipo" } }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = new { MessageType = 3, Message = "Algo salió mal: " + ex.Message } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost, ActionName("RemoveFromSeason")]
        public ActionResult SeasonDeleteTeam(Guid teamId, Guid seasonId)
        {
            try
            {
                var team = db.SeasonTeams.Where(s => s.SeasonId == seasonId).Where(t => t.TeamId == teamId);
                int cont = team.Count();
                if (cont > 0)
                {
                    db.SeasonTeams.Remove(team.First());
                    db.SaveChanges();
                    return Json(new { data = new { MessageType = 1, Message = "Se eliminó el equipo de la temporada" } }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { data = new { MessageType = 2, Message = "El equipo no pertenece a esta temporada" } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = new { MessageType = 3, Message = "Algo salió mal: " + ex.Message } }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Equipos
        [HttpGet]
        public ActionResult TeamCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TeamCreateNew()
        {
            Team team = new Team();
            try
            {
                if (TryUpdateModel(team,new[] { "ShortName", "Name", "Abbreviation", "Shield", "Stadium", "City", "State", "Country" }) && ModelState.IsValid)
                {
                    team.TeamId = Guid.NewGuid();
                    team.ShieldHeight = 40;
                    team.ShieldWidth = 40;
                    db.Teams.Add(team);
                    db.SaveChanges();
                    return Json(new { data = new { MessageType = 1, Message = "Se añadió el nuevo equipo" } }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = new { MessageType = 3, Message = "Algo salió mal: " + ex.Message } }, JsonRequestBehavior.AllowGet);
            }
            return View(team);
        }

        public ActionResult TeamDetails(Guid teamId)
        {
            Team team = db.Teams.Find(teamId);
            return View(team);
        }

        [HttpPost]
        public ActionResult TeamDetails(Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                RedirectToAction("TeamList");
            }
            return View(team);
        }

        [HttpPost, ActionName("TeamDelete")]
        public ActionResult TeamDeleteConfirmed (Guid id)
        {
            try
            {
                Team team = db.Teams.Find(id);
                var exists = db.SeasonTeams.Where(t => t.TeamId == team.TeamId);
                if (exists.Count() > 0)
                {
                    var season = db.Seasons.Where(s => s.SeasonId == exists.FirstOrDefault().SeasonId).First();
                    var league = db.Leagues.Where(l => l.LeagueId == season.LeagueId).First();
                    return Json(new { data = new { MessageType = 2, Message = "No se puede eliminar el equipo ya que está registrado en la siguiente temporada: " 
                        + season.Name + " " +
                        "de la liga: " + league.Name
                    } }, JsonRequestBehavior.AllowGet);
                }
                db.Entry(team).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Json(new { data = new { MessageType = 1, Message = "Se eliminó el equipo" } }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = new { MessageType = 3, Message = "Algo salió mal: " + ex.Message } }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult TeamList()
        {
            var teams = db.Teams.ToList();
            return View(teams);
        }

        [ChildActionOnly]
        public ActionResult TeamListPartial(Guid seasonId)
        {
            ViewData["seasonId"] = seasonId;
            var teams = db.Teams.ToList();
            return PartialView(teams);
        }
        #endregion

        #region Semanas

        [HttpGet]
        public ActionResult WeekList(Guid seasonId)
        {
            var season = db.Seasons.Find(seasonId);
            var weeks = db.Weeks.Where(w => w.SeasonId == seasonId).ToList();
            ViewBag.Season = season;
            return View(weeks);
        }

        [HttpGet]
        public ActionResult WeekCreate(Guid seasonId)
        {
            ViewBag.SeasonId = seasonId;
            return View();
        }

        [HttpPost]
        public ActionResult WeekCreate(Week week)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    week.WeekId = Guid.NewGuid();
                    db.Weeks.Add(week);
                    db.SaveChanges();
                    return Json(new { data = new { MessageType = 1, Message = "Se añadió la semana" } }, JsonRequestBehavior.AllowGet);
                }
                return View(week);
            }
            catch (Exception ex)
            {
                return Json(new { data = new { MessageType = 3, Message = "Algo salió mal: " + ex.Message } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult WeekEdit(Guid weekId)
        {
            var week = db.Weeks.Find(weekId);
            return View(week);
        }

        [HttpPost]
        public ActionResult WeekEdit(Week week)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(week).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { data = new { Location = "/PoolAdministration/WeekList?seasonId=" + week.SeasonId  } }, JsonRequestBehavior.AllowGet);
                }
                return View(week);
            }
            catch (Exception ex )
            {
                return Json(new { data = new { MessageType = 3, Message = "Algo salió mal: " + ex.Message } }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult WeekDetails(Guid weekId, Guid seasonId)
        {
            var gamesIds = db.WeekGames.Where(wg => wg.WeekId == weekId).ToList();
            List<WeekGamesVM> games = new List<WeekGamesVM>();
            foreach (var item in gamesIds)
            {
                games.Add(db.Games.Find(item.GameId).ToWeekGamesVM());
            }
            ViewBag.SeasonId = seasonId;
            ViewBag.WeekId = weekId;
            return View(games);
        }
        #endregion

        #region Partidos

        public ActionResult GameCreate(Guid weekId, Guid seasonId)
        {
            ViewBag.WeekId = weekId;
            ViewBag.SeasonId = seasonId;

            //Obtener los ids de los equipos registrados en la temporada para llenar el combo de locales y visitantes para dar de alta el partido
            var seasonTeams = db.SeasonTeams.Where(st => st.SeasonId == seasonId).ToList();
            List<Team> teams = new List<Team>();
            foreach (var item in seasonTeams)
            {
                teams.Add(db.Teams.Find(item.TeamId));
            }
            //Parsear teams a selectlistitems
            return View();
        }

        #endregion

    }
}
