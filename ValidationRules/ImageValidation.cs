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
    class ImageValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (!input.IsNullOrEmpty())
            {
                if (input.Length < 5)
                {
                    return new ValidationResult(false, "Длина пути должна составлять минимум 5 символов");
                }

                //int endIndex = input.LastIndexOf(".png");
                //string type = input.Substring(input.Length, endIndex);

                //if (type != ".png")
                //{
                //    return new ValidationResult(false, "Неверная ссылка на изображение");
                //} 
            }

            return ValidationResult.ValidResult;
        }
    }
}
