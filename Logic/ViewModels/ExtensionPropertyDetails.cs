using ExtensionPropertyFramework.CustomAttributes;

namespace Logic.ViewModels
{
    public class ExtensionPropertyDetails
    {
        public int ExtensionPropertyId { get; set; }
        [RequiredNotNullOrEmpty]
        public string ColumnName { get; set; }
        [RequiredNotNullOrEmpty]
        public string DisplayText { get; set; }
        public string Description { get; set; }
        public string DataType { get; set; }
        [RequiredNotNullOrEmpty]
        public string StringMinMax { get; set; }
        [RequiredNotNullOrEmpty]
        public string Encryption { get; set; }
        public bool IsDsar { get; set; }
        public bool IsRtbf { get; set; }
        public int ExtensionDomainId { get; set; }
        [RequiredNotNullOrEmpty]
        public string DefaultValue { get; set; }
    }
}
