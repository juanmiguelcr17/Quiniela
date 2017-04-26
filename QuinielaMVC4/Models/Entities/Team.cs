using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuinielaMVC4.Models.Entities
{
    public class Team
    {
        [ScaffoldColumn(false)]
        [Key]
        public System.Guid TeamId { get; set; }

        [ScaffoldColumn(false)]
        public string Pronoun { get; set; }

        [Display(Name="Sobrenombre")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Debes elegir el nombre del equipo")]
        [Display(Name = "Equipo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debes elegir la abreviatura del equipo")]
        [Display(Name = "Abreviatura")]
        public string Abbreviation { get; set; }

        [Display(Name = "Escudo")]
        [DataType(DataType.ImageUrl)]
        public string Shield { get; set; }

        [Required(ErrorMessage = "Debes elegir el color del equipo")]
        public System.Drawing.Color Color { get; set; }

        [Display(Name = "Estadio")]
        public string Stadium { get; set; }

        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }
    }
}