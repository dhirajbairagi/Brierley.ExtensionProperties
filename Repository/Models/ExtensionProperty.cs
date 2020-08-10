using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
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
        public string DataType { get; set; }
        [RequiredNotNullOrEmpty]
        public string StringMinMax { get; set; }
        [RequiredNotNullOrEmpty]
        public string Encryption { get; set; }
        public bool IsDsar { get; set; }
        public bool IsRtbf { get; set; }
        [RequiredNotNullOrEmpty]
        public string DefaultValue { get; set; }
    }
}
