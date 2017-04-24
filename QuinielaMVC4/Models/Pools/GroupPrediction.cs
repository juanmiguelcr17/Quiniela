using System;
using System.Collections.Generic;

namespace QuinielaMVC4.Models.Pools
{
    public class GroupPrediction
    {
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}
