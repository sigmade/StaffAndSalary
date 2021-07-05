using System.Collections.Generic;

namespace Sigmade.Domain.Models
{
    public class WorkLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsHidden { get; set; }

        public ICollection<WorkTime> WorkTimes { get; set; }
    }
}
