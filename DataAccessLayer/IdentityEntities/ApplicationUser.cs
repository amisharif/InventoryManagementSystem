using Microsoft.AspNetCore.Identity;
using System;

namespace DataAccessLayer.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; }
    }
}
