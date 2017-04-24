using System;
using System.Collections.Generic;
using System.Drawing;

namespace QuinielaLibrary.Entities
{
    public class Team
    {
        public virtual Guid Id { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Abbreviation { get; set; }
        public virtual Image Shield { get; set; }
        public virtual Color Color { get; set; }
        public virtual string Stadium { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        
        //    this.Color = Color.FromArgb(color);
        
    }
}
