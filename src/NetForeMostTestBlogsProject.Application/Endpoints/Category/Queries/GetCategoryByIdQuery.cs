using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.Category;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.Category.Queries
{
    public class GetCategoryByIdQuery : IRequest<EndpointResult<GetCategoryDTO>>
    {
        public int CategoryId { get; set; }
    }
}
