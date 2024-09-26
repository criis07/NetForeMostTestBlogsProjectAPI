using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.DTO.Category;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.Category;
using NetForeMostTestBlogsProject.Application.Models;

namespace NetForeMostTestBlogsProject.Application.Endpoints.Category.Queries
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, EndpointResult<IEnumerable<GetCategoryDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        public GetAllCategoriesQueryHandler(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<EndpointResult<IEnumerable<GetCategoryDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAllCategoriesAsync(cancellationToken);
            var response = _mapper.Map<GetCategoryDTO[]>(result);

            return new EndpointResult<IEnumerable<GetCategoryDTO>>(response);   
        }
    }
}
