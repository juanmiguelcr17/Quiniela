using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuinielaMVC4.Models.Entities
{
    public class Week
    {
        [Key]
        [ScaffoldColumn(false)]
        public System.Guid WeekId { get; set; }

        [Display(Name="Número")]
        public int Number { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public System.Guid SeasonId { get; set; }

        public Season Season {  get; set; }

        public System.Collections.Generic.List<Game> Games { get; set; }
    }
}