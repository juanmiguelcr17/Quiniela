using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class Season
    {
        public Guid Id { get; set; }
        public League League { get; set; }
        public List<Team> Teams { get; set; }
        public DateTime Year { get; set; }
        public string Name { get; set; }
    }
}
