using Brierley.ExtensionPropertyManager.FluentValidators;
using Brierley.ExtensionPropertyManager.Models;
using ExtensionPropertyFramework.Interfaces;
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
