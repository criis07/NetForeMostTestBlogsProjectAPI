using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetForeMostTestBlogsProject.Api.Extensions;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/api/blog")]
        [Authorize]
        public async Task<ActionResult> CreateBlogEntry([FromBody] CreateBlogEntryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpPut]
        [Route("/api/blog/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateBlogEntry([FromRoute] int id,[FromBody] CreateBlogEntryCommand Command)
        {
            var request = new UpdateBlogEntryCommand
            {
                BlogId = id,
                Content = Command.Content,
                Title = Command.Title,
                UserId = Command.UserId,
            };
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }

        [HttpDelete]
        [Route("/api/blog/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteBlogEntry([FromRoute] int id)
        {
            var request = new DeleteBlogEntryCommand
            {
                BlogId = id,
            };
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }

        [HttpGet]
        [Route("/api/blogs")]
        [Authorize]
        public async Task<ActionResult> GetAllBlogEntries()
        {
            var request = new GetAllBlogEntriesQuery();
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }

        [HttpGet]
        [Route("/api/blog/{id}")]
        [Authorize]
        public async Task<ActionResult> GetBlogEntryById([FromRoute] int id)
        {
            var request = new GetBlogEntryByIdQuery { BlogId = id };
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }
    }
}
