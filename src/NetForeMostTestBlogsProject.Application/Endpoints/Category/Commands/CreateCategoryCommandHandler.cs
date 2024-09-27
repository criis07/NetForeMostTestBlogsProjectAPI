using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.Category;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.Category;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.Category.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, EndpointResult<CreateCategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public CreateCategoryCommandHandler(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<EndpointResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.CreateCategoryAsync(request);

            return new EndpointResult<CreateCategoryResponse>(result);
        }
    }
}
