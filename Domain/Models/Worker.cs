using System;
using System.Collections.Generic;

namespace Sigmade.Domain.Models
{
    public class Worker
    {
        public long Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string PassportNumber { get; set; }
        public string SocialNumber { get; set; }
        public string TaxNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<WorkTime> WorkTimes { get; set; }
    }
}
