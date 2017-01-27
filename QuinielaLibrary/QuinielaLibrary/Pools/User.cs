using QuinielaLibrary.Entities;
using System;
using System.Drawing;

namespace QuinielaLibrary.Pools
{
    // EL CONTROL DE USUARIOS DEBE IR EN OTRA LIBRERIA
    public class User : Person
    {
        public override Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }
        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }
        public override string LastName
        {
            get
            {
                return base.LastName;
            }
            set
            {
                base.LastName = value;
            }
        }
        public Image Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
