using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class Week
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Season Season { get; set; }
        public List<Game> Games { get; set; }
        public Week()
        {
        }
        public Week(Guid id, int number, List<Game> games = null, Season season = null)
        {
            this.Id = id;
            this.Number = number;
            this.Games = games;
            this.Season = season;
        }
    }
}
