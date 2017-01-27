using QuinielaLibrary.Catalogs;
using System;

namespace QuinielaLibrary.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public Team Local { get; set; }

        public Team Visitor { get; set; }

        public Score Score { get; set; }

        public DateTime Date { get; set; }

        public Referee Referee { get; set; }

        public QuinielaLibrary.Catalogs.Enumerations.Result Result { get; set; }

        public Game()
        {
        }

        public Game(Guid id, Team local, Team visitor, DateTime date, Score score=null, Referee referee=null)
        {
            this.Id = id;
            this.Local = local;
            this.Visitor = visitor;
            this.Date = date;
            this.Score = score;
            this.Referee = referee;
        }
    }
}
