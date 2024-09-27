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
    public class UpdateBlogEntryCommand : IRequest<EndpointResult<UpdateBlogEntryResponse>>
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
    }
}
