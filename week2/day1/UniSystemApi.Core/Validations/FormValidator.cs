using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UniSystemApi.Core.Exceptions;

namespace UniversitySystemSummer.Core.Validations
{
    public static class FormValidator
    {
        public static void Validate(object form)
        {
            var context = new ValidationContext(form, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(form, context, results, validateAllProperties: true);

            if (!isValid)
            {
                var errors = string.Join(" | ", results.Select(r => r.ErrorMessage));
                throw new BusinessException(errors);
            }
        }
    }
}