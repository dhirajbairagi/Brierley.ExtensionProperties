using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IExtensionDomainService
    {
        Task<ExtensionDomainDetails> CreateExtensionDomain(ExtensionDomainDetails extensionDomain);
    }
}
