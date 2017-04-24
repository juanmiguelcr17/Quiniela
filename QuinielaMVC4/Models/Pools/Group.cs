using System;
using System.Collections.Generic;
using System.Drawing;
namespace QuinielaMVC4.Models.Pools
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image Photo { get; set; }
        public int UsersLimit { get; set; }
        public List<User> Members { get; set; }
    }
}
