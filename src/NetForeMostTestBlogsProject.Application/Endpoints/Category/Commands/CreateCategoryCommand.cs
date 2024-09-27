using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NetForeMostTestBlogsProject.Application.DTO.Category;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.Category.Commands
{
    public class CreateCategoryCommand : IRequest<EndpointResult<CreateCategoryResponse>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
