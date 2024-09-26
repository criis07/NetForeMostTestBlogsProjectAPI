using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetForeMostTestBlogsProject.Application.DTO
{
    public class GenericResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; } = null!;
    }
}
