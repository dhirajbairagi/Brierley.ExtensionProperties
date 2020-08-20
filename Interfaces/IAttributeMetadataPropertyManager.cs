using Brierley.ExtensionPropertyManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.Interfaces
{
    public interface IAttributeMetadataPropertyManager<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        Task<IList<AttributeMetadataProperty>>
            CreateAsync(IList<AttributeMetadataProperty> attributeMetadataProperties);
        Task<IList<AttributeMetadataProperty>>
            UpdateAsync(IList<AttributeMetadataProperty> attributeMetadataProperties);

        Task<IList<AttributeMetadataProperty>>
            GetAsync(string targetTable);

    }
}
