using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.SeedData
{
    internal static class ExtensionDomainSeed
    {
        public static IList<ExtensionDomain> GetDomains()
        {
            return new List<ExtensionDomain>
            {
                new ExtensionDomain
                {
                    Id = Guid.Parse("6a8b4aae-db55-4bb7-bd20-c06d1976059f"),
                    ExtensionDomainId = 1,
                    TargetTableName = "Products",
                    DisplayText = "Products Table",
                    Description = "Products Table",
                    OwnerId = 1,
                    IsActive = true,
                    CreatedBy = Guid.Parse("6a8b4aae-db55-4bb7-bd20-c06d1976059f"),
                    CreatedDate = DateTimeOffset.UtcNow,
                    UpdatedBy = Guid.Parse("6a8b4aae-db55-4bb7-bd20-c06d1976059f"),
                    UpdatedDate = DateTimeOffset.UtcNow
                }
            };
        }
    }
}
