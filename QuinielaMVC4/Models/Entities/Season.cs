
namespace QuinielaMVC4.Models.Entities
{
    public class Season : QuinielaLibrary.Entities.Season
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

        public override System.Guid LeagueId
        {
            get
            {
                return base.LeagueId;
            }
            set
            {
                base.LeagueId = value;
            }
        }

        public override QuinielaLibrary.Entities.League League
        {
            get
            {
                return base.League;
            }
            set
            {
                base.League = value;
            }
        }

        public System.Collections.Generic.List<Team> Teams { get; set; }

        public override System.DateTime Year
        {
            get
            {
                return base.Year;
            }
            set
            {
                base.Year = value;
            }
        }

        public override System.DateTime Starts
        {
            get
            {
                return base.Starts;
            }
            set
            {
                base.Starts = value;
            }
        }

        public override System.DateTime Ends
        {
            get
            {
                return base.Ends;
            }
            set
            {
                base.Ends = value;
            }
        }

        public override int Weeks
        {
            get
            {
                return base.Weeks;
            }
            set
            {
                base.Weeks = value;
            }
        }
    }
}