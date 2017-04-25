
namespace QuinielaMVC4.Models.Entities
{
    public class Week : QuinielaLibrary.Entities.Week
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

        public override int Number
        {
            get
            {
                return base.Number;
            }
            set
            {
                base.Number = value;
            }
        }

        public override System.Guid SeasonId
        {
            get
            {
                return base.SeasonId;
            }
            set
            {
                base.SeasonId = value;
            }
        }

        public override QuinielaLibrary.Entities.Season Season
        {
            get
            {
                return base.Season;
            }
            set
            {
                base.Season = value;
            }
        }

        public override System.Collections.Generic.List<QuinielaLibrary.Entities.Game> Games
        {
            get
            {
                return base.Games;
            }
            set
            {
                base.Games = value;
            }
        }
    }
}