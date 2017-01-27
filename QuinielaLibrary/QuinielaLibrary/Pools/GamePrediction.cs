using QuinielaLibrary.Entities;
using System;

namespace QuinielaLibrary.Pools
{
    public class GamePrediction
    {
        public Game Game { get; set; }
        public QuinielaLibrary.Catalogs.Enumerations.Result Result { get; set; }
        public GamePrediction()
        {
        }
        public GamePrediction(Game game, QuinielaLibrary.Catalogs.Enumerations.Result result)
        {
            this.Game = game;
            this.Result = result;
        }
    }
}
