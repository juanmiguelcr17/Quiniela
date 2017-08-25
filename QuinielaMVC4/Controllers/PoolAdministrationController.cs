﻿using QuinielaMVC4.Models;
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
            ViewData["seasonId"] = seasonId;
            return View(teams);
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
                //Mostrar algun mensaje de actualización o redirigir?
            }
            return View(team);
        }

        [HttpPost, ActionName("TeamDelete")]
        public ActionResult TeamDeleteConfirmed (Guid id)
        {
            Team team = db.Teams.Find(id);
            //db.Teams.Remove(team);
            db.Entry(team).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            //Mostrar algun mensaje de actualización o redirigir?
            return RedirectToAction("");
        }

        public ActionResult TeamList()
        {
            var teams = db.Teams.ToList();
            return Json(teams);
        }

        [ChildActionOnly]
        public ActionResult TeamListPartial(Guid seasonId)
        {
            ViewData["seasonId"] = seasonId;
            var teams = db.Teams.ToList();
            return PartialView(teams);
        }
        
        [HttpPost, ActionName("AddToSeason")]
        public ActionResult SeasonAddTeam(Guid teamId, Guid seasonId)
        {
            try
            {
                var res = db.SeasonTeams.Where(a => a.SeasonId == seasonId).Where(b => b.TeamId == teamId).ToList();

                int count = res.Count();
                if(count > 0)
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

        [HttpPost]
        public ActionResult SeasonDeleteTeam(Guid teamId, Guid seasonId)
        {
            try
            {
                var team = db.SeasonTeams.Where(s => s.SeasonId == seasonId).Where(t => t.TeamId == teamId);
                int cont = team.Count();
                if(cont > 0)
                {
                    db.Entry(team).State = System.Data.Entity.EntityState.Deleted;
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
    }
}