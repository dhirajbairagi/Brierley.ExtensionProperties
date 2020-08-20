using System.Collections.Generic;
using System.Linq;
using Brierley.ExtensionPropertyManager.Models;
using FluentValidation;

namespace Brierley.ExtensionPropertyManager.FluentValidators
{
    public class ExtensionPropertyValidator : AbstractValidator<IList<ExtensionProperty>>
    {
        public ExtensionPropertyValidator()
        {
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.ColumnName)).WithMessage("ColumnName Should not be null");
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.Encryption)).WithMessage("Encryption Should not be null");
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.DefaultValue)).WithMessage("DefaultValue Should not be null");
            RuleForEach(x => x).Must(IsProgramEntityIdDifferent).WithMessage("ProgramId & BusinessEntityId values does not obey mutual exclusion");
            RuleForEach(x => x).Must(IsValidDataType).WithMessage("Unacceptable data type");
        }
        private bool IsValidDataType(ExtensionProperty property)
        {
            string[] dataTypes = { "string", "number", "boolean", "date" };
            return !string.IsNullOrEmpty(property.DataType)
                && !string.IsNullOrWhiteSpace(property.DataType)
                && dataTypes.Contains(property.DataType.ToLower());
        }
        private bool IsProgramEntityIdDifferent(ExtensionProperty property)
        {
            return property.BusinessEntityId != property.ProgramId
                   && (property.ProgramId <= -1 && property.BusinessEntityId > -1
                       || property.ProgramId > -1 && property.BusinessEntityId <= -1);
        }
    }

}
