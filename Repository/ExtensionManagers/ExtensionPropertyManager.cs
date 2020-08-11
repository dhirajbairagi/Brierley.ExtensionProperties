using Brierley.ExtensionPropertyManager.FluentValidators;
using Brierley.ExtensionPropertyManager.Models;
using ExtensionPropertyFramework.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.ExtensionManagers
{
    public class ExtensionPropertyManager<TContext> : IExtensionPropertyManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        private readonly TContext context;

        public ExtensionPropertyManager(TContext context)
        {
            this.context = context;
        }

        public async Task<IList<ExtensionProperty>> CreateExtensionProperties(IList<ExtensionProperty> properties)
        {
            var validator = new ExtensionPropertyValidator();
            var result = validator.Validate(properties);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            await context.ExtensionProperties.AddRangeAsync(properties);
            await context.SaveChangesAsync();
            return properties;
        }



        public async Task<ExtensionProperty> GetExtensionProperties(int propertyId)
        {
            return await context.ExtensionProperties.Where(prop => prop.ExtensionPropertyId == propertyId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ExtensionProperty>> GetExtensionProperties(string targetTableName, int ownerId)
        {
            return await (from prop in context.ExtensionProperties
                          join domain in context.AttributeMetadata
                          on prop.AttributeMetadataId equals domain.AttributeMetadataId
                          where domain.TargetTableName.ToLower() == targetTableName.ToLower()
                          && (prop.BusinessEntityId == ownerId || prop.ProgramId == ownerId)
                          select prop).ToListAsync();
        }

        public async Task<IList<ExtensionProperty>> UpdateExtensionProperties(IList<ExtensionProperty> properties)
        {
            var validator = new ExtensionPropertyValidator();
            var result = validator.Validate(properties);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            context.ExtensionProperties.UpdateRange(properties);
            await context.SaveChangesAsync();
            return properties;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
