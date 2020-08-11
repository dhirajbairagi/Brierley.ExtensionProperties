using Brierley.ExtensionPropertyManager.Models;
using ExtensionPropertyFramework.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brierley.ExtensionPropertyManager.ExtensionManagers
{
    internal class ExtensionDomainManager : IExtensionDomainManager
    {
        public async Task<ExtensionDomain> Create<TContext>(ExtensionDomain domain, TContext context) where TContext : ExtensionPropertyDbContext<TContext>
        {
            var validationResuts = this.ValidateObject(domain);
            if (validationResuts.Any())
            {
                throw new ValidationException(JsonConvert.SerializeObject(validationResuts));
            }

            await context.ExtensionDomains.AddAsync(domain);
            await context.SaveChangesAsync();
            return domain;
        }

        public async Task<ExtensionDomain> Update<TContext>(ExtensionDomain domain, TContext context) where TContext : ExtensionPropertyDbContext<TContext>
        {
            var validationResuts = this.ValidateObject(domain);
            if (validationResuts.Any())
            {
                throw new ValidationException(JsonConvert.SerializeObject(validationResuts));
            }
            context.ExtensionDomains.Update(domain);
            await context.SaveChangesAsync();
            return domain;
        }
    }
}
