using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using QuinielaLibrary;
using QuinielaLibrary.Entities;
using QuinielaLibrary.Pools;

namespace QuinielaTestConsoleApp
{
    public class Test
    {
        Actions act = new Actions();
        string[] equipos = new string[] { "Veracruz", "Queretaro", "Cruz Azul", "Necaxa", "Tigres", "Santos", "Morelia", "Tijuana", "Leon", "Pachuca", "Chivas", "Pumas", "Toluca", "Atlas", "Puebla", "Monterrey", "Jaguares", "America" };
        string[] abb = new string[] { "Ver", "Que", "Caz", "Nec", "Tig", "San", "Mor", "Tij", "Leo", "Pac", "Chi", "UNAM", "Tol", "Atl", "Pue", "Mty", "Jag", "Ame" };
        int[] colors = new int[] { -65536, -16777216, -16776961, -16181, -329006, -16744448, -23296, -65536, -16744448, -12042869, -65536, -10496, -65536, -65536, -16728065, -16777077, -16744448, -256 };
        List<Team> teams = new List<Team>();
        internal Season temporada { get; set; }
        internal League ligaMX { get; set; }
        internal List<Game> Partidos { get; set; }
        internal Week semana1 { get; set; }
        internal Pool Quiniela1 { get; set; }
        internal Prediction Prediccion1 { get; set; }
        internal int aciertos { get; set; }

        internal void crearLiga()
        {
            ligaMX = act.CreateLeague(Guid.NewGuid(), "Liga MX", "México");
        }

        internal void CrearTemporada()
        {
            temporada = act.CreateSeason(Guid.NewGuid(), "Clausura 2017", DateTime.Now, DateTime.Now, DateTime.Now, ligaMX, 17);
        }

        internal void CrearEquipos()
        {
            for (int i = 0; i <= 17; i++)
            {
                teams.Add(new Team(Guid.NewGuid(), abb[i], equipos[i], abb[i], "", "", "", colors[i]));
            }
            act.AddTeams(teams, temporada);
        }

        internal void CrearJornada()
        {
            Partidos = new List<Game>();
            for (int i = 0; i <= 17; i += 2)
            {
                Partidos.Add(act.CreateGame(Guid.NewGuid(), teams.ElementAt(i), teams.ElementAt(i + 1), DateTime.Now));
            }
            semana1 = act.CreateWeek(Guid.NewGuid(), 1, Partidos);
        }

        internal void CrearQuiniela()
        {
            Quiniela1 = act.CreatePool(Guid.NewGuid(), DateTime.Now, DateTime.Now, semana1.Games);
        }
        
        internal void CrearPrediccion()
        {
            Prediccion1 = new Prediction();
            Prediccion1.Id = Guid.NewGuid();
            Prediccion1.User = new User();
            Prediccion1.Group = new Group();
            Prediccion1.Predictions = new List<GamePrediction>();
            foreach (var game in Quiniela1.Games)
            {
                Prediccion1.Predictions.Add(new GamePrediction(game, QuinielaLibrary.Catalogs.Enumerations.Result.Local));
            }
        }

        internal void SetResultsOfWeek()
        {
            Dictionary<Guid, QuinielaLibrary.Catalogs.Enumerations.Result> Results = new Dictionary<Guid, QuinielaLibrary.Catalogs.Enumerations.Result>();

            Results.Add(semana1.Games.ElementAt(0).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(1).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(2).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Empate);
            Results.Add(semana1.Games.ElementAt(3).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(4).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Vistante);
            Results.Add(semana1.Games.ElementAt(5).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(6).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(7).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Vistante);

            act.SetResultsOfWeek(semana1.Games, Results);
        }

        internal void VerifyResults()
        {
            aciertos = act.GetResultsAgainstPredictions(semana1.Games, Prediccion1.Predictions);
        }
    }
}

