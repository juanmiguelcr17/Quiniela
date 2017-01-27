using System;
using System.Collections.Generic;
using System.Drawing;

namespace QuinielaLibrary.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Image Shield { get; set; }
        public Color Color { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<Player> Players { get; set; }
        public Coach Coach { get; set; }
        public Team()
        {
        }
        public Team(Guid id, string shortname, string name, string abbreviation, string stadium, string city, string state, Color color, Image shield = null, List<Player> players = null, Coach coach = null)
        {
            this.Id = id;
            this.ShortName = shortname;
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Shield = shield;
            this.Color = color;
            this.Stadium = stadium;
            this.City = city;
            this.State = state;
            this.Players = players;
            this.Coach = coach;
        }
        public Team(Guid id, string shortname, string name, string abbreviation, string stadium, string city, string state, int color, Image shield = null, List<Player> players = null, Coach coach = null)
        {
            this.Id = id;
            this.ShortName = shortname;
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Shield = shield;
            this.Color = Color.FromArgb(color);
            this.Stadium = stadium;
            this.City = city;
            this.State = state;
            this.Players = players;
            this.Coach = coach;
        }
    }
}
