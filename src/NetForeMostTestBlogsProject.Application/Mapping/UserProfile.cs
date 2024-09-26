using AutoMapper;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.APIs.Commands.AuthUsers;


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
        }
    }
}
