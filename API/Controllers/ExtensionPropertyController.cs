using Logic.Interfaces;
using Logic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/extensionproperties")]
    [ApiController]
    public class ExtensionPropertyController : ControllerBase
    {
        private readonly IExtensionPropertyService _extensionPropertyService;
        public ExtensionPropertyController(IExtensionPropertyService extensionPropertyService)
        {
            _extensionPropertyService = extensionPropertyService;
        }
        /// <summary>
        /// Creates an Extension Property
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IList<ExtensionPropertyDetails> extensionProperties)
        {
            extensionProperties = await _extensionPropertyService.CreateExtensionProperties(extensionProperties);
            return StatusCode(StatusCodes.Status201Created, extensionProperties);
        }
    }
}
