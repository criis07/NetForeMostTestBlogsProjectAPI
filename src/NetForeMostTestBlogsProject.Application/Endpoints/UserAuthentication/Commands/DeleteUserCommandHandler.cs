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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, EndpointResult<DeleteUserResponse>>
    {
        private IMapper _mapper;
        private IUserService _userService;
        public DeleteUserCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<EndpointResult<DeleteUserResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUserAsync(request.id);
            return new EndpointResult<DeleteUserResponse>(result);
        }
    }
}
