using QuinielaLibrary.Entities;
using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Pools
{
    /// <summary>
    /// Quiniela. Contiene los juegos a pronosticar, fecha, fecha límite para llenarla.
    /// </summary>
    public class Pool
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime MaxDateFill { get; set; }
        public List<Game> Games { get; set; }
        public Pool()
        {
        }
        public Pool(Guid id, DateTime date, DateTime maxdatefill, List<Game>games)
        {
            this.Id = id;
            this.Date = Date;
            this.MaxDateFill = maxdatefill;
            this.Games = games;
        }
    }
}
