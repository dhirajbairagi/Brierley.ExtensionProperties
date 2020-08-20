using Brierley.ExtensionPropertyManager.Models;
using FluentValidation;

namespace Brierley.ExtensionPropertyManager.FluentValidators
{
    public class AttributeMetadataValidator : AbstractValidator<AttributeMetadata>
    {
        public AttributeMetadataValidator()
        {
            RuleFor(x => x).Must(x => !string.IsNullOrEmpty(x.TargetTableName)).WithMessage("TargetTableName Should not be null");
            RuleFor(x => x).Must(x => !string.IsNullOrEmpty(x.DisplayText)).WithMessage("DisplayText Should not be null");
        }
    }
}
