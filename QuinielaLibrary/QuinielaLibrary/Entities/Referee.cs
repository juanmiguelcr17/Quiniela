using System;

namespace QuinielaLibrary.Entities
{
    public class Referee : Person
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
        
    }
}
