using System;
using System.Collections.Generic;

namespace QuinielaLibrary.Entities
{
    public class League
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Country { get; set; }
    }
}
