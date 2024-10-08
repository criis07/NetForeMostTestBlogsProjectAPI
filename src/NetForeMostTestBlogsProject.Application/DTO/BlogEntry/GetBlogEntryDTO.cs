using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetForeMostTestBlogsProject.Domain.Entities;

namespace NetForeMostTestBlogsProject.Application.DTO.BlogEntry
{
    public class GetBlogEntryDTO : GenericResponse
    {
        public int? BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? PublicationDate { get; set; }
        public int? UserId { get; set; }
        public IEnumerable<string>? CategoryNames { get; set; }
    }
}
