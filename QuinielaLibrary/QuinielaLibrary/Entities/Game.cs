using QuinielaLibrary.Catalogs;
using System;

namespace QuinielaLibrary.Entities
{
    public class Game
    {
        public virtual Guid Id { get; set; }

        public virtual Guid LocalId { get; set; }

        public virtual Team Local { get; set; }

        public virtual Guid VisitorId { get; set; }

        public virtual Team Visitor { get; set; }

        public virtual Score Score { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual QuinielaLibrary.Catalogs.Enumerations.Result Result { get; set; }

        
    }
}
