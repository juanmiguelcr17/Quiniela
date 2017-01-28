using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuinielaLibrary.Pools
{
    public class UserHits
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Hits { get; set; }
    }
}
