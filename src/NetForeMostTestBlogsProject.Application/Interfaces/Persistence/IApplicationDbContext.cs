using NetForeMostTestBlogsProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NetForeMostTestBlogsProject.Application.Interfaces.Persistence;

public interface IApplicationDbContext
{

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
