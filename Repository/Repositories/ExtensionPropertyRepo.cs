using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ExtensionProperty> GetExtensionPropertyById(int propertyId)
        {
            return await _dbContext.ExtensionProperties.Where(prop => prop.ExtensionPropertyId == propertyId).FirstOrDefaultAsync();
        }

        public async Task<IList<ExtensionProperty>> UpdateExtensionProperties(IList<ExtensionProperty> properties)
        {
            _dbContext.ExtensionProperties.UpdateRange(properties);
            await _dbContext.SaveChangesAsync();
            return properties;
        }
    }
}
