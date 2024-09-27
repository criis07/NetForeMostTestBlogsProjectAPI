using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetForeMostTestBlogsProject.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }

        // Relación muchos a uno: cada blog tiene un autor (usuario)
        public int UserId { get; set; }
        public User? Author { get; set; }

        // Relación muchos a muchos con categorías
        public ICollection<BlogCategory> BlogCategories { get; set; } = new List<BlogCategory>();
    }

}
