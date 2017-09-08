using System.ComponentModel.DataAnnotations;

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
        [Range(1900, 2100, ErrorMessage = "Solo se permite registrar temporadas entre los años 1900 y 2100")]
        public int Year { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Inicia")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Starts { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Termina")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string Ends { get; set; }

        [Display(Name = "No. Semanas")]
        public int Weeks { get; set; }
    }
}