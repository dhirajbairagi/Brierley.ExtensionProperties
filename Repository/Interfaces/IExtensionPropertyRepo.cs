using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IExtensionPropertyRepo
    {
        Task<IList<ExtensionProperty>> CreateExtensionProperties(IList<ExtensionProperty> properties);
        Task<IList<ExtensionProperty>> UpdateExtensionProperties(IList<ExtensionProperty> properties);
        Task<ExtensionProperty> GetExtensionPropertyById(int propertyId);
    }
}
