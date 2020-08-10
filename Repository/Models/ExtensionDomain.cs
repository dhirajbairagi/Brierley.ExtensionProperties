using Repository.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class ExtensionDomain : BaseModel
    {
        [Key]
        public int ExtensionDomainId { get; set; }
        [RequiredNotNullOrEmpty]
        public string TargetTableName { get; set; }
        public int OwnerId { get; set; }
        [RequiredNotNullOrEmpty]
        public string DisplayText { get; set; }
        public string Description { get; set; }
    }
}
