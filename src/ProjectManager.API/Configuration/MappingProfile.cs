using AutoMapper;
using ProjectManager.API.ViewModels;
using ProjectManager.Core.Entities;

namespace ProjectManager.API.Configuration
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            #region User
            CreateMap<UserRegister, UserRegisterViewModel>();
            CreateMap<ExternalUser, ExternalUserViewModel>();
            CreateMap<UserLogin, UserLoginViewModel>();
            CreateMap<UserLoginTokenResponse, UserLoginTokenResponseViewModel>();
            CreateMap<UserToken, UserTokenViewModel>();
            CreateMap<UserClaim, UserClaimViewModel>();

            CreateMap<UserRegisterViewModel, UserRegister>();
            CreateMap<ExternalUserViewModel, ExternalUser>();
            CreateMap<UserLoginViewModel, UserLogin>();
            CreateMap<UserLoginTokenResponseViewModel, UserLoginTokenResponse>();
            CreateMap<UserTokenViewModel, UserToken>();
            CreateMap<UserClaimViewModel, UserClaim>();
            #endregion
        }
    }    
}
