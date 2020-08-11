using Brierley.ExtensionPropertyManager.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brierley.ExtensionPropertyManager.Models
{
    public class AttributeMetadata : BaseModel
    {
        [Key]
        public int AttributeMetadataId { get; set; }
        [RequiredNotNullOrEmpty]
        public string TargetTableName { get; set; }
        public string Alias { get; set; }
        [RequiredNotNullOrEmpty]
        public string DisplayText { get; set; }
        public bool IsPromoEligible { get; set; } = true;
        public bool IsBatchEligible { get; set; } = true;
        public bool HasPrivacyElement { get; set; } = true;
        public string Description { get; set; }
        [ForeignKey("AttributeMetadataId")]
        public virtual ICollection<ExtensionProperty> ExtensionProperties { get; set; }
    }
}
