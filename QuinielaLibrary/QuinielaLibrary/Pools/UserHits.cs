using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuinielaLibrary.Pools
{
    public class UserHits
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual int Hits { get; set; }
    }
}
