using Brierley.ExtensionPropertyManager;
using Brierley.ExtensionPropertyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExtensionPropertyFramework.Interfaces
{
    public interface IExtensionPropertyManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        /// <summary>
        /// Bulk insert Extension properties
        /// </summary>
        /// <param name="properties">Extension properties List</param>
        /// <returns>Created Extension properties List</returns>
        Task<IList<ExtensionProperty>> CreateExtensionProperties(IList<ExtensionProperty> properties);
        /// <summary>
        /// Bulk Update Extension properties
        /// </summary>
        /// <param name="properties">Extension properties List</param>
        /// <returns>Updated Extension properties List</returns>
        Task<IList<ExtensionProperty>> UpdateExtensionProperties(IList<ExtensionProperty> properties);
        /// <summary>
        /// Gets Extension property by its Id
        /// </summary>
        /// <param name="propertyId">propertyId</param>
        /// <returns>Extension property of that Id</returns>
        Task<ExtensionProperty> GetExtensionProperties(int propertyId);
        /// <summary>
        /// Gets List of Extension Properties for a given table name and ownerID
        /// </summary>
        /// <param name="targetTableName">Any table Name like Products.Stores, Members etc</param>
        /// <param name="ownerId">it can be either Business Entity Id or Program Id depends on Context</param>
        /// <returns></returns>
        Task<IEnumerable<ExtensionProperty>> GetExtensionProperties(string targetTableName, int ownerId);

    }
}
