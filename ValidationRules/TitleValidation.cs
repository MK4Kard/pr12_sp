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
    internal class TitleValidation : ValidationRule
    {
        public bool IsEdit { get; set; } = false;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            var db = BaseDbService.Instance.Context;

            bool titleUnique = db.InterestGroups.Any(l => l.Title.ToLower() == input.ToLower());

            if (titleUnique && !IsEdit)
            {
                return new ValidationResult(false, "Такая группа уже существует");
            }

            return ValidationResult.ValidResult;
        }
    }
}
