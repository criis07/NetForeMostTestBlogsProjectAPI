using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.DTO.Category;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Queries;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.Category;
using NetForeMostTestBlogsProject.Domain.Entities;

namespace NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _config;
        public CategoryService(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _config = configuration;
        }

        public async Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryCommand category)
        {
            var result = _applicationDbContext.categories.Add(new Category
            {
                Name = category.Name!,
                Description = category.Description!
            });

            await _applicationDbContext.SaveChangesAsync();
            return new CreateCategoryResponse { Success = true, Message = "Category created successfully" };
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.categories.ToListAsync(cancellationToken);
        }

        public async Task<GetCategoryDTO> GetCategoryByIdAsync(GetCategoryByIdQuery categoryInformation)
        {
            var category = await _applicationDbContext.categories.FirstOrDefaultAsync(x => x.CategoryId == categoryInformation.CategoryId);
            if (category == null)
            {
                return new GetCategoryDTO { Success = false, Message = "Blog not found" };
            }
            return new GetCategoryDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            };
        }
    }
}
