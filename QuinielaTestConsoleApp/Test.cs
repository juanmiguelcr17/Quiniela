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
        string[] names = new string[] { "Joan", "Mikel", "Jhon", "Louis", "Kim" };
        string[] LastNames = new string[] { "Fields", "Smith", "Jackson", "Sheep", "Forest", "Lee", "Johansen", "Marts" };
        List<Team> teams = new List<Team>();
        internal Season temporada { get; set; }
        internal League ligaMX { get; set; }
        internal List<Game> Partidos { get; set; }
        internal Week semana1 { get; set; }
        internal Pool Quiniela1 { get; set; }
        internal Prediction Prediccion1 { get; set; }
        internal int aciertos { get; set; }
        internal User User1 { get; set; }
        internal Group Grupo1 { get; set; }
        internal GroupPrediction PredictionsOfGroup { get; set; }
        internal UserHits UserHits { get; set; }
        internal Classification WeekClassif { get; set; }

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

        internal void CrearUsuario()
        {
            Random rdm = new Random();
            User1 = new User();
            User1.Id = Guid.NewGuid();
            User1.Name = names[rdm.Next(0, names.Count() - 1)];
            User1.LastName = string.Format("{0} {1}", LastNames[rdm.Next(0, LastNames.Count() - 1)], LastNames[rdm.Next(0, LastNames.Count() - 1)]);
            User1.Email = string.Format("{0}{1}@testgmail.com", User1.Name.ToLower(), User1.LastName.ToLower().Trim().Replace(" ",""));
            Grupo1.Members.Add(User1);
        }
        internal void CrearGrupo()
        {
            Grupo1 = new Group();
            Grupo1.Id = Guid.NewGuid();
            Grupo1.Name = "Loosers";
            Grupo1.UsersLimit = 5;
            Grupo1.Members = new List<User>();
        }

        internal void CrearPrediccion()
        {
            Random rdm = new Random();
            Prediccion1 = new Prediction();
            Prediccion1.Id = Guid.NewGuid();
            Prediccion1.User = User1;
            Prediccion1.Group = Grupo1;
            Prediccion1.PoolPredicted = Quiniela1;
            Prediccion1.Predictions = new List<GamePrediction>();
            foreach (var game in Quiniela1.Games)
            {
                var res = QuinielaLibrary.Catalogs.Enumerations.Result.NA;
            newOne:
                switch (rdm.Next(0,4))
                {
                    case 1:
                        res = QuinielaLibrary.Catalogs.Enumerations.Result.Local;
                        goto add;
                    case 2:
                        res = QuinielaLibrary.Catalogs.Enumerations.Result.Empate;
                        goto add;
                    case 3:
                       res = QuinielaLibrary.Catalogs.Enumerations.Result.Visitante;
                        goto add;
                    add:
                    Prediccion1.Predictions.Add(new GamePrediction(game, res));
                    break;
                    default:
                    goto newOne;
                }
                
            }
        }

        internal void SetResultsOfWeek()
        {
            Dictionary<Guid, QuinielaLibrary.Catalogs.Enumerations.Result> Results = new Dictionary<Guid, QuinielaLibrary.Catalogs.Enumerations.Result>();

            Results.Add(semana1.Games.ElementAt(0).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(1).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(2).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Empate);
            Results.Add(semana1.Games.ElementAt(3).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(4).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Visitante);
            Results.Add(semana1.Games.ElementAt(5).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(6).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Local);
            Results.Add(semana1.Games.ElementAt(7).Id, QuinielaLibrary.Catalogs.Enumerations.Result.Visitante);

            act.SetResultsOfWeek(semana1.Games, Results);
        }

        internal void VerifyResults()
        {
            aciertos = act.GetResultsAgainstPredictions(semana1.Games, Prediccion1.Predictions);
            Prediccion1.Hits = aciertos;
        }
        internal Test()
        {
            PredictionsOfGroup = new GroupPrediction();
            PredictionsOfGroup.Predictions = new List<Prediction>();


            WeekClassif = new Classification();
            WeekClassif.UsersHits = new List<UserHits>();
            WeekClassif.Id = Guid.NewGuid();
        }

        internal void AddPredictionToList()
        {
            PredictionsOfGroup.Predictions.Add(Prediccion1);
        }

        internal void GetWeekClassification()
        {
            WeekClassif.Group = Grupo1;
            foreach (var pred in PredictionsOfGroup.Predictions)
            {
                UserHits = new UserHits();
                UserHits.Id = pred.User.Id;
                UserHits.UserName = pred.User.Name + " " + pred.User.LastName;
                UserHits.Hits = pred.Hits;
                WeekClassif.UsersHits.Add(UserHits);
            }
            //WeekClassif.UsersHits.Sort(delegate(UserHits uh1, UserHits uh2) { return uh2.Hits.CompareTo(uh1.Hits); });
            WeekClassif.UsersHits.Sort((a, b) => b.Hits.CompareTo(a.Hits));
        }
    }
}

