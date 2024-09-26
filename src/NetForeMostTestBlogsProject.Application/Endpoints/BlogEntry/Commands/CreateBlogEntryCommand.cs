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
    public class CreateBlogEntryCommand : IRequest<EndpointResult<CreateBlogEntryResponse>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
