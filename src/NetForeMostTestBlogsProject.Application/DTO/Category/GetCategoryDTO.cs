using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetForeMostTestBlogsProject.Application.DTO.Category
{
    public class GetCategoryDTO : GenericResponse
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
