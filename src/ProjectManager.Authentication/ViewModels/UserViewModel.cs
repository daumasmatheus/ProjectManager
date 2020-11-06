using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Authentication.ViewModels
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Entre com pelo menos 2 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Entre com pelo menos 2 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [EmailAddress(ErrorMessage = "Campo {0} com formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(100, ErrorMessage = "A senha deve ter entre {2} e {1}", MinimumLength = 8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string PasswordConfirmation { get; set; }
    }

    public class UserLogin
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [EmailAddress(ErrorMessage = "Campo {0} com formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(100, ErrorMessage = "A senha deve ter entre {2} e {1}", MinimumLength = 8)]
        public string Password { get; set; }
    }

    public class UserLoginTokenResponse
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }

    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
