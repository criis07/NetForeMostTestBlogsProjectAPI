using AutoMapper;
using NetForeMostTestBlogsProject.Application.Mapping;
using Xunit;

namespace NetForeMostTestBlogsProject.Application.Tests.Mapping;

public class PeopleProfileTests
{
    [Fact]
    public void VerifyConfiguration()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<PeopleProfile>());

        configuration.AssertConfigurationIsValid();
    }
}
