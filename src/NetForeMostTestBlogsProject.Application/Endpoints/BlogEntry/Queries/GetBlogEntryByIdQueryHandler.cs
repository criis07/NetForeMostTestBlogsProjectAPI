using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.BlogEntry;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries
{
    public class GetBlogEntryByIdQueryHandler : IRequestHandler<GetBlogEntryByIdQuery, EndpointResult<GetBlogEntryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogEntryService _blogEntryService;
        public GetBlogEntryByIdQueryHandler(IMapper mapper, IBlogEntryService blogEntryService)
        {
            _blogEntryService = blogEntryService;
            _mapper = mapper;
        }
        public async Task<EndpointResult<GetBlogEntryDTO>> Handle(GetBlogEntryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _blogEntryService.GetBlogEntryByIdAsync(request);
            return new EndpointResult<GetBlogEntryDTO>(result);
        }
    }
}
