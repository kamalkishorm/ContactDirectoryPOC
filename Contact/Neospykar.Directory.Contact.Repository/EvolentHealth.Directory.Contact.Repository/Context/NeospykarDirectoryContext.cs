using Microsoft.EntityFrameworkCore;

namespace Neospykar.Directory.Contact.Repository.Context
{
    public partial class NeospykarDirectoryContext : DbContext
    {
        public NeospykarDirectoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Contact>(ConfigureContact);
        }
    }
}
