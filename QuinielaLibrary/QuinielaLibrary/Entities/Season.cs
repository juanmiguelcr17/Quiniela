using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class Season
    {
        public Guid Id { get; set; }
        public Guid LeagueId { get; set; }
        public League League { get; set; }
        public List<Team> Teams { get; set; }
        public DateTime Year { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
        public string Name { get; set; }
        public int Weeks { get; set; }
        public Season()
        {
        }

        public Season(Guid id, string name, DateTime year, DateTime starts, DateTime ends, League league, int weeks, List<Team> teams = null)
        {
            this.Id = id;
            this.Name = name;
            this.Year = year;
            this.Starts = starts;
            this.Ends = ends;
            this.League = league;
            this.Weeks = weeks;
            this.Teams = teams;
        }
    }
}
