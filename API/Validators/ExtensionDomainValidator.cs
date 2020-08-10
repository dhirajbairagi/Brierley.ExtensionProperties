using FluentValidation;
using Logic.ViewModels;

namespace API.Validators
{
    public class ExtensionDomainValidator : AbstractValidator<ExtensionDomainDetails>
    {
        public ExtensionDomainValidator()
        {
            RuleForEach(x => x.DisplayText).NotEmpty().NotNull().WithMessage("DisplayText cannot be empty or null");
            RuleForEach(x => x.TargetTableName).NotEmpty().NotNull().WithMessage("TargetTableName cannot be empty or null");
        }
    }
}
