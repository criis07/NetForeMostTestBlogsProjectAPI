using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;
using NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Commands;
using NetForeMostTestBlogsProject.Api.Extensions;
using NetForeMostTestBlogsProject.Application.Endpoints.APIs.Commands.AuthUsers;
using Microsoft.AspNetCore.Authorization;

namespace NetForeMostTestBlogsProject.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //Creamos nuestro punto de entrada para enviarlo a la clase handler por medio del mediator 
        [HttpPost]
        [Route("/api/user/login")]
        public async Task<ActionResult> LoginAuthMethod([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("/api/user/register")]
        public async Task<ActionResult> RegisterAuthMethod([FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPost]
        [Authorize]
        [Route("/api/sign-in-with-token")]
        public async Task<ActionResult> SignInWithAccessToken([FromBody] AccessWithTokenCommand accessToken)
        {
            var result = await _mediator.Send(accessToken);
            return result.ToActionResult();
        }

    }
}
