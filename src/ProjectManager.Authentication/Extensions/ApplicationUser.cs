using Microsoft.AspNetCore.Identity;

namespace ProjectManager.Authentication.Extensions
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsPersonalDataFilled { get; set; }
    }
}
