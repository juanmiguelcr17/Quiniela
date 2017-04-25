
namespace QuinielaMVC4.Models.Entities
{
    public class Team : QuinielaLibrary.Entities.Team
    {
        public override System.Guid Id
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

        public override string ShortName
        {
            get
            {
                return base.ShortName;
            }
            set
            {
                base.ShortName = value;
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

        public override string Abbreviation
        {
            get
            {
                return base.Abbreviation;
            }
            set
            {
                base.Abbreviation = value;
            }
        }

        public override System.Drawing.Image Shield
        {
            get
            {
                return base.Shield;
            }
            set
            {
                base.Shield = value;
            }
        }

        public override System.Drawing.Color Color
        {
            get
            {
                return base.Color;
            }
            set
            {
                base.Color = value;
            }
        }

        public override string Stadium
        {
            get
            {
                return base.Stadium;
            }
            set
            {
                base.Stadium = value;
            }
        }

        public override string City
        {
            get
            {
                return base.City;
            }
            set
            {
                base.City = value;
            }
        }

        public override string State
        {
            get
            {
                return base.State;
            }
            set
            {
                base.State = value;
            }
        }
    }
}