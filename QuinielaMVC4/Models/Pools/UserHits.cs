using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuinielaMVC4.Models.Pools
{
    public class UserHits
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Hits { get; set; }
    }
}
