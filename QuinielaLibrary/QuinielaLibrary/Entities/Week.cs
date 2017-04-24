using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class Week
    {
        public virtual Guid Id { get; set; }
        public virtual int Number { get; set; }
        public virtual Guid SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public virtual List<Game> Games { get; set; }
        
    }
}
