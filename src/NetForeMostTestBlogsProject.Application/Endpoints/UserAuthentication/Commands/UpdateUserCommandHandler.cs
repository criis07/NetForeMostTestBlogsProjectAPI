using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.User;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, EndpointResult<UpdateUserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<EndpointResult<UpdateUserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUser = _mapper.Map<UpdateUserDTO>(request);
            var result = await _userService.UpdateUserAsync(updateUser);
            return new EndpointResult<UpdateUserResponse>(result);
        }
    }
}
