using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;
using NetForeMostTestBlogsProject.Domain.Entities;
using NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.UserService;
using NetForeMostTestBlogsProject.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.CategoryService;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Queries;
using System.Reflection.Metadata;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Commands;

namespace NetForeMostProjetcUnitTesting.Services
{
    public class CategoryUnitTesting
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly Mock<IPrincipalService> _principalServiceMock;
        private readonly Mock<IDateTimeService> _dateTimeServiceMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly CategoryService _categoryService;

        public CategoryUnitTesting()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Asegura una base de datos en memoria nueva para cada prueba
                .Options;
            _principalServiceMock = new Mock<IPrincipalService>();
            _dateTimeServiceMock = new Mock<IDateTimeService>();
            _configMock = new Mock<IConfiguration>();

            // Inicializa el servicio con el contexto en memoria y los mocks necesarios
            _categoryService = new CategoryService(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), _configMock.Object);
        }

        private async Task SeedData(ApplicationDbContext context, Category category)
        {
            context.categories.Add(category);
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task CategoryReturnAllTheDataForASingleRegister_Successfully()
        {

            var category = new Category { Name = "Test name", Description = "Test description" };

            await SeedData(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), category);

            var categoryData = new GetCategoryByIdQuery { CategoryId = 1 };

            var result = await _categoryService.GetCategoryByIdAsync(categoryData);

            Assert.NotNull(result.CategoryId);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Description);
        }

        [Fact]
        public async Task CategoryCreation_Successfully()
        {
            // Arrange
            var newCategory = new CreateCategoryCommand
            {
                Name = "New Category",
                Description = "New category description"
            };

            // Act
            await _categoryService.CreateCategoryAsync(newCategory);

            // Assert
            using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
            {
                var categoryFromDb = await context.categories
                    .FirstOrDefaultAsync(c => c.Name == newCategory.Name && c.Description == newCategory.Description);

                Assert.NotNull(categoryFromDb);
                Assert.Equal(newCategory.Name, categoryFromDb.Name);
                Assert.Equal(newCategory.Description, categoryFromDb.Description);
            }
        }

    }
}
