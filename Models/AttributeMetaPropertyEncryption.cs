using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brierley.ExtensionPropertyManager.Models
{
    public class AttributeMetaPropertyEncryption : BaseModel
    {
        [Key]
        public int AttributeMetaPropertyEncryptionId { get; set; }
        public int AttributeMetadataPropertyId { get; set; }
        [ForeignKey("AttributeMetadataPropertyId")]
        public virtual AttributeMetadataProperty AttributeMetadataProperty { get; set; }
        public int ProgramId { get; set; }
        [Required]
        [MaxLength(25)]
        public string Encryption { get; set; }
    }
}
