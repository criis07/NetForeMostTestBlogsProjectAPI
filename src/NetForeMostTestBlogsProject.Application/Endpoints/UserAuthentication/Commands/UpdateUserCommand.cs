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
    public class UpdateUserCommand : IRequest<EndpointResult<UpdateUserResponse>>
    {
        public int id { get; set; }
        public string? Name { get; set; }  
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
