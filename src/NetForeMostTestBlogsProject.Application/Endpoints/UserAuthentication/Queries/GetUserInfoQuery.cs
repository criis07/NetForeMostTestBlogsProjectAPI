using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Queries
{
    public class GetUserInfoQuery : IRequest<EndpointResult<GetUserInfo>>
    {
        public int Id { get; set; }
    }
}
