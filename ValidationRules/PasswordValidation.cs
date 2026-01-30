using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_vUser.ValidationRules
{
    public class PasswordValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 8)
            {
                return new ValidationResult(false, "Минимальная длина пароля должна составлять 8 символов");
            }

            int d = 0, s = 0, lu = 0, ll = 0;
            foreach (var c in input)
            {
                if (Char.IsDigit(c))
                    d++;
                if (Char.IsSymbol(c) || Char.IsPunctuation(c))
                    s++;
                if (Char.IsUpper(c))
                    lu++;
                if (Char.IsLower(c))
                    ll++;
            }

            if (d == 0)
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы одну цифру");
            }
            if (s == 0)
            {
                return new ValidationResult(false, "Пароль должен содержать хотя бы один символ");
            }
            if (lu == 0)
            {
                return new ValidationResult(false, "Обязательна буква в верхнем регистре");
            }
            if (ll == 0)
            {
                return new ValidationResult(false, "Обязательна буква в нижнем регистре");
            }

            return ValidationResult.ValidResult;
        }
    }
}
