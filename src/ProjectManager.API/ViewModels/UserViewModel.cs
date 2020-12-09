using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.API.ViewModels
{
    public class UserRegisterViewModel
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

    public class ExternalUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Provider { get; set; }
        public string ExternalUserId { get; set; }
    }

    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [EmailAddress(ErrorMessage = "Campo {0} com formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} obrigatório")]
        [StringLength(100, ErrorMessage = "A senha deve ter entre {2} e {1}", MinimumLength = 8)]
        public string Password { get; set; }
    }

    public class UserLoginTokenResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel UserToken { get; set; }
    }

    public class UserTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<UserClaimViewModel> Claims { get; set; }
    }

    public class UserClaimViewModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
