using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class Week
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public List<Game> Games { get; set; }
    }
}
