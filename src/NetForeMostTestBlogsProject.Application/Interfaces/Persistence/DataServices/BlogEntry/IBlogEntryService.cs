using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries;
using NetForeMostTestBlogsProject.Domain.Entities;

namespace NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.BlogEntry
{
    public interface IBlogEntryService
    {
        Task<CreateBlogEntryResponse> CreateBlogEntryAsync(CreateBlogEntryCommand blog);
        Task<UpdateBlogEntryResponse> UpdateBlogEntryAsync(UpdateBlogEntryCommand blog);
        Task<DeleteBlogEntryResponse> DeleteBlogEntryAsync(DeleteBlogEntryCommand blog);
        Task<IEnumerable<GetBlogEntryDTO>> GetAllBlogEntriesAsync(CancellationToken cancellationToken = default);
        Task<GetBlogEntryDTO> GetBlogEntryByIdAsync(GetBlogEntryByIdQuery blog);
    }
}
