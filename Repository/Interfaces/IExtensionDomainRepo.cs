using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IExtensionDomainRepo
    {
        Task<ExtensionDomain> Create(ExtensionDomain domain);
        Task<ExtensionDomain> Update(ExtensionDomain domain);
    }
}
