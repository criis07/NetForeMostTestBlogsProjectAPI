using System.Reflection;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;
using NetForeMostTestBlogsProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetForeMostTestBlogsProject.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IPrincipalService _principalService;
    private readonly IDateTimeService _dateTimeService;

    public DbSet<User> users { get; set; } = null!;
    public DbSet<Blog> blogs { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IPrincipalService principalService,
        IDateTimeService dateTimeService) : base(options)
    {
        _principalService = principalService;
        _dateTimeService = dateTimeService;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
    //Constructor de nuestra estructura de datos
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.SeedData();
    }
}
