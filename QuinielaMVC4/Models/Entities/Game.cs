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

        public Team Local { get; set; }

        public Team Visitor { get;  set; }

        public QuinielaLibrary.Catalogs.Score Score { get; set; }

        [Required(ErrorMessage = "Debes elegir la fecha del partido")]
        [Display(Name = "Fecha")]
        public System.DateTime Date { get; set; }

        [ScaffoldColumn(false)]
        public QuinielaLibrary.Catalogs.Enumerations.Result Result { get; set; }
    }
}