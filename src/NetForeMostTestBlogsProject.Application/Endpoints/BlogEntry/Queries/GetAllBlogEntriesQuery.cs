using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries
{
    public class GetAllBlogEntriesQuery : IRequest<EndpointResult<IEnumerable<GetBlogEntryDTO>>>
    {
    }
}
