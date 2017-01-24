using System;

namespace QuinielaLibrary.Entities
{
    public class Player : Person
    {
        public override int Id
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
        public override string LastNameP
        {
            get
            {
                return base.LastNameP;
            }

            set
            {
                base.LastNameP = value;
            }
        }
        public override string LastNameM
        {
            get
            {
                return base.LastNameM;
            }

            set
            {
                base.LastNameM = value;
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
        public override string Nation
        {
            get
            {
                return base.Nation;
            }

            set
            {
                base.Nation = value;
            }
        }
        public QuinielaLibrary.Catalogs.Enumerations.Posicion Posicion { get; set; }
    }
}
