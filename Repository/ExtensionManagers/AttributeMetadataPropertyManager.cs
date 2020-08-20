using Brierley.ExtensionPropertyManager.Interfaces;
using Brierley.ExtensionPropertyManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.ExtensionManagers
{
    internal class AttributeMetadataPropertyManager<TContext> : IAttributeMetadataPropertyManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        private readonly TContext _context;

        public AttributeMetadataPropertyManager(TContext context)
        {
            _context = context;
        }


        public async Task<IList<AttributeMetadataProperty>> CreateAsync(IList<AttributeMetadataProperty> attributeMetadataProperties)
        {
            await _context.AddRangeAsync(attributeMetadataProperties);
            await _context.SaveChangesAsync();
            return attributeMetadataProperties;
        }

        public async Task<IList<AttributeMetadataProperty>> GetAsync(string targetTable)
        {
            var result = await _context.AttributeMetadataProperties.Include(x => x.AttributeMetadata)
                .Where(x => x.AttributeMetadata.TargetTableName.ToUpper() == targetTable.ToUpper()).ToListAsync();
            return result;
        }

        public async Task<IList<AttributeMetadataProperty>> UpdateAsync(IList<AttributeMetadataProperty> attributeMetadataProperties)
        {
            _context.UpdateRange(attributeMetadataProperties);
            await _context.SaveChangesAsync();
            return attributeMetadataProperties; ;
        }
    }
}
