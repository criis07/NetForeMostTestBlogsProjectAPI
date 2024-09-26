using Microsoft.EntityFrameworkCore;
using Moq;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;
using NetForeMostTestBlogsProject.Domain.Entities;
using NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.UserService;
using NetForeMostTestBlogsProject.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.BlogEntryService;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands;

namespace NetForeMostProjetcUnitTesting.Services
{
    public class BlogUnitTesting
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly Mock<IPrincipalService> _principalServiceMock;
        private readonly Mock<IDateTimeService> _dateTimeServiceMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly BlogEntryService _blogEntryService;
        private readonly UserService _userService;

        public BlogUnitTesting()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Asegura una base de datos en memoria nueva para cada prueba
                .Options;
            _principalServiceMock = new Mock<IPrincipalService>();
            _dateTimeServiceMock = new Mock<IDateTimeService>();
            _configMock = new Mock<IConfiguration>();

            // Inicializa el servicio con el contexto en memoria y los mocks necesarios
            _blogEntryService = new BlogEntryService(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), _configMock.Object);
            _userService = new UserService(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), _configMock.Object);
        }

        private async Task SeedData(ApplicationDbContext context, Blog blog)
        {
            context.blogs.Add(blog);
            await context.SaveChangesAsync();

        }

        private async Task SeedDataForUser(ApplicationDbContext context, User user)
        {
            context.users.Add(user);
            await context.SaveChangesAsync();

        }

        [Fact]
        public async Task BlogReturnAllTheDataForASingleRegister_Successfully()
        {
            var blog = new Blog
            {
                UserId = 1,
                Title = "Test title",
                Content = "Test content",
                PublicationDate = DateTime.UtcNow,
                BlogId = 1
            };

            await SeedData(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), blog);

            var blogData = new GetBlogEntryByIdQuery { BlogId = 1 };

            var result = await _blogEntryService.GetBlogEntryByIdAsync(blogData);

            Assert.NotNull(result.Title);
            Assert.NotNull(result.Content);
            Assert.NotNull(result.PublicationDate);
            Assert.NotNull(result.BlogId);
            Assert.NotNull(result.UserId);
        }

        [Fact]
        public async Task BlogEntryCreation_Successfully()
        {

            // Arrange
            var user = new User
            {
                Id = 1,
                Name = "Cristian",
                LastName = "Rojas",
                Email = "criisuser07@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("1234") // Asumiendo que la contraseña está encriptada
            };
            await SeedDataForUser(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), user);
            // Arrange
            var newBlog = new CreateBlogEntryCommand
            {
                UserId = 1,
                Title = "New Blog Title",
                Content = "New blog content"
            };

            // Act
            await _blogEntryService.CreateBlogEntryAsync(newBlog);

            // Assert
            using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
            {
                var blogFromDb = await context.blogs
                    .FirstOrDefaultAsync(b => b.UserId == newBlog.UserId && b.Title == newBlog.Title);

                Assert.NotNull(blogFromDb);
                Assert.Equal(newBlog.Title, blogFromDb.Title);
                Assert.Equal(newBlog.Content, blogFromDb.Content);
            }
        }

    }
}
