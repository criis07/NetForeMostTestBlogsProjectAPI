using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetForeMostTestBlogsProject.Application.DTO.Users;

namespace NetForeMostTestBlogsProject.Application.DTO.UserAuthentication
{
    public class UpdateUserDTO : RegisterUserDTO
    {
        public int id {  get; set; }
    }
}
