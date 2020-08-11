using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.Interfaces
{
    public interface IExtensionPropertyTransformer<TContext> where TContext : ExtensionPropertyDbContext<TContext>
    {
        Task<string> TransformExtensionProperties(string extensionProperties, string targetTable, int ownerId);
    }
}
