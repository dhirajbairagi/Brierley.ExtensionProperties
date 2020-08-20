using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brierley.ExtensionPropertyManager.Models
{
    public class AttributeMetadataProperty : BaseModel
    {
        [Key]
        public int AttributeMetadataPropertyId { get; set; }
        public int AttributeMetadataId { get; set; }
        [ForeignKey("AttributeMetadataId")]
        public AttributeMetadata AttributeMetadata { get; set; }
        [Required]
        [MaxLength(63)]
        public string ColumnName { get; set; }
        [Required]
        [MaxLength(63)]
        public string DisplayText { get; set; }
        [MaxLength(63)]
        public string Alias { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [MaxLength(250)]
        public string ToolTipText { get; set; }
        [Required]
        public bool IsApiCreateEligible { get; set; } = true;
        [Required]
        public bool IsApiUpdateEligible { get; set; } = true;
        [Required]
        public bool IsPromotionEligible { get; set; } = true;
        public bool IsDsar { get; set; }
        public bool IsRtbf { get; set; }
    }
}
