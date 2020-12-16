using AutoMapper;
using ProjectManager.API.DTOs;
using ProjectManager.Core.Entities;

namespace ProjectManager.API.Configuration
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            #region User
            CreateMap<UserRegister, UserRegisterDto>();
            CreateMap<ExternalUser, ExternalUserDto>();
            CreateMap<UserLogin, UserLoginDto>();
            CreateMap<UserLoginTokenResponse, UserLoginTokenResponseDto>();
            CreateMap<UserToken, UserTokenDto>();
            CreateMap<UserClaim, UserClaimDto>();

            CreateMap<UserRegisterDto, UserRegister>();
            CreateMap<ExternalUserDto, ExternalUser>();
            CreateMap<UserLoginDto, UserLogin>();
            CreateMap<UserLoginTokenResponseDto, UserLoginTokenResponse>();
            CreateMap<UserTokenDto, UserToken>();
            CreateMap<UserClaimDto, UserClaim>();
            #endregion

            CreateMap<TaskDto, Task>();
            CreateMap<Task, TaskDto>();

            CreateMap<ProjectDto, Project>();
            CreateMap<Project, ProjectDto>();

            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();

            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();

        }
    }    
}
