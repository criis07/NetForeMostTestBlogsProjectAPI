
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetForeMostTestBlogsProject.Domain.Entities;

namespace NetForeMostTestBlogsProject.Infrastructure.Persistence.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.LastName).HasMaxLength(25);

            builder.Property(x=> x.Password).HasMaxLength(150);
        }
    }
}
