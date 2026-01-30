using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_vUser.ValidationRules
{
    public class LoginValidation
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 5)
            {
                return new ValidationResult(false, "Логин должен содержать не менее 5 символов");
            }

            return ValidationResult.ValidResult;
        }
    }
}
