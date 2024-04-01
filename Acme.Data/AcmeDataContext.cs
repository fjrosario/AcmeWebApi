using Microsoft.EntityFrameworkCore;

namespace Acme.Data
{
    public class AcmeDataContext : DbContext, IAcmeDataContext
    {
        public AcmeDataContext(DbContextOptions<AcmeDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseInMemoryDatabase(databaseName: "Acme");

        }

        public virtual DbSet<Models.Order> Orders { get; set; }
        public virtual DbSet<Models.Address> Addresses { get; set; }

        public virtual DbSet<Models.Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
