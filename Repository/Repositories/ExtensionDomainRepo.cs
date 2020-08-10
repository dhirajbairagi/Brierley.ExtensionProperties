using Repository.Interfaces;
using Repository.Models;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ExtensionDomainRepo : IExtensionDomainRepo
    {
        private readonly ExtensionPropertyDbContext _dbContext;

        public async Task<ExtensionDomain> Create(ExtensionDomain domain)
        {
            await _dbContext.ExtensionDomains.AddAsync(domain);
            await _dbContext.SaveChangesAsync();
            return domain;
        }
    }
}
