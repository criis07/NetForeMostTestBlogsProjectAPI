using System.Globalization;
using System.Security.Claims;
using NetForeMostTestBlogsProject.Api.Exceptions;
using NetForeMostTestBlogsProject.Application.Interfaces.Services;

namespace NetForeMostTestBlogsProject.Api.Services;

public class PrincipalService : IPrincipalService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public PrincipalService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int UserId
    {
        get
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
            if (claimsPrincipal == null)
                throw new MissingClaimsPrincipalException();

            return int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0", CultureInfo.CurrentCulture);
        }
    }
}
