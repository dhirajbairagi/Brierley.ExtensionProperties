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
        public DbSet<AttributeMetadata> AttributeMetadata { get; set; }
        public DbSet<ExtensionProperty> ExtensionProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeMetadata>().HasIndex(keys => new { keys.TargetTableName }).IsUnique();
            modelBuilder.Entity<ExtensionProperty>().HasIndex(keys => new { keys.AttributeMetadataId, keys.ColumnName, keys.BusinessEntityId, keys.ProgramId }).IsUnique();
            modelBuilder.Entity<AttributeMetadata>().HasData(ExtensionDomainSeed.GetDomains());
            base.OnModelCreating(modelBuilder);
        }
    }
}
