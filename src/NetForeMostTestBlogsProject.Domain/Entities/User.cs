using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetForeMostTestBlogsProject.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Avatar {  get; set; }
        public string? Status { get; set; }
        public bool Active { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public ICollection<BlogCategory> BlogCategories { get; set; } = new List<BlogCategory>();
    }
}
