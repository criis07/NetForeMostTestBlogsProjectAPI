using System.Diagnostics.CodeAnalysis;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;

namespace NetForeMostTestBlogsProject.Infrastructure.Services;

[ExcludeFromCodeCoverage]
public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}
