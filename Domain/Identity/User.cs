using Microsoft.AspNetCore.Identity;
using System;

namespace Sigmade.Domain.Identity
{
    public class User : IdentityUser
    {
        public DateTime DateCreated { get; set; }
        public bool IsBlocked { get; set; }
    }
}
