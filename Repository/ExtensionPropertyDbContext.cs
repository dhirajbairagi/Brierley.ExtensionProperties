using Brierley.ExtensionPropertyManager.Models;
using Brierley.ExtensionPropertyManager.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Brierley.ExtensionPropertyManager
{
    public class ExtensionPropertyDbContext<TContext> : DbContext where TContext : DbContext
    {
        public ExtensionPropertyDbContext(DbContextOptions<TContext> options) : base(options)
        {
        }
        public ExtensionPropertyDbContext()
        {

        }
        public DbSet<ExtensionDomain> ExtensionDomains { get; set; }
        public DbSet<ExtensionProperty> ExtensionProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExtensionProperty>().HasIndex(keys => new { keys.ExtensionDomainId, keys.ColumnName }).IsUnique();
            modelBuilder.Entity<ExtensionDomain>().HasIndex(keys => new { keys.OwnerId, keys.TargetTableName }).IsUnique();
            modelBuilder.Entity<ExtensionDomain>().HasData(ExtensionDomainSeed.GetDomains());
            base.OnModelCreating(modelBuilder);
        }
    }
}
