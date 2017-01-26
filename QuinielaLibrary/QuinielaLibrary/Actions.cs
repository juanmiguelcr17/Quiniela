using QuinielaLibrary.Entities;
using QuinielaLibrary.Catalogs;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace QuinielaLibrary
{
    public class Actions
    {
        public Player CreatePlayer(Guid id,string name, string lastName, DateTime birthDate, string nationality, Enumerations.Position position)
        {
            return new Player(id, name, lastName, birthDate, nationality, position);
        }
        public Coach CreateCoach(Guid id, string name, string lastname, DateTime birthdate, string nationality)
        {
            return new Coach(id, name, lastname, birthdate, nationality);
        }
        public Referee CreateReferee(Guid id, string name, string lastname, DateTime birthdate, string nationality)
        {
            return new Referee(id, name, lastname, birthdate, nationality);
        }
        public Team CreateTeam(Guid id, string shortname, string name, string abbreviation, Image shield, Color color, string stadium, string city, string state, List<Player> players=null, Coach coach=null)
        {
            return new Team(id, shortname, name, abbreviation, shield, color, stadium, city, state, players, coach);
        }
    }
}
