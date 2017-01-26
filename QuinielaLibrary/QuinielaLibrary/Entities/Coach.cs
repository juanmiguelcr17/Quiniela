using System;

namespace QuinielaLibrary.Entities
{
    public class Coach : Person
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
        public override DateTime BirthDate
        {
            get
            {
                return base.BirthDate;
            }

            set
            {
                base.BirthDate = value;
            }
        }
        public override string Nationality
        {
            get
            {
                return base.Nationality;
            }

            set
            {
                base.Nationality = value;
            }
        }
        public Coach()
        {
        }
        public Coach(Guid id, string name, string lastname, DateTime birthdate, string nationality)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastname;
            this.BirthDate = birthdate;
            this.Nationality = nationality;
        }
    }
}
