using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_vUser.ValidationRules
{
    public class PhoneValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (!input.IsNullOrEmpty())
            {
                if (!long.TryParse(input, out long longValue))
                {
                    return new ValidationResult(false, "Необходимо ввести число");
                }

                if (longValue < 80000000000 || longValue > 89999999999)
                {
                    return new ValidationResult(false, "Пример номера: 89991234567");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}
