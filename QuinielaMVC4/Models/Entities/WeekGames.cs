
using System;
using System.ComponentModel.DataAnnotations;

namespace QuinielaMVC4.Models.Entities
{
    public class WeekGames
    {
        [Key]
        public long Id { get; set; }

        public Guid WeekId { get; set; }

        public Guid GameId { get; set; }
    }
}