using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuinielaLibrary.Pools
{
    public class GeneralClassification
    {
        public Guid Id { get; set; }
        public Group Group { get; set; }
        public List<Classification> ClassificationsOfSeason { get; set; }
    }
}
