using System;

namespace Brierley.ExtensionPropertyManager.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
