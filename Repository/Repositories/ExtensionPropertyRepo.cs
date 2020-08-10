using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ExtensionPropertyRepo : IExtensionPropertyRepo
    {
        private readonly ExtensionPropertyDbContext _dbContext;

        public ExtensionPropertyRepo(ExtensionPropertyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ExtensionProperty>> CreateExtensionProperties(IList<ExtensionProperty> properties)
        {
            await _dbContext.ExtensionProperties.AddRangeAsync(properties);
            await _dbContext.SaveChangesAsync();
            return properties;
        }
    }
}
