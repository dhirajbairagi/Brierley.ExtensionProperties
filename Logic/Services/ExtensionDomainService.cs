using AutoMapper;
using Logic.Interfaces;
using Logic.ViewModels;
using Repository.Interfaces;
using Repository.Models;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class ExtensionDomainService : IExtensionDomainService
    {
        private readonly IExtensionDomainRepo _extensionDomainRepo;
        private readonly IMapper _mapper;
        public ExtensionDomainService(IExtensionDomainRepo extensionDomainRepo, IMapper mapper)
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
