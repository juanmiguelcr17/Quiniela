using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class League
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public League()
        {
        }
        public League(Guid id, string name, string country)
        {
            this.Id = id;
            this.Name = name;
            this.Country = country;
        }
    }
}
