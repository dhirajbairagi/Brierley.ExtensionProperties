using Brierley.ExtensionPropertyManager.FluentValidators;
using Brierley.ExtensionPropertyManager.Models;
using ExtensionPropertyFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.ExtensionManagers
{
    public class ExtensionPropertyManager<TContext> : IExtensionPropertyManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        private readonly TContext _context;

        public ExtensionPropertyManager(TContext context)
        {
            _context = context;
        }

        public async Task<IList<ExtensionProperty>> CreateExtensionPropertiesAsync(IList<ExtensionProperty> properties)
        {
            var validator = new ExtensionPropertyValidator();
            var result = validator.Validate(properties);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            await _context.ExtensionProperties.AddRangeAsync(properties);
            await _context.SaveChangesAsync();
            return properties;
        }



        public async Task<ExtensionProperty> GetExtensionPropertiesAsync(int propertyId)
        {
            return await _context.ExtensionProperties.Where(prop => prop.ExtensionPropertyId == propertyId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ExtensionProperty>> GetExtensionPropertiesAsync(string targetTableName, int ownerId)
        {
            return await (from prop in _context.ExtensionProperties
                          join domain in _context.AttributeMetadata
                          on prop.AttributeMetadataId equals domain.AttributeMetadataId
                          where domain.TargetTableName.ToLower() == targetTableName.ToLower()
                          && (prop.BusinessEntityId == ownerId || prop.ProgramId == ownerId)
                          select prop).ToListAsync();
        }

        public async Task<IList<ExtensionProperty>> UpdateExtensionPropertiesAsync(IList<ExtensionProperty> properties)
        {
            var validator = new ExtensionPropertyValidator();
            var result = validator.Validate(properties);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
            _context.ExtensionProperties.UpdateRange(properties);
            await _context.SaveChangesAsync();
            return properties;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
