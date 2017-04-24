using QuinielaLibrary.Entities;
using QuinielaLibrary.Catalogs;
using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using QuinielaLibrary.Pools;

namespace QuinielaLibrary
{
    public class Actions
    {
        public void SetResultsOfWeek(List<Game> Games, Dictionary<Guid, Enumerations.Result> Results)
        {
            foreach (var result in Results)
            {
                Games.Where(i => i.Id == result.Key).First().Result = result.Value;
            }
        }

        public int GetResultsAgainstPredictions(List<Game> Results, List<GamePrediction> Predictions)
        {
            int goodOnes = 0;

            foreach (var prediction in Predictions)
            {
                foreach (var game in Results)
                {
                    if (prediction.Game.Local.Id == game.Local.Id && prediction.Game.Visitor.Id == game.Visitor.Id)
                    {
                        if (prediction.Result == game.Result)
                        {
                            goodOnes++;
                            break;
                        }
                    }
                }
            }

            return goodOnes;
        }
    }
}
