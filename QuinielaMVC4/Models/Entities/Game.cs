
namespace QuinielaMVC4.Models.Entities
{
    public class Game : QuinielaLibrary.Entities.Game
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

        public override System.Guid LocalId
        {
            get
            {
                return base.LocalId;
            }
            set
            {
                base.LocalId = value;
            }
        }

        public override System.Guid VisitorId
        {
            get
            {
                return base.VisitorId;
            }
            set
            {
                base.VisitorId = value;
            }
        }

        public override QuinielaLibrary.Entities.Team Local
        {
            get
            {
                return base.Local;
            }
            set
            {
                base.Local = value;
            }
        }

        public override QuinielaLibrary.Entities.Team Visitor
        {
            get
            {
                return base.Visitor;
            }
            set
            {
                base.Visitor = value;
            }
        }

        public override QuinielaLibrary.Catalogs.Score Score
        {
            get
            {
                return base.Score;
            }
            set
            {
                base.Score = value;
            }
        }

        public override System.DateTime Date
        {
            get
            {
                return base.Date;
            }
            set
            {
                base.Date = value;
            }
        }

        public override QuinielaLibrary.Catalogs.Enumerations.Result Result
        {
            get
            {
                return base.Result;
            }
            set
            {
                base.Result = value;
            }
        }
    }
}