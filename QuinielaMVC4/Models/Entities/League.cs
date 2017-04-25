
namespace QuinielaMVC4.Models.Entities
{
    public class League : QuinielaLibrary.Entities.League
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

        public override string Country
        {
            get
            {
                return base.Country;
            }
            set
            {
                base.Country = value;
            }
        }
    }
}