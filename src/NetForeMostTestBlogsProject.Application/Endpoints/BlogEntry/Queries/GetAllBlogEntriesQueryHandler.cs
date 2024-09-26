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
    public class GetAllBlogEntriesQueryHandler : IRequestHandler<GetAllBlogEntriesQuery, EndpointResult<IEnumerable<GetBlogEntryDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogEntryService _blogEntryService;
        public GetAllBlogEntriesQueryHandler(IMapper mapper, IBlogEntryService blogEntryService)
        {
            _blogEntryService = blogEntryService;
            _mapper = mapper;
        }
        public async Task<EndpointResult<IEnumerable<GetBlogEntryDTO>>> Handle(GetAllBlogEntriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _blogEntryService.GetAllBlogEntriesAsync(cancellationToken);
            var response = _mapper.Map<GetBlogEntryDTO[]>(result);
            return new EndpointResult<IEnumerable<GetBlogEntryDTO>>(response);
        }
    }
}
