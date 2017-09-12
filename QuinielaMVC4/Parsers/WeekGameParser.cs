using Newtonsoft.Json;
using QuinielaLibrary.Catalogs;
using QuinielaMVC4.Models.Entities;
using QuinielaMVC4.ViewModels;
using static QuinielaLibrary.Catalogs.Enumerations;

namespace QuinielaMVC4.Parsers
{
    public static class WeekGameParser
    {
        public static WeekGamesVM ToWeekGamesVM (this Game game)
        {
            Team local = JsonConvert.DeserializeObject<Team>(game.Local);
            Team visitor = JsonConvert.DeserializeObject<Team>(game.Visitor);
            Score score = JsonConvert.DeserializeObject<Score>(game.Score);
            Result result = (Result)game.Result;

            WeekGamesVM weekGame = new WeekGamesVM();
            weekGame.Local = local.Name;
            weekGame.Visitor = visitor.Name;
            weekGame.Date = game.Date;
            weekGame.LocalScore = score != null ? score.Local : 0;
            weekGame.VisitorScore = score != null ? score.Visitor : 0;
            weekGame.Result = result.ToString();

            return weekGame;
        }
    }
}