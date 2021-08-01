using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Sigmade.Domain.Identity
{
    public class User : IdentityUser<Guid>
    {
        public DateTime DateCreated { get; set; }
        public bool IsBlocked { get; set; }

        public ICollection<UserRole> Roles { get; set; }
    }
}
