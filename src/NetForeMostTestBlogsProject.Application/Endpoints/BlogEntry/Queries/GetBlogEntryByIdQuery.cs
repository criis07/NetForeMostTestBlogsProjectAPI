using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries
{
    public class GetBlogEntryByIdQuery : IRequest<EndpointResult<GetBlogEntryDTO>>
    {
        public int BlogId { get; set; }
    }
}
