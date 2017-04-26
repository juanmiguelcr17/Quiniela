using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace QuinielaMVC4.Models.Entities
{
    public class League
    {
        [Key]
        [ScaffoldColumn(false)]
        public System.Guid LeagueId { get; set; }

        [Display(Name="Liga")]
        public string Name { get; set; }

        [Display(Name="Pais")]
        public string Country { get; set; }
    }
}