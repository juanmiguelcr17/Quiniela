using QuinielaMVC4.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace QuinielaMVC4.Models
{
    public class BaseData : DropCreateDatabaseIfModelChanges<QuinielaEntities>
    {
        protected override void Seed(QuinielaEntities context)
        {
            var league = new League { LeagueId = Guid.NewGuid(), Name = "Liga MX", Country = "México" };
            context.Leagues.Add(league);

            var teams = new List<Team> 
            { 
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Las", ShortName = "Águilas", Name = "América", Abbreviation = "Ame", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/America", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Gold, Stadium = "Azteca", City = "Ciudad de México", State = "Ciudad de México", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Zorros", Name = "Atlas", Abbreviation = "Atl", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Atlas", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.IndianRed, Stadium = "Jalisco", City = "Guadalajara", State = "Jalisco", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Las", ShortName = "Chivas", Name = "Guadalajara", Abbreviation = "Chi", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Chivas", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.SteelBlue, Stadium = "Chivas", City = "Zapopan", State = "Jalisco", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="La", ShortName = "Máquina", Name = "Cruz Azul", Abbreviation = "Caz", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/CruzAzul", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Blue, Stadium = "Azul", City = "Ciudad de México", State = "Ciudad de México", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Jaguares", Name = "Chiapas", Abbreviation = "Chis", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Jaguares", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.SpringGreen, Stadium = "Víctor Manuel Reyna", City = "Tuxtla Gutiérrez", State = "Chiapas", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Esmeraldas", Name = "León", Abbreviation = "Leo", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Leon", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Green, Stadium = "Nou Camp", City = "León", State = "Guanajuato", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Monarcas", Name = "Morelia", Abbreviation = "Mor", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Monarcas", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Yellow, Stadium = "Morelos", City = "Morelia", State = "Michoacán", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Rayados", Name = "Monterrey", Abbreviation = "Mty", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Monterrey", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.DarkBlue, Stadium = "BBVA", City = "Monterrey", State = "Nuevo León", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Rayos", Name = "Necaxa", Abbreviation = "Nec", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Necaxa", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.HotPink, Stadium = "Victoria", City = "Aguascalientes", State = "Aguascalientes", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Tuzos", Name = "Pachuca", Abbreviation = "Pac", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Pachuca", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.DarkBlue, Stadium = "Hidalgo", City = "Pachuca", State = "Hidalgo", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="La", ShortName = "Franja", Name = "Puebla", Abbreviation = "Pue", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Puebla", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.SkyBlue, Stadium = "Cuauhtemoc", City = "Puebla", State = "Puebla", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Pumas", Name = "Pumas", Abbreviation = "Pum", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Pumas", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.DarkSlateBlue, Stadium = "Olimpico Universitario", City = "Ciudad Universitaria", State = "Ciudad de México", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Gallos", Name = "Querétaro", Abbreviation = "Que", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Queretaro", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Black, Stadium = "Corregidora", City = "Querétaro", State = "Querétaro", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Guerreros", Name = "Santos", Abbreviation = "San", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Santos", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.ForestGreen, Stadium = "Corona", City = "Torreón", State = "Coahuila", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Tigres", Name = "Tigres", Abbreviation = "Tig", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Tigres", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Gold, Stadium = "Universitario", City = "San Nicolás de los Garza", State = "Nuevo León", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Xolos", Name = "Tijuana", Abbreviation = "Tij", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Tijuana", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.DarkRed, Stadium = "Caliente", City = "Tijuana", State = "Baja California Norte", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Diablos", Name = "Toluca", Abbreviation = "Tol", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Toluca", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Red, Stadium = "Nemesio Díez", City = "Toluca", State = "México", Country="México" },
                new Team() { TeamId = Guid.NewGuid(), Pronoun="Los", ShortName = "Tiburones", Name = "Veracruz", Abbreviation = "Ver", Shield = "http://localhost:7555/QuinielaAPI/API/Resources/Veracruz", ShieldWidth=40, ShieldHeight=40, Color = System.Drawing.Color.Red, Stadium = "Luis Pirata Fuente", City = "Veracruz", State = "Veracruz", Country="México" },
            };
            context.Teams.AddRange(teams);

            var season = new Season
            {
                SeasonId = Guid.NewGuid(),
                Name = "Clausura 2017",
                LeagueId = league.LeagueId,
                League = league,
                Teams = teams,
                Year = DateTime.Now.Year,
                Starts = "01/01/2017",
                Ends = "15/16/2017",
                Weeks = 20
            };
            context.Seasons.Add(season);

            long id = 0;
            foreach (var team in teams)
            {
                SeasonTeams st = new SeasonTeams();
                st.Id = id;
                st.SeasonId = season.SeasonId;
                st.TeamId = team.TeamId;
                context.SeasonTeams.Add(st);
            }

            new List<Week> { 
                new Week{ WeekId = Guid.NewGuid(), Number = 1, Name = "Jornada 1", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 2, Name = "Jornada 2", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 3, Name = "Jornada 3", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 4, Name = "Jornada 4", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 5, Name = "Jornada 5", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 6, Name = "Jornada 6", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 7, Name = "Jornada 7", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 8, Name = "Jornada 8", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 9, Name = "Jornada 9", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 10, Name = "Jornada 10", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 11, Name = "Jornada 11", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 12, Name = "Jornada 12", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 13, Name = "Jornada 13", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 14, Name = "Jornada 14", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 15, Name = "Jornada 15", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 16, Name = "Jornada 16", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 17, Name = "Jornada 17", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 18, Name = "Cuartos de Final", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 19, Name = "Semifinal", SeasonId = season.SeasonId, Season = season, Games = null },
                new Week{ WeekId = Guid.NewGuid(), Number = 20, Name = "Final", SeasonId = season.SeasonId, Season = season, Games = null },
            }.ForEach(a => context.Weeks.Add(a));
        }
    }
}