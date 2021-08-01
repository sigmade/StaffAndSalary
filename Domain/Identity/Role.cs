using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Sigmade.Domain.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public ICollection<UserRole> Users { get; set; }
    }
}
