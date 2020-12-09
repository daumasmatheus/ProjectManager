using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.API.ViewModels;
using ProjectManager.Core.BaseClasses;
using ProjectManager.Core.Extensions;
using ProjectManager.Core.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.API.Controllers
{
    [Route("api/authentication")]
    public class AuthController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthController(SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IAuthenticationService authenticationService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Efetua o registro de um novo usuário 
        /// </summary>
        /// <param name="userRegister">Dados do usuário para registro no banco de dados</param>
        /// <returns>Dados de autenticação e autorização (jwt token e claims) do usuário</returns>
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]UserRegisterViewModel userRegister)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new ApplicationUser
            {
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = true                
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded) return CustomResponse(await _authenticationService.GenerateJWT(userRegister.Email));

            foreach (var error in result.Errors)
            {
                AddProccessError(error.Description);
            }

            return CustomResponse();
        }

        /// <summary>
        /// Efetua o login do usuário registrado
        /// </summary>
        /// <param name="userLogin">Dados para o login do usuário</param>
        /// <returns>Dados de autenticação e autorização (jwt token e claims) do usuário</returns>
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginViewModel userLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await _authenticationService.GenerateJWT(userLogin.Email));
            }

            if (result.IsLockedOut)
            {
                AddProccessError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            AddProccessError("Usuário ou senha incorretos");
            return CustomResponse();
        }

        [HttpPost("external-auth")]
        public async Task<ActionResult> ExternalAuth([FromBody]ExternalUserViewModel externalUser)
        {
            var user = _userManager.Users.Where(x => x.ExternalUserId == externalUser.ExternalUserId).FirstOrDefault();

            if (user != null)
            {
                return CustomResponse(await _authenticationService.GenerateJWT(user.Email));
            }
            else
            {
                var newUser = new ApplicationUser
                {
                    FirstName = externalUser.FirstName,
                    LastName = externalUser.LastName,
                    UserName = externalUser.Email,
                    Email = externalUser.Email,
                    Provider = externalUser.Provider,
                    ExternalUserId = externalUser.ExternalUserId
                };

                var result = await _userManager.CreateAsync(newUser);

                if (result.Succeeded) return CustomResponse(await _authenticationService.GenerateJWT(externalUser.Email));

                foreach (var error in result.Errors)
                {
                    AddProccessError(error.Description);
                }

                return CustomResponse();
            }
        }
    }
}
