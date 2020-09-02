using System.Globalization;
using System.Windows.Controls;

namespace ListOfCompanyEmployees.ValidationRules
{
    public class AgeRangeRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value?.ToString(), out var age))
            {
                if (age < Min || age > Max)
                {
                    return new ValidationResult(
                        false,
                        $"Please enter an age in the range: {Min}-{Max}.");
                }

                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Age must be integer");
        }
    }
}