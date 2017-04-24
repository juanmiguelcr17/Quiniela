using System;
using System.Collections.Generic;
using System.Drawing;
namespace QuinielaLibrary.Pools
{
    public class Group
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Image Photo { get; set; }
        public virtual int UsersLimit { get; set; }
        public virtual List<User> Members { get; set; }
    }
}
