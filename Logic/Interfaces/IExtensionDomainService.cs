using Logic.ViewModels;
using System.Threading.Tasks;

namespace Brierley.ExtensionProperty.Manager.Interfaces
{
    public interface IExtensionDomainManager
    {
        Task<ExtensionDomainDetails> CreateExtensionDomain(ExtensionDomainDetails extensionDomain);
        Task<ExtensionDomainDetails> UpdateExtensionDomain(ExtensionDomainDetails extensionDomain);
    }
}
