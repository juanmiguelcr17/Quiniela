﻿using QuinielaLibrary.Entities;
using System;
using System.Collections.Generic;

namespace QuinielaMVC4.Models.Pools
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
    }
}
