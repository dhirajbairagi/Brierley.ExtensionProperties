using Repository.CustomAttributes;
using System.Collections.Generic;

namespace Logic.ViewModels
{
    public class ExtensionPropertyViewModel
    {
        public ExtensionDomainDetails ExtensionDomainDetails { get; set; }
        public IList<ExtensionPropertyDetails> ExtensionPropertyDetails { get; set; }
    }
}
