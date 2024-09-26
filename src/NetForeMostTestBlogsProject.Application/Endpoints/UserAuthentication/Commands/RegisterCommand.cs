using System.ComponentModel.DataAnnotations;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class RegisterCommand : IRequest<EndpointResult<RegistrationResponse>>
    {

        public string? Name { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string? ConfirmPassword { get; set; } = string.Empty;
    }
}
