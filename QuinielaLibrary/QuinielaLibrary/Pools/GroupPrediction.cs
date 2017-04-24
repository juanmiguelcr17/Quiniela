using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Pools
{
    public class GroupPrediction
    {
        public virtual Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual List<Prediction> Predictions { get; set; }
    }
}
