using System;
using System.Drawing;

namespace QuinielaMVC4.Models.Pools
{
    // EL CONTROL DE USUARIOS DEBE IR EN OTRA LIBRERIA
    public class User
    {
        public Guid Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public virtual Image Photo { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }
}
