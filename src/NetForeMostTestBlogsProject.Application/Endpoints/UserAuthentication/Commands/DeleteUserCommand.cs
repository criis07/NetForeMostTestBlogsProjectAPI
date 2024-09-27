using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Commands
{
    public class DeleteUserCommand : IRequest<EndpointResult<DeleteUserResponse>>
    {
        public int id { get; set; }
    }
}
