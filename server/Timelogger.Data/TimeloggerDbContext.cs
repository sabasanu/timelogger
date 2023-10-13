using Microsoft.EntityFrameworkCore;
using Timelogger.Domain;

namespace Timelogger.Data
{
    public class TimeloggerDbContext : DbContext
    {
        private readonly IIdentityProvider _identityProvider;

        public TimeloggerDbContext(DbContextOptions<TimeloggerDbContext> dbContextOptions, IIdentityProvider identityProvider)
            :base(dbContextOptions)
        {
            _identityProvider = identityProvider;
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<TimeRegistration> TimeRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TimeloggerDbContext).Assembly);
            modelBuilder.Entity<Customer>().HasQueryFilter(c => c.UserId == _identityProvider.UserId);
            modelBuilder.Entity<Project>().HasQueryFilter(c => c.UserId == _identityProvider.UserId);
        }
    }
}
