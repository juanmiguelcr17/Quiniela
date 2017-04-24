using QuinielaLibrary.Entities;
using System;

namespace QuinielaLibrary.Pools
{
    public class GamePrediction
    {
        public virtual Guid GameId { get; set; }
        public virtual Game Game { get; set; }
        public virtual QuinielaLibrary.Catalogs.Enumerations.Result Result { get; set; }
                
    }
}
