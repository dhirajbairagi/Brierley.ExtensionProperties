﻿using System.ComponentModel.DataAnnotations;

namespace Brierley.ExtensionPropertyManager.CustomAttributes
{
    public class RequiredNotNullOrEmpty : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value is string @string ? !string.IsNullOrEmpty(@string) : base.IsValid(value);
        }
    }
}
