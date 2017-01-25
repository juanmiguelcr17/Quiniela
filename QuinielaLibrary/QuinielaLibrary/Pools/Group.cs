using System;
using System.Collections.Generic;
namespace QuinielaLibrary.Pools
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
    }
}
