using ProjectManager.Authentication.ViewModels;
using System.Threading.Tasks;

namespace ProjectManager.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task<UserLoginTokenResponse> GenerateJWT(string email);
    }
}
