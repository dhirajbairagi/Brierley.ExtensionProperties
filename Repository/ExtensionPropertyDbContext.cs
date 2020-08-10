using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Repository.Models;
using Repository.SeedData;
using System.Security.Cryptography;

namespace Repository
{
    public class ExtensionPropertyDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ExtensionPropertyDbContext(DbContextOptions<ExtensionPropertyDbContext> options,
            IConfiguration _configuration) : base(options)
        {
            this._configuration = _configuration;
        }
        public DbSet<ExtensionDomain> ExtensionDomains { get; set; }
        public DbSet<ExtensionProperty> ExtensionProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string schemaName = _configuration.GetConnectionString("SchemaName");
            modelBuilder.HasDefaultSchema(schemaName);


            modelBuilder.Entity<ExtensionProperty>().HasIndex(keys => new { keys.ExtensionDomainId, keys.ColumnName }).IsUnique();
            modelBuilder.Entity<ExtensionDomain>().HasIndex(keys => new { keys.OwnerId, keys.TargetTableName }).IsUnique();
            modelBuilder.Entity<ExtensionDomain>().HasData(ExtensionDomainSeed.GetDomains());
            base.OnModelCreating(modelBuilder);
        }
    }
}
