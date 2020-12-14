using Microsoft.AspNetCore.Identity;
using ProjectManager.Core.Entities;
using System;

namespace ProjectManager.Core.Extensions
{
    public class ApplicationUser : IdentityUser
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Provider { get; set; } = "LOCAL";
        public string ExternalUserId { get; set; }

        public Person Person { get; set; }
    }
}
