using Brierley.ExtensionPropertyManager.Models;
using System;
using System.Collections.Generic;

namespace Brierley.ExtensionPropertyManager.SeedData
{
    internal static class ExtensionDomainSeed
    {
        public static IList<AttributeMetadata> GetDomains()
        {
            return new List<AttributeMetadata>
            {
                new AttributeMetadata
                {
                    Id = Guid.Parse("6a8b4aae-db55-4bb7-bd20-c06d1976059f"),
                    AttributeMetadataId = 1,
                    TargetTableName = "Products",
                    DisplayText = "Products Table",
                    Description = "Products Table",
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
