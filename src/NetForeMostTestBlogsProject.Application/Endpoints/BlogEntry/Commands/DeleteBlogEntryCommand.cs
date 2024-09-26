using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands
{
    public class DeleteBlogEntryCommand : IRequest<EndpointResult<DeleteBlogEntryResponse>>
    {
        public int BlogId { get; set; }
    }
}
