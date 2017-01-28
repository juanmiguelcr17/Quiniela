using QuinielaLibrary.Entities;
using QuinielaLibrary.Catalogs;
using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using QuinielaLibrary.Pools;

namespace QuinielaLibrary
{
    public class Actions
    {
        public Player CreatePlayer(Guid id,string name, string lastName, DateTime birthDate, string nationality, Enumerations.Position position)
        {
            return new Player(id, name, lastName, birthDate, nationality, position);
        }
        
        public Coach CreateCoach(Guid id, string name, string lastname, DateTime birthdate, string nationality)
        {
            return new Coach(id, name, lastname, birthdate, nationality);
        }
        
        public Referee CreateReferee(Guid id, string name, string lastname, DateTime birthdate, string nationality)
        {
            return new Referee(id, name, lastname, birthdate, nationality);
        }

        public Team CreateTeam(Guid id, string shortname, string name, string abbreviation, string stadium, string city, string state, Color color, Image shield = null, List<Player> players = null, Coach coach = null)
        {
            return new Team(id,shortname,name,abbreviation,stadium, city,state,color,shield,players,coach);
        }
        
        public League CreateLeague(Guid id, string name, string country)
        {
            return new League(id, name, country);
        }
        
        public Week CreateWeek(Guid id, int number, List<Game> games = null)
        {
            return new Week(id, number, games);
        }
        
        public Game CreateGame(Guid id, Team local, Team visitor, DateTime date, Score score = null, Referee referee = null)
        {
            return new Game(id, local, visitor, date, score, referee);
        }

        public Season CreateSeason(Guid id, string name, DateTime year, DateTime starts, DateTime ends, League league, int weeks, List<Team> teams = null)
        {
            return new Season(id, name, year, starts, ends, league, weeks, teams);
        }

        public void AddTeam(Team team, Season season)
        {
            season.Teams.Add(team);
        }

        public void AddTeams(List<Team> teams, Season season)
        {
            season.Teams = teams;
        }

        public Pool CreatePool(Guid id, DateTime date, DateTime maxDateFill, List<Game> games)
        {
            return new Pool(id, date, maxDateFill, games);
        }

        public void SetResultsOfWeek(List<Game> Games, Dictionary<Guid, Enumerations.Result> Results)
        {
            foreach (var result in Results)
            {
                Games.Where(i => i.Id == result.Key).FirstOrDefault().Result = result.Value;
            }
        }

        public int GetResultsAgainstPredictions(List<Game> Results, List<GamePrediction> Predictions)
        {
            int goodOnes = 0;

            foreach (var prediction in Predictions)
            {
                foreach (var game in Results)
                {
                    if (prediction.Game.Local.Id == game.Local.Id && prediction.Game.Visitor.Id == game.Visitor.Id)
                    {
                        if (prediction.Result == game.Result)
                        {
                            goodOnes++;
                            break;
                        }
                    }
                }
            }

            return goodOnes;
        }
    }
}
