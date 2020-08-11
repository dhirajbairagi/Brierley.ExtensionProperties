using Brierley.ExtensionPropertyManager;
using Brierley.ExtensionPropertyManager.Models;
using System.Threading.Tasks;

namespace ExtensionPropertyFramework.Interfaces
{
    public interface IExtensionDomainManager
    {
        Task<ExtensionDomain> Create<TContext>(ExtensionDomain domain, TContext context) where TContext : ExtensionPropertyDbContext<TContext>;
        Task<ExtensionDomain> Update<TContext>(ExtensionDomain domain, TContext context) where TContext : ExtensionPropertyDbContext<TContext>;
    }
}
