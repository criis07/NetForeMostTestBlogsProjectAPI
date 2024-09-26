using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;
using NetForeMostTestBlogsProject.Application.DTO.Users;

namespace NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.User
{
    public interface IUserService
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO user);
        Task<LoginResponse> LoginUserAsync(LoginDTO loginData);
        Task<GetUserInfo> GetUserInfoAsync(int id);
        Task<LoginResponse>SignInWithTokenAsync(string accessToken);
    }
}
