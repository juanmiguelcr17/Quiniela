using System.Data.Entity;
using QuinielaMVC4.Models.Entities;

namespace QuinielaMVC4.Models
{
    public class QuinielaEntities : DbContext
    {
        public QuinielaEntities() : base("name=QuinielaDBContext")
        {
        }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<SeasonTeams> SeasonTeams { get; set; }
    }
}