using Brierley.ExtensionPropertyManager;
using Brierley.ExtensionPropertyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExtensionPropertyFramework.Interfaces
{
    public interface IExtensionPropertyManager
    {
        Task<IList<ExtensionProperty>> CreateExtensionProperties<TContext>(IList<ExtensionProperty> properties, TContext context) where TContext : ExtensionPropertyDbContext<TContext>;
        Task<IList<ExtensionProperty>> UpdateExtensionProperties<TContext>(IList<ExtensionProperty> properties, TContext context) where TContext : ExtensionPropertyDbContext<TContext>;
        Task<ExtensionProperty> GetExtensionPropertyById<TContext>(int propertyId, TContext context) where TContext : ExtensionPropertyDbContext<TContext>;
    }
}
