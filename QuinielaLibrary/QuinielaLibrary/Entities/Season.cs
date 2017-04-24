using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class Season
    {
        public virtual Guid Id { get; set; }
        public virtual Guid LeagueId { get; set; }
        public virtual League League { get; set; }
        public virtual List<Team> Teams { get; set; }
        public virtual DateTime Year { get; set; }
        public virtual DateTime Starts { get; set; }
        public virtual DateTime Ends { get; set; }
        public virtual string Name { get; set; }
        public virtual int Weeks { get; set; }
        
    }
}
