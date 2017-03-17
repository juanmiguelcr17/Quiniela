using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Pools
{
    public class GroupPrediction
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}
