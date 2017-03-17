using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuinielaLibrary.Pools
{
    public class Classification
    {
        public Guid Id { get; set; }
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public List<UserHits> UsersHits { get; set; }
    }
}
