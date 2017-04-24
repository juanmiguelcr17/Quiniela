using System;

namespace QuinielaLibrary.Pools
{
    public class Classification
    {
        public virtual Guid Id { get; set; }
        public virtual Guid GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual System.Collections.Generic.List<UserHits> UsersHits { get; set; }
    }
}
