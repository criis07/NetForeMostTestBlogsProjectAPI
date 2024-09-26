using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetForeMostTestBlogsProject.Domain.Entities
{
    public class BlogCategory
    {
        public int BlogId { get; set; }
        [JsonIgnore]
        public Blog? Blog { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
    }

}
