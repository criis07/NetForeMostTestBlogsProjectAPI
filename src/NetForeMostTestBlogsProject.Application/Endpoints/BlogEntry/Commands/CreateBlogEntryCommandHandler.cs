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

namespace NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands
{
    public class CreateBlogEntryCommandHandler : IRequestHandler<CreateBlogEntryCommand, EndpointResult<CreateBlogEntryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogEntryService _blogEntryService;

        public CreateBlogEntryCommandHandler(IMapper mapper, IBlogEntryService blogEntryService)
        {
            _mapper = mapper;
            _blogEntryService = blogEntryService;
        }
        public async Task<EndpointResult<CreateBlogEntryResponse>> Handle(CreateBlogEntryCommand request, CancellationToken cancellationToken)
        {
            var result = await _blogEntryService.CreateBlogEntryAsync(request);

            return new EndpointResult<CreateBlogEntryResponse>(result);
        }
    }
}
