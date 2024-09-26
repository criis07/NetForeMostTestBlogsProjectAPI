using AutoMapper;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.User;
using NetForeMostTestBlogsProject.Application.Models;


namespace NetForeMostTestBlogsProject.Application.Endpoints.APIs.Commands.AuthUsers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, EndpointResult<RegistrationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public RegisterCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<EndpointResult<RegistrationResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var logRequest = _mapper.Map<RegisterUserDTO>(request);
            var logMethod = await _userService.RegisterUserAsync(logRequest);

            return new EndpointResult<RegistrationResponse>(logMethod);
        }
    }
}
