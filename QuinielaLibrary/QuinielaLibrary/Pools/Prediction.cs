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
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid PoolId { get; set; }
        public Pool PoolPredicted { get; set; }
        public int Hits { get; set; }
        public List<GamePrediction> Predictions { get; set; }
    }
}
