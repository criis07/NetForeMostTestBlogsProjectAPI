using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.BlogEntry;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands
{
    public class DeleteBlogEntryCommandHandler : IRequestHandler<DeleteBlogEntryCommand, EndpointResult<DeleteBlogEntryResponse>>
    {
        private readonly IMediator _mediator;
        private readonly IBlogEntryService _blogEntryService;
        public DeleteBlogEntryCommandHandler(IMediator mediator, IBlogEntryService blogEntryService)
        {
            _blogEntryService = blogEntryService;
            _mediator = mediator;
        }
        public async Task<EndpointResult<DeleteBlogEntryResponse>> Handle(DeleteBlogEntryCommand request, CancellationToken cancellationToken)
        {
            var result = await _blogEntryService.DeleteBlogEntryAsync(request);
            return new EndpointResult<DeleteBlogEntryResponse>(result);
        }
    }
}
