using Brierley.ExtensionPropertyManager.Models;
using ExtensionPropertyFramework.Interfaces;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.ExtensionManagers
{
    internal class ExtensionDomainManager : IExtensionDomainManager
    {
        public async Task<ExtensionDomain> Create<TContext>(ExtensionDomain domain, TContext context) where TContext : ExtensionPropertyDbContext<TContext>
        {
            await context.ExtensionDomains.AddAsync(domain);
            await context.SaveChangesAsync();
            return domain;
        }

        public async Task<ExtensionDomain> Update<TContext>(ExtensionDomain domain, TContext context) where TContext : ExtensionPropertyDbContext<TContext>
        {
            context.ExtensionDomains.Update(domain);
            await context.SaveChangesAsync();
            return domain;
        }
    }
}
