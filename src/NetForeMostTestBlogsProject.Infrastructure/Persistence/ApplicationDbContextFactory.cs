using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NetForeMostTestBlogsProject.Infrastructure.Persistence;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;
using System.IO;

namespace NetForeMostTestBlogsProject.Infrastructure.Persistence
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!, x => x.MigrationsAssembly("NetForeMostTestBlogsProject.Api"));

            // Crea instancias predeterminadas de los servicios necesarios
            var principalService = new DefaultPrincipalService();
            var dateTimeService = new DefaultDateTimeService();

            return new ApplicationDbContext(optionsBuilder.Options, principalService, dateTimeService);
        }
    }

    // Implementaciones predeterminadas
    public class DefaultPrincipalService : IPrincipalService
    {
        public int UserId => 1;
    }

    public class DefaultDateTimeService : IDateTimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
