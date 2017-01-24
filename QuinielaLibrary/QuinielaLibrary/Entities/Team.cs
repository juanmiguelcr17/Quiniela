using System;
using System.Collections.Generic;
using System.Drawing;

namespace QuinielaLibrary.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Color Color { get; set; }
        public Image Shield { get; set; }
        public List<Player> Players { get; set; }
        public Coach Coach { get; set; }
    }
}
