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
        public ExtensionDomainService(IExtensionDomainRepo extensionDomainRepo)
        {
            _extensionDomainRepo = extensionDomainRepo;
        }

        public async Task<ExtensionDomainDetails> CreateExtensionDomain(ExtensionDomainDetails extensionDomain)
        {
            ExtensionDomain domain = _mapper.Map<ExtensionDomain>(extensionDomain);
            domain = await _extensionDomainRepo.Create(domain);
            extensionDomain = _mapper.Map<ExtensionDomainDetails>(domain);
            return extensionDomain;
        }
    }
}
