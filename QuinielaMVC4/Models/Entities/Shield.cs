using System;
namespace QuinielaMVC4.Models.Entities
{
    public class Shield
    {
        public Guid TeamId { get; set; }

        public byte[] Data { get; set; }
    }
}