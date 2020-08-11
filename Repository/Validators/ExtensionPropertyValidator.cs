using Brierley.ExtensionPropertyManager.Models;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace API.Validators
{
    public class ExtensionPropertyValidator : AbstractValidator<IList<ExtensionProperty>>
    {
        private static readonly string[] datatypes = { "string", "number", "boolean" };
        public ExtensionPropertyValidator()
        {
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.ColumnName)).WithMessage("ColumnName cannot be empty or null");
            RuleForEach(x => x).Must(x => x.MaxLength > 0).WithMessage("StringMinMax cannot be empty or null");
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.Encryption)).WithMessage("Encryption cannot be empty or null");
            RuleForEach(x => x).Must(x => !string.IsNullOrEmpty(x.DefaultValue)).WithMessage("DefaultValue cannot be empty or null");
            RuleForEach(x => x).Must(x => datatypes.Contains(x.DataType.ToLower())).WithMessage("Unacceptable data type");
        }
    }
}
