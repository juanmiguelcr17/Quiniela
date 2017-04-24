using System;

namespace QuinielaMVC4.Models.Pools
{
    public class Classification
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public System.Collections.Generic.List<UserHits> UsersHits { get; set; }
    }
}
