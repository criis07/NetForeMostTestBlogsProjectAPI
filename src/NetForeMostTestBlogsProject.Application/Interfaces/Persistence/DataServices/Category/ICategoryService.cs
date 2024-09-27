using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetForeMostTestBlogsProject.Application.DTO.Category;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Queries;
using NetForeMostTestBlogsProject.Domain.Entities;

namespace NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.Category
{
    public interface ICategoryService
    {
        Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryCommand category);
        Task<IEnumerable<Domain.Entities.Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
        Task<GetCategoryDTO> GetCategoryByIdAsync(GetCategoryByIdQuery category);
    }
}
