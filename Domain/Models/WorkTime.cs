using System;

namespace Sigmade.Domain.Models
{
    public class WorkTime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PersonId { get; set; }
        public Worker Person { get; set; }
        public byte Hours { get; set; }
        public int WorkLocationId { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
