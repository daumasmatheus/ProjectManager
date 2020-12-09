using Microsoft.AspNetCore.Identity;
using System.Security.Policy;

namespace ProjectManager.Core.Extensions
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Provider { get; set; } = "LOCAL";
        public string ExternalUserId { get; set; }
    }
}
