using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Application.Endpoints.UserAuthentication.Queries;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.User;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.Users.Queries.Users
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, EndpointResult<GetUserInfo>>
    {   private IMapper _mapper;
        private IUserService _userService;

        public GetUserInfoQueryHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService; 
        }

        public async Task<EndpointResult<GetUserInfo>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserInfoAsync(request.Id);

            return new EndpointResult<GetUserInfo>(result);
        }
    }
}
