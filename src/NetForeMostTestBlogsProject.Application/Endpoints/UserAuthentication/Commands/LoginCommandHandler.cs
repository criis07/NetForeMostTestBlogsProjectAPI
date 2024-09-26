using AutoMapper;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Commands;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.User;
using NetForeMostTestBlogsProject.Application.Models;


namespace Project4.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, EndpointResult<LoginResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public LoginCommandHandler(IMapper mapper, IUserService userService, IMediator mediator)
        {
            _mapper = mapper;
            _userService = userService;
            _mediator = mediator;
        }
        public async Task<EndpointResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var logRequest = _mapper.Map<LoginDTO>(request);
            var logMethod = await _userService.LoginUserAsync(logRequest);
            return new EndpointResult<LoginResponse>(logMethod);
        }
    }
}
