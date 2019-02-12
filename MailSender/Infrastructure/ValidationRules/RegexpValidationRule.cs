using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.Infrastructure.ValidationRules
{
    public class RegexpValidationRule : ValidationRule
    {
        private Regex _Regex;

        public string RegExpr
        {
            get => _Regex?.ToString();
            set => _Regex = value is null ? null : new Regex(value);
        }

        public bool AllowNull { get; set; }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(value is null)
                return AllowNull 
                    ? ValidationResult.ValidResult 
                    : new ValidationResult(false, ErrorMessage ?? "Пустая строка");

            if(_Regex is null) return ValidationResult.ValidResult;

            if (!(value is string str))
                return new ValidationResult(false, ErrorMessage ?? "Значение не является строкой");

            return _Regex.IsMatch(str) 
                ? ValidationResult.ValidResult 
                : new ValidationResult(false, ErrorMessage ?? "Строка не удовлетворяет регулярному выражению");
        }
    }
}
