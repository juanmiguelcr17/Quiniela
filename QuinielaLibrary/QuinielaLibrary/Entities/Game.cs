using QuinielaLibrary.Catalogs;
using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class Game
    {
        public Team Local { get; set; }
        public Team Visitor { get; set; }
        public Score Score { get; set; }
        public DateTime Date { get; set; }
        
    }
}
