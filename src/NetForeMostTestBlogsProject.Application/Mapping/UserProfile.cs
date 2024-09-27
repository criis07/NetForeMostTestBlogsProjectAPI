using AutoMapper;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.APIs.Commands.AuthUsers;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;


namespace NetForeMostTestBlogsProject.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginCommand, LoginDTO>()
                .ForMember(ldt => ldt.Email, lg => lg.MapFrom(src => src.Email))
                .ForMember(ldt => ldt.Password, lg => lg.MapFrom(src => src.Password));

            CreateMap<RegisterCommand, RegisterUserDTO>()
                .ForMember(rdt => rdt.Email, lg => lg.MapFrom(src => src.Email))
                .ForMember(rdt => rdt.Password, lg => lg.MapFrom(src => src.Password))
                .ForMember(rdt => rdt.Name, lg => lg.MapFrom(src => src.Name))
                .ForMember(rdt => rdt.LastName, lg => lg.MapFrom(src => src.LastName))
                .ForMember(rdt => rdt.ConfirmPassword, lg => lg.MapFrom(src => src.ConfirmPassword));

            CreateMap<UpdateUserCommand, UpdateUserDTO>()
                .ForMember(ctu => ctu.id, lg => lg.MapFrom(src => src.id))
                .ForMember(ctu => ctu.Name, lg => lg.MapFrom(src => src.Name))
                .ForMember(ctu => ctu.LastName, lg => lg.MapFrom(src => src.LastName))
                .ForMember(ctu => ctu.Email, lg => lg.MapFrom(src => src.Email))
                .ForMember(ctu => ctu.Password, lg => lg.MapFrom(src => src.Password));
        }
    }
}
