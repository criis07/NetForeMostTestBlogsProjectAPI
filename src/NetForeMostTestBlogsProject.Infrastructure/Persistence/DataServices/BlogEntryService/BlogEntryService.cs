using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetForeMostTestBlogsProject.Application.DTO.BlogEntry;
using NetForeMostTestBlogsProject.Application.DTO.UserAuthentication;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Commands;
using NetForeMostTestBlogsProject.Application.Endpoints.BlogEntry.Queries;
using NetForeMostTestBlogsProject.Application.Interfaces.Persistence.DataServices.BlogEntry;
using NetForeMostTestBlogsProject.Domain.Entities;

namespace NetForeMostTestBlogsProject.Infrastructure.Persistence.DataServices.BlogEntryService
{
    public class BlogEntryService : IBlogEntryService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _config;
        public BlogEntryService(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _config = configuration;
        }

        public async Task<CreateBlogEntryResponse> CreateBlogEntryAsync(CreateBlogEntryCommand blog)
        {
            var result = _applicationDbContext.blogs.Add(new Blog
            {
                Title = blog.Title,
                Content = blog.Content,
                PublicationDate = DateTime.UtcNow,
                UserId = blog.UserId,
            });

            await _applicationDbContext.SaveChangesAsync();

            return new CreateBlogEntryResponse { Success = true, Message = "Entry created" };
        }

        public async Task<DeleteBlogEntryResponse> DeleteBlogEntryAsync(DeleteBlogEntryCommand blogInformation)
        {
            var blog = await _applicationDbContext.blogs.FirstOrDefaultAsync(c => c.BlogId == blogInformation.BlogId);
            if (blog == null)
            {
                return new DeleteBlogEntryResponse { Success = false, Message = "User not found" };
            }

            try
            {
                _applicationDbContext.blogs.Remove(blog!);
                await _applicationDbContext.SaveChangesAsync();
                return new DeleteBlogEntryResponse { Success = true, Message = "Successfully deleted" };
            }
            catch (Exception ex)
            {
                // Manejar la excepción (log, rethrow, etc.)
                return new DeleteBlogEntryResponse { Success = false, Message = "Error while deleting user: " + ex.Message };
            }
        }

        public async Task<IEnumerable<Blog>> GetAllBlogEntriesAsync(CancellationToken cancellationToken = default)
        {
            return await _applicationDbContext.blogs.ToListAsync(cancellationToken);
        }

        public async Task<GetBlogEntryDTO> GetBlogEntryByIdAsync(GetBlogEntryByIdQuery blogInformation)
        {
            var blog = await _applicationDbContext.blogs.FirstOrDefaultAsync(x => x.BlogId == blogInformation.BlogId);
            if (blog == null)
            {
                return new GetBlogEntryDTO { Success = false, Message = "Blog not found" };
            }
            return new GetBlogEntryDTO
            {
                BlogId = blog!.BlogId,
                Content = blog.Content,
                Title = blog.Title,
                PublicationDate  = blog.PublicationDate.ToString(),
                UserId = blog.UserId
            };
        }

        public async Task<UpdateBlogEntryResponse> UpdateBlogEntryAsync(UpdateBlogEntryCommand blogInformation)
        {
            var blog = await _applicationDbContext.blogs.FirstOrDefaultAsync(c => c.BlogId == blogInformation.BlogId);
            if (blog != null)
            {
                blog.Title = blogInformation.Title ?? blog.Title;
                blog.Content = blogInformation.Content ?? blog.Content;
                blog.UserId = blogInformation.UserId != 0 ? blogInformation.UserId : blog.UserId;

                try
                {
                    await _applicationDbContext.SaveChangesAsync();
                    return new UpdateBlogEntryResponse { Success = true, Message = "Successfully updated" };
                }
                catch (Exception ex)
                {
                    // Manejar excepción (log, rethrow, etc.)
                    return new UpdateBlogEntryResponse { Success = false, Message = "Error while updating Blog: " + ex.Message };
                }
            }
            return new UpdateBlogEntryResponse { Success = false, Message = "Blog not found" };
        }
    }
}
