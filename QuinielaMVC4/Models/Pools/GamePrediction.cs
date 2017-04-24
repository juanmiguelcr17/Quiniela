using QuinielaLibrary.Entities;
using QuinielaLibrary.Catalogs;
using System;

namespace QuinielaMVC4.Models.Pools
{
    public class GamePrediction
    {
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Enumerations.Result Result { get; set; }
                
    }
}
