using Brierley.ExtensionPropertyManager.FluentValidators;
using Brierley.ExtensionPropertyManager.Models;
using ExtensionPropertyFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.ExtensionManagers
{
    internal class AttributeMetadataSetManager<TContext> : IAttributeMetadataSetManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        private readonly TContext _context;

        public AttributeMetadataSetManager(TContext context)
        {
            _context = context;
        }

        public async Task<AttributeMetadata> CreateAsync(AttributeMetadata domain)
        {
            var validator = new AttributeMetadataValidator();
            var result = validator.Validate(domain);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            await _context.AttributeMetadata.AddAsync(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<AttributeMetadata> GetAttributeMetadataAsync(string tableName)
        {
            return await _context.AttributeMetadata.Include(x=>x.AttributeMetadataProperties)
                .Include(x=>x.ExtensionProperties)
                .Where(x => x.TargetTableName.ToUpper() == tableName.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task<AttributeMetadata> GetAttributeMetadataAsync(int attributeMetadataId)
        {
            return await _context.AttributeMetadata.Include(x => x.AttributeMetadataProperties)
                .Include(x => x.ExtensionProperties).Where(x => x.AttributeMetadataId == attributeMetadataId).FirstOrDefaultAsync();
        }

        public async Task<AttributeMetadata> UpdateAsync(AttributeMetadata domain)
        {
            var validator = new AttributeMetadataValidator();
            var result = validator.Validate(domain);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            _context.AttributeMetadata.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }
    }
}
