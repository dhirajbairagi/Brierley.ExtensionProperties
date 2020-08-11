using Brierley.ExtensionPropertyManager.CustomAttributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brierley.ExtensionPropertyManager.Models
{
    public class ExtensionProperty : BaseModel
    {
        [Key]
        public int ExtensionPropertyId { get; set; }
        [RequiredNotNullOrEmpty]
        public string ColumnName { get; set; }
        public int ExtensionDomainId { get; set; }
        [RequiredNotNullOrEmpty]
        public string DisplayText { get; set; }
        [ForeignKey("ExtensionDomainId")]
        public virtual ExtensionDomain ExtensionDomain { get; set; }
        public string Description { get; set; }
        [AcceptDefaultValues(ErrorMessage ="InValid data type")]
        public string DataType { get; set; }
        public int MaxLength { get; set; }
        [RequiredNotNullOrEmpty]
        public string Encryption { get; set; }
        public bool IsDsar { get; set; }
        public bool IsRtbf { get; set; }
        [RequiredNotNullOrEmpty]
        public string DefaultValue { get; set; }
    }
}
