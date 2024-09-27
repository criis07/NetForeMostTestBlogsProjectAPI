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
    public class UpdateBlogEntryCommandHandler : IRequestHandler<UpdateBlogEntryCommand, EndpointResult<UpdateBlogEntryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogEntryService _blogEntryService;

        public UpdateBlogEntryCommandHandler(IMapper mapper, IBlogEntryService blogEntryService)
        {
            _blogEntryService = blogEntryService;
            _mapper = mapper;
        }

        public async Task<EndpointResult<UpdateBlogEntryResponse>> Handle(UpdateBlogEntryCommand request, CancellationToken cancellationToken)
        {
            var result = await _blogEntryService.UpdateBlogEntryAsync(request);
            return new EndpointResult<UpdateBlogEntryResponse>(result);
        }
    }
}
