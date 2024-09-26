using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetForeMostTestBlogsProject.Api.Extensions;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.Category.Queries;

namespace NetForeMostTestBlogsProject.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/api/category")]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result.ToActionResult();
        }

        [HttpGet]
        [Route("/api/categories")]
        public async Task<ActionResult> GetAllCategories()
        {
            var request = new GetAllCategoriesQuery();
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }

        [HttpGet]
        [Route("/api/category/{id}")]
        public async Task<ActionResult> GetCategoryById([FromRoute] int id)
        {
            var request = new GetCategoryByIdQuery { CategoryId = id };
            var result = await _mediator.Send(request);
            return result.ToActionResult();
        }
    }
}
