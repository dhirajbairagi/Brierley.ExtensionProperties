using Brierley.ExtensionPropertyManager;
using Brierley.ExtensionPropertyManager.Models;
using System.Threading.Tasks;

namespace ExtensionPropertyFramework.Interfaces 
{
    public interface IAttributeMetadataSetManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        /// <summary>
        /// Creates Attribute Metadata per table
        /// </summary>
        /// <param name="attributeMetadata">attributeMetadata</param>
        /// <returns>Created object</returns>
        Task<AttributeMetadata> CreateAsync(AttributeMetadata attributeMetadata);
        /// <summary>
        /// Update existing Attribute Metadata per table
        /// </summary>
        /// <param name="attributeMetadata">attributeMetadata</param>
        /// <returns>Updated object</returns>
        Task<AttributeMetadata> UpdateAsync(AttributeMetadata attributeMetadata);
        /// <summary>
        /// Get Attribute Metadata by Table name
        /// </summary>
        /// <param name="tableName">table Name</param>
        /// <returns></returns>
        Task<AttributeMetadata> GetAttributeMetadataAsync(string tableName);
        /// <summary>
        /// Get Attribute Metadata by Table name
        /// </summary>
        /// <param name="attributeMetadataId">table Name</param>
        /// <returns></returns>
        Task<AttributeMetadata> GetAttributeMetadataAsync(int attributeMetadataId);
    }
}
