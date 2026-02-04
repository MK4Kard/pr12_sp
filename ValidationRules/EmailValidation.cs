using pr12_vUser.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr12_vUser.ValidationRules
{
    public class EmailValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            /*if (input.Length < 5)
            {
                return new ValidationResult(false, "Логин должен содержать не менее 5 символов");
            }*/

            var db = BaseDbService.Instance.Context;

            bool mailUnique = db.Users.Any(m => m.Email.ToLower() == input.ToLower());

            if (mailUnique)
            {
                return new ValidationResult(false, "Такая почта уже существует");
            }

            bool dogInMail = input.Contains('@');

            if (!dogInMail)
            {
                return new ValidationResult(false, "В почте обязателен символ @");
            }

            return ValidationResult.ValidResult;
        }
    }
}
