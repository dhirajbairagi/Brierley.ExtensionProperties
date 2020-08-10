using Repository.CustomAttributes;

namespace Logic.ViewModels
{
    public class ExtensionDomainDetails
    {
        public int ExtensionDomainId { get; set; }
        [RequiredNotNullOrEmpty]
        public string TargetTableName { get; set; }
        public int OwnerId { get; set; }
        [RequiredNotNullOrEmpty]
        public string DisplayText { get; set; }
        public string Description { get; set; }
    }
}
