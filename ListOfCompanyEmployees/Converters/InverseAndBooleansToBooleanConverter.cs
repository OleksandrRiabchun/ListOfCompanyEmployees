using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ListOfCompanyEmployees.Converters
{
    public class InverseAndBooleansToBooleanConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture) =>
            values.Length <= 0 || values.All(value => !(value is bool) || !(bool)value);

        public object[] ConvertBack(
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture) => throw new NotImplementedException();
    }
}