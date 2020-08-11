using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brierley.ExtensionProperty.Manager.Interfaces
{
    public interface IExtensionPropertyManager
    {
        Task<IList<ExtensionPropertyDetails>> CreateExtensionProperties(IList<ExtensionPropertyDetails> extensionProperties);
        Task<IList<ExtensionPropertyDetails>> UpdateExtensionProperties(IList<ExtensionPropertyDetails> extensionProperties);
        Task<ExtensionPropertyDetails> GetExtensionPropertyById(int propertyId);
    }
}
