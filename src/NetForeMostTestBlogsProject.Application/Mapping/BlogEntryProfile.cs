using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Commands;
using NetForeMostTestBlogsProject.Domain.Entities;

namespace NetForeMostTestBlogsProject.Application.Mapping
{
    public class BlogEntryProfile : Profile
    {
        public BlogEntryProfile()
        {
            CreateMap<Blog, GetBlogEntryDTO>()
            .ForMember(ldt => ldt.UserId, lg => lg.MapFrom(src => src.UserId))
            .ForMember(ldt => ldt.Title, lg => lg.MapFrom(src => src.Title))
            .ForMember(ldt => ldt.BlogId, lg => lg.MapFrom(src => src.BlogId))
            .ForMember(ldt => ldt.Content, lg => lg.MapFrom(src => src.Content))
            .ForMember(ldt => ldt.PublicationDate, lg => lg.MapFrom(src => src.PublicationDate));
        }
    }
}
