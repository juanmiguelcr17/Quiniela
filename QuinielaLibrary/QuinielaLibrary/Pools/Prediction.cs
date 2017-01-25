﻿using QuinielaLibrary.Entities;
using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Pools
{
    /// <summary>
    /// Clase que contiene las predicciones de la quiniela hechas por un usuario.
    /// </summary>
    public class Prediction
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
        public Pool Pool { get; set; }
    }
}
