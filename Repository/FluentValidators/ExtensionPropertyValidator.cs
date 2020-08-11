using Brierley.ExtensionPropertyManager.Models;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace Brierley.ExtensionPropertyManager.FluentValidators
{
    public class ExtensionPropertyValidator : AbstractValidator<IList<ExtensionProperty>>
    {
        public ExtensionPropertyValidator()
        {
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.ColumnName)).WithMessage("ColumnName Should not be null");
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.Encryption)).WithMessage("Encryption Should not be null");
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.DefaultValue)).WithMessage("DefaultValue Should not be null");
            RuleForEach(x => x).Must(x => IsProgramEntityIdDifferent(x)).WithMessage("ProgramId & BusinessEntityId values does not obey mutual exclusion");
            RuleForEach(x => x).Must(x => IsValidDataType(x)).WithMessage("Unacceptable data type");
        }
        private bool IsValidDataType(ExtensionProperty property)
        {
            string[] datatypes = { "string", "number", "boolean", "date" };
            if (!string.IsNullOrEmpty(property.DataType)
                && !string.IsNullOrWhiteSpace(property.DataType)
                && datatypes.Contains(property.DataType.ToLower()))
            {
                return true;
            }
            return false;
        }
        private bool IsProgramEntityIdDifferent(ExtensionProperty property)
        {
            if (property.BusinessEntityId != property.ProgramId)
            {
                if (property.ProgramId <= -1 && property.BusinessEntityId > -1)
                {
                    return true;
                }
                else if (property.ProgramId > -1 && property.BusinessEntityId <= -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

}
