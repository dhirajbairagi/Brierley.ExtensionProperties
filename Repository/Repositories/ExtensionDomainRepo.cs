using Repository.Interfaces;
using Repository.Models;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ExtensionDomainRepo : IExtensionDomainRepo
    {
        private readonly ExtensionPropertyDbContext _dbContext;

        public ExtensionDomainRepo(ExtensionPropertyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExtensionDomain> Create(ExtensionDomain domain)
        {
            await _dbContext.ExtensionDomains.AddAsync(domain);
            await _dbContext.SaveChangesAsync();
            return domain;
        }

        public async Task<ExtensionDomain> Update(ExtensionDomain domain)
        {
            _dbContext.ExtensionDomains.Update(domain);
            await _dbContext.SaveChangesAsync();
            return domain;
        }
    }
}
