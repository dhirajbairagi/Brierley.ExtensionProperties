using Brierley.ExtensionPropertyManager.Models;
using ExtensionPropertyFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.ExtensionManagers
{
    public class ExtensionPropertyManager : IExtensionPropertyManager
    {
        public ExtensionPropertyManager()
        {

        }
        public async Task<IList<ExtensionProperty>> CreateExtensionProperties<TContext>(IList<ExtensionProperty> properties, TContext context) where TContext : ExtensionPropertyDbContext<TContext>
        {
            await context.ExtensionProperties.AddRangeAsync(properties);
            await context.SaveChangesAsync();
            return properties;
        }

        public async Task<ExtensionProperty> GetExtensionPropertyById<TContext>(int propertyId, TContext context) where TContext : ExtensionPropertyDbContext<TContext>
        {
            return await context.ExtensionProperties.Where(prop => prop.ExtensionPropertyId == propertyId).FirstOrDefaultAsync();
        }

        public async Task<IList<ExtensionProperty>> UpdateExtensionProperties<TContext>(IList<ExtensionProperty> properties, TContext context) where TContext : ExtensionPropertyDbContext<TContext>
        {
            context.ExtensionProperties.UpdateRange(properties);
            await context.SaveChangesAsync();
            return properties;
        }
    }
}
