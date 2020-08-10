using Logic.Interfaces;
using Logic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/extensiondomain")]
    [ApiController]
    public class ExtensionDomainController : ControllerBase
    {
        private readonly IExtensionDomainService _extensionDomainService;

        public ExtensionDomainController(IExtensionDomainService extensionDomainService)
        {
            _extensionDomainService = extensionDomainService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExtensionDomainDetails extensionDomain)
        {
            extensionDomain = await _extensionDomainService.CreateExtensionDomain(extensionDomain);
            return StatusCode(StatusCodes.Status201Created, extensionDomain);
        }

    }
}
