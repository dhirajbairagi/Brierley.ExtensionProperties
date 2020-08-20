using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Brierley.ExtensionPropertyManager
{
    public static class ValidationExtensions
    {
        public static IEnumerable<string> ValidateObject(this object current, object instance)
        {
            var context = new ValidationContext(instance, null, null);
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(instance, context, result, true);
            return result.Select(x => x.ErrorMessage);
        }
        public static List<List<string>> ValidateObjects(this object current, object objects)
        {
            var instances = JsonConvert.DeserializeObject<IList<object>>(JsonConvert.SerializeObject(objects));
            var results = new List<List<string>>();
            foreach (var instance in instances)
            {
                var context = new ValidationContext(instance, null, null);
                var result = new List<ValidationResult>();
                Validator.TryValidateObject(instance, context, result, true);
                results.Add(result.Select(x=>x.ErrorMessage).ToList());
            }
            return results;
        }
    }
}
