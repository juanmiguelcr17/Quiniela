using System;
using System.ComponentModel.DataAnnotations;

namespace QuinielaMVC4.Models.Entities
{
    public class SeasonTeams
    {
        [Key]
        public long Id { get; set; }

        public Guid SeasonId { get; set; }

        public Guid TeamId { get; set; }
    }
}