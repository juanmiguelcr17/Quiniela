using System;
using System.Drawing;

namespace QuinielaLibrary.Pools
{
    // EL CONTROL DE USUARIOS DEBE IR EN OTRA LIBRERIA
    public class User
    {
        public virtual Guid Id
        {
            get;
            set;
        }
        public virtual string Name
        {
            get;
            set;
        }
        public virtual string LastName
        {
            get;
            set;
        }
        public virtual Image Photo { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }
}
