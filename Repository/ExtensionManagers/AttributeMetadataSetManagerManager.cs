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
        private readonly TContext context;

        public AttributeMetadataSetManager(TContext context)
        {
            this.context = context;
        }

        public async Task<AttributeMetadata> Create(AttributeMetadata domain)
        {
            var validator = new AttributeMetadataValidator();
            var result = validator.Validate(domain);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            await context.AttributeMetadata.AddAsync(domain);
            await context.SaveChangesAsync();
            return domain;
        }

        public async Task<AttributeMetadata> GetAttributeMetadata(string tableName)
        {
            return await context.AttributeMetadata.Where(x => x.TargetTableName.ToUpper() == tableName.ToUpper()).FirstOrDefaultAsync();
        }

        public async Task<AttributeMetadata> GetAttributeMetadata(int attributeMetadataId)
        {
            return await context.AttributeMetadata.Where(x => x.AttributeMetadataId == attributeMetadataId).FirstOrDefaultAsync();
        }

        public async Task<AttributeMetadata> Update(AttributeMetadata domain)
        {
            var validator = new AttributeMetadataValidator();
            var result = validator.Validate(domain);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            context.AttributeMetadata.Update(domain);
            await context.SaveChangesAsync();
            return domain;
        }
    }
}
