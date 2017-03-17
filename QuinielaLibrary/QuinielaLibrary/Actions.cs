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
        public Player CreatePlayer(Guid Id, string Name, string LastName, DateTime BirthDate, string Nationality, Enumerations.Position Position)
        {
            return new Player(Id, Name, LastName, BirthDate, Nationality, Position);
        }
        
        public Coach CreateCoach(Guid Id, string Name, string LastName, DateTime BirthDate, string Nationality)
        {
            return new Coach(Id, Name, LastName, BirthDate, Nationality);
        }
        
        public Referee CreateReferee(Guid Id, string Name, string LastName, DateTime BirthDate, string Nationality)
        {
            return new Referee(Id, Name, LastName, BirthDate, Nationality);
        }

        public Team CreateTeam(Guid Id, string ShortName, string Name, string Abbreviation, string Stadium, string City, string State, Color Color, Image Shield = null, List<Player> Players = null, Coach Coach = null)
        {
            return new Team(Id, ShortName, Name, Abbreviation, Stadium, City, State, Color, Shield, Players, Coach);
        }
        
        public League CreateLeague(Guid Id, string Name, string Country)
        {
            return new League(Id, Name, Country);
        }
        
        public Week CreateWeek(Guid Id, int Number, List<Game> Games = null)
        {
            return new Week(Id, Number, Games);
        }
        
        public Game CreateGame(Guid Id, Team Local, Team Visitor, DateTime Date, Score Score = null, Referee Referee = null)
        {
            return new Game(Id, Local, Visitor, Date, Score, Referee);
        }

        public Season CreateSeason(Guid Id, string Name, DateTime Year, DateTime Starts, DateTime Ends, League League, int Weeks, List<Team> Teams = null)
        {
            return new Season(Id, Name, Year, Starts, Ends, League, Weeks, Teams);
        }

        public void AddTeam(Team Team, Season Season)
        {
            Season.Teams.Add(Team);
        }

        public void AddTeams(List<Team> Teams, Season Season)
        {
            Season.Teams = Teams;
        }

        public Pool CreatePool(Guid Id, DateTime Date, DateTime MaxDateFill, List<Game> Games)
        {
            return new Pool(Id, Date, MaxDateFill, Games);
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
