using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Brierley.ExtensionPropertyManager.CustomAttributes
{
    public class AcceptDefaultValues : ValidationAttribute
    {
        private static readonly string[] Datatypes = { "String", "Number", "Boolean","Date" };
        public override bool IsValid(object value)
        {
            return value is string && Datatypes.Contains(value.ToString().ToLower());
        }
    }
}
