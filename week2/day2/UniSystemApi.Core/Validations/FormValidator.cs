using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UniSystemApi.Core.Exceptions;
using UniSystemApi.Core.Validations;

namespace UniversitySystemSummer.Core.Validations
{
    public class FormValidator
    {
        public static FormValidatorResults Validate(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);
            return new FormValidatorResults(isValid, results);
        }
    }
}