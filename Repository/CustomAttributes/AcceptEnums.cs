using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Brierley.ExtensionPropertyManager.CustomAttributes
{
    public class AcceptDefaultValues : ValidationAttribute
    {
        private static readonly string[] datatypes = { "String", "Number", "Boolean","Date" };
        public override bool IsValid(object value)
        {
            return value is string ? datatypes.Contains(value.ToString().ToLower()) : false;
        }
    }
}
