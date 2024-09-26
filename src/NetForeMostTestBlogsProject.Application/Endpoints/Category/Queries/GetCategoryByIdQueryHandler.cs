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

namespace NetForeMostTestBlogsProject.Application.Endpoints.Category.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, EndpointResult<GetCategoryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public GetCategoryByIdQueryHandler(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<EndpointResult<GetCategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetCategoryByIdAsync(request);
            return new EndpointResult<GetCategoryDTO>(result);

        }
    }
}
