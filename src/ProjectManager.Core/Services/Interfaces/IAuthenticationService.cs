using ProjectManager.Core.Entities;
using System.Threading.Tasks;

namespace ProjectManager.Core.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserLoginTokenResponse> GenerateJWT(string email);
    }
}
