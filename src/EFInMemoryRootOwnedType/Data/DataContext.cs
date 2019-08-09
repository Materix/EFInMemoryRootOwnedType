using EFInMemoryRootOwnedType.Model;
using Microsoft.EntityFrameworkCore;

namespace EFInMemoryRootOwnedType.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.HasMany(e => e.Names).WithOne(e => e.Person).HasPrincipalKey(e => e.Id).HasForeignKey(e => e.PersonId);
                builder.OwnsOne(e => e.Comment);
            });

            modelBuilder.Entity<PersonNames>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.OwnsOne(e => e.Value);
            });
        }
    }
}