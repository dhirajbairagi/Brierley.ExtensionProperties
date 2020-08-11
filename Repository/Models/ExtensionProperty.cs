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
        [MaxLength(63)]
        public string ColumnName { get; set; }  
        public int AttributeMetadataId { get; set; }
        public int BusinessEntityId { get; set; }
        public int ProgramId { get; set; }
        [RequiredNotNullOrEmpty]
        [MaxLength(63)]
        public string DisplayText { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [MaxLength(25)]
        public string DataType { get; set; }
        public int StringMax { get; set; }
        [RequiredNotNullOrEmpty]
        [MaxLength(25)]
        public string Encryption { get; set; }
        public bool IsDsar { get; set; }
        public bool IsRtbf { get; set; }
        [RequiredNotNullOrEmpty]
        [MaxLength(50)]
        public string DefaultValue { get; set; }
    }
}
