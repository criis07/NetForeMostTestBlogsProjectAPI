using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetForeMostTestBlogsProject.Application.DTO.Users;

namespace NetForeMostTestBlogsProject.Application.DTO.UserAuthentication
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; } = null!;
        public string? Token { get; set; } = null!;
        public GetUserInfo? user { get; set; }
    }
}
