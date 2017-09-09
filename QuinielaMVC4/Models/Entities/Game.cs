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

        public string Local { get; set; }

        public string Visitor { get;  set; }

        public string Score { get; set; }

        [Required(ErrorMessage = "Debes elegir la fecha del partido")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [ScaffoldColumn(false)]
        public string Result { get; set; }
    }
}