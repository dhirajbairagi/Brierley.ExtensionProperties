using AutoMapper.Internal;
using Castle.Core.Internal;
using FluentValidation;
using Logic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace API.Validators
{
    public class ExtensionPropertyValidator : AbstractValidator<IList<ExtensionPropertyDetails>>
    {
        private static readonly string[] datatypes = { "string", "number", "boolean" };
        public ExtensionPropertyValidator()
        {
            RuleForEach(x => x).Must(x => !x.ColumnName.IsNullOrEmpty()).WithMessage("ColumnName cannot be empty or null");
            RuleForEach(x => x).Must(x => !x.StringMinMax.IsNullOrEmpty()).WithMessage("StringMinMax cannot be empty or null");
            RuleForEach(x => x).Must(x => !x.Encryption.IsNullOrEmpty()).WithMessage("Encryption cannot be empty or null");
            RuleForEach(x => x).Must(x => !x.DefaultValue.IsNullOrEmpty()).WithMessage("DefaultValue cannot be empty or null");
            RuleForEach(x => x).Must(x => datatypes.Contains(x.DataType.ToLower())).WithMessage("Unacceptable data type");
        }
    }
}
