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
        
    }
}
