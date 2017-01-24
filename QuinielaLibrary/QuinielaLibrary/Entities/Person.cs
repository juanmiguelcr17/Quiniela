using System;

namespace QuinielaLibrary.Entities
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastNameP { get; set; }
        public virtual string LastNameM { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Nation { get; set; }
    }
}
