using Brierley.ExtensionPropertyManager.Models;
using FluentValidation;

namespace API.Validators
{
    public class ExtensionDomainValidator : AbstractValidator<ExtensionDomain>
    {
        public ExtensionDomainValidator()
        {
            RuleForEach(x => x.DisplayText).NotEmpty().NotNull().WithMessage("DisplayText cannot be empty or null");
            RuleForEach(x => x.TargetTableName).NotEmpty().NotNull().WithMessage("TargetTableName cannot be empty or null");
        }
    }
}
