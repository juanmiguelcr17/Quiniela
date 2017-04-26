using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuinielaMVC4.Models.Entities
{
    public class Season
    {
        [Key]
        [ScaffoldColumn(false)]
        public System.Guid SeasonId { get; set; }

        [Display(Name="Nombre")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public System.Guid LeagueId { get; set; }

        public League League { get; set; }

        public System.Collections.Generic.List<Team> Teams { get; set; }

        [Display(Name = "Año")]
        public int Year { get; set; }

        [Display(Name = "Inicia")]
        public System.DateTime Starts { get; set; }

        [Display(Name = "Termina")]
        public System.DateTime Ends { get; set; }

        [Display(Name = "No. Semanas")]
        public int Weeks { get; set; }
    }
}