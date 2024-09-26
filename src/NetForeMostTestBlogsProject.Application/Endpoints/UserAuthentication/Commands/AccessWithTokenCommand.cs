using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class AccessWithTokenCommand : IRequest<EndpointResult<LoginResponse>>
    {
        public string? AccessToken { get; set; }
    }
}
