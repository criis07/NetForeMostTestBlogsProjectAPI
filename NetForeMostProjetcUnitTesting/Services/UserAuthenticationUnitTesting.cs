using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.Extensions.Configuration;
using NetForeMostTestBlogsProject.Domain.Entities;
using NetForeMostTestBlogsProject.Application.DTO.Users;
using NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.UserService;
using NetForeMostTestBlogsProject.Infrastructure.Persistence;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;

namespace NetForeMostProjetcUnitTesting.Services
{
    public class UserAuthenticationUnitTesting
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly Mock<IPrincipalService> _principalServiceMock;
        private readonly Mock<IDateTimeService> _dateTimeServiceMock;
        private readonly Mock<IConfiguration> _configMock;
        private readonly UserService _userService;

        public UserAuthenticationUnitTesting()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Asegura una base de datos en memoria nueva para cada prueba
                .Options;
            _principalServiceMock = new Mock<IPrincipalService>();
            _dateTimeServiceMock = new Mock<IDateTimeService>();
            _configMock = new Mock<IConfiguration>();
            _configMock.Setup(config => config["Jwt:Key"]).Returns("cgD-mc07J1q686Lo}0iM£W0348J5u4GC<goS");

            // Inicializa el servicio con el contexto en memoria y los mocks necesarios
            _userService = new UserService(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), _configMock.Object);
        }

        private async Task SeedData(ApplicationDbContext context, User user)
        {
            context.users.Add(user);
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task LoginUser_ReturnsSuccess_WhenCredentialsAreValid()
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
            await SeedData(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object), user);

            var loginDTO = new LoginDTO
            {
                Email = "criisuser07@gmail.com",
                Password = "1234"
            };

            // Act
            var result = await _userService.LoginUserAsync(loginDTO);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task LoginUser_ReturnsFailure_WhenCredentialsAreInvalid()
        {
            // Arrange
            await SeedData(new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object),
                new User
                {
                    Id = 1,
                    Name = "Cristian",
                    LastName = "Rojas",
                    Email = "criisuser07@gmail.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("1234")
                });

            var loginDTO = new LoginDTO
            {
                Email = "criisuser07@gmail.com",
                Password = "wrong_password" // Contraseña incorrecta
            };

            // Act
            var result = await _userService.LoginUserAsync(loginDTO);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid credentials", result.Message);
            Assert.Null(result.Token);
        }
    }
}
