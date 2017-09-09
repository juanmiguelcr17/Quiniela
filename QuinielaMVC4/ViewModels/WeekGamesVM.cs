using System.ComponentModel.DataAnnotations;

namespace QuinielaMVC4.ViewModels
{
    public class WeekGamesVM
    {
        [Display(Name ="Local")]
        public string Local { get; set; }

        [Display(Name = "Visitante")]
        public string Visitor { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Display(Name = "Marcador local")]
        public int LocalScore { get; set; }

        [Display(Name = "Marcador visitante")]
        public int VisitorScore { get; set; }

        [Display(Name = "Resultado")]
        public string Result { get; set; }
    }
}