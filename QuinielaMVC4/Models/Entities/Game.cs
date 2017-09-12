using System.ComponentModel.DataAnnotations;

namespace QuinielaMVC4.Models.Entities
{
    public class Game
    {
        [Key]
        [ScaffoldColumn(false)]
        public System.Guid GameId { get; set; }

        [ScaffoldColumn(false)]
        public System.Guid LocalId { get; set; }

        [ScaffoldColumn(false)]
        public System.Guid VisitorId { get; set; }

        [Display(Name = "Local")]
        public string Local { get; set; }

        [Display(Name = "Visitante")]
        public string Visitor { get;  set; }

        [Display(Name = "Marcador")]
        public string Score { get; set; }

        [Required(ErrorMessage = "Debes elegir la fecha del partido")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public string Date { get; set; }


        [ScaffoldColumn(false)]
        public int Result { get; set; }
    }
}