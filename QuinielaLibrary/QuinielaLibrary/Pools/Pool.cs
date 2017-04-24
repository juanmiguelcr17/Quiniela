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
        public virtual Guid Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime MaxDateFill { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}
