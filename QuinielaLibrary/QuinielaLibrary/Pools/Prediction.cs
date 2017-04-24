using QuinielaLibrary.Entities;
using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Pools
{
    /// <summary>
    /// Clase que contiene las predicciones de la quiniela hechas por un usuario.
    /// </summary>
    public class Prediction
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual Guid GroupId { get; set; }
        public virtual Guid PoolId { get; set; }

        public virtual User User { get; set; }
        
        public virtual Group Group { get; set; }
        
        public virtual Pool PoolPredicted { get; set; }
        public virtual int Hits { get; set; }
        public virtual List<GamePrediction> Predictions { get; set; }
    }
}
