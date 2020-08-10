using Logic.Interfaces;
using Logic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        /// <param name="extensionProperties">List of extended properties</param>
        /// <returns>created list</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IList<ExtensionPropertyDetails> extensionProperties)
        {
            extensionProperties = await _extensionPropertyService.CreateExtensionProperties(extensionProperties);
            return StatusCode(StatusCodes.Status201Created, extensionProperties);
        }
        /// <summary>
        /// Updates existing Extension Properties
        /// </summary>
        /// <param name="extensionProperties">List of extended properties</param>
        /// <returns>updated list</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] IList<ExtensionPropertyDetails> extensionProperties)
        {
            extensionProperties = await _extensionPropertyService.UpdateExtensionProperties(extensionProperties);
            return StatusCode(StatusCodes.Status201Created, extensionProperties);
        }
        /// <summary>
        /// Gets Extension Property by Property Id
        /// </summary>
        /// <param name="propertyId">propertyId</param>
        /// <returns>Extension Property</returns>
        [HttpGet("{propertyId}")]
        public async Task<IActionResult> GetById([FromRoute] int propertyId)
        {
            ExtensionPropertyDetails extensionProperty = await _extensionPropertyService.GetExtensionPropertyById(propertyId);
            return StatusCode(StatusCodes.Status200OK, extensionProperty);
        }
    }
}
