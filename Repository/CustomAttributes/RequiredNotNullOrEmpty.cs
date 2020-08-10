using System.ComponentModel.DataAnnotations;

namespace Repository.CustomAttributes
{
    public class RequiredNotNullOrEmpty : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value is string ? !string.IsNullOrEmpty((string)value) : base.IsValid(value);
        }
    }
}
