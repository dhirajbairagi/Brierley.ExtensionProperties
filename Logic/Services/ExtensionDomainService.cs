using AutoMapper;
using Brierley.ExtensionProperty.Manager.Interfaces;
using Logic.ViewModels;
using System.Threading.Tasks;

namespace Brierley.ExtensionProperty.Manager.Services
{
    public class ExtensionDomainManager : IExtensionDomainManager
    {
        private readonly IExtensionDomainRepo _extensionDomainRepo;
        private readonly IMapper _mapper;
        public ExtensionDomainManager(IExtensionDomainRepo extensionDomainRepo, IMapper mapper)
        {
            _extensionDomainRepo = extensionDomainRepo;
            _mapper = mapper;
        }

        public async Task<ExtensionDomainDetails> CreateExtensionDomain(ExtensionDomainDetails extensionDomain)
        {
            ExtensionDomain domain = _mapper.Map<ExtensionDomain>(extensionDomain);
            domain = await _extensionDomainRepo.Create(domain);
            extensionDomain = _mapper.Map<ExtensionDomainDetails>(domain);
            return extensionDomain;
        }

        public async Task<ExtensionDomainDetails> UpdateExtensionDomain(ExtensionDomainDetails extensionDomain)
        {
            ExtensionDomain domain = _mapper.Map<ExtensionDomain>(extensionDomain);
            domain = await _extensionDomainRepo.Update(domain);
            extensionDomain = _mapper.Map<ExtensionDomainDetails>(domain);
            return extensionDomain;
        }
    }
}
