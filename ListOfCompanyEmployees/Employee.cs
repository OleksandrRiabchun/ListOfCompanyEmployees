using System.Globalization;

namespace ListOfCompanyEmployees
{
    public class Employee
    {

        private readonly CultureInfo _culture;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public decimal Salary { get; set; }

        public Employee(CultureInfo culture = default)
        {
            _culture = culture ?? CultureInfo.CreateSpecificCulture("uk-UA");
        }

        public override string ToString() => $"{Id}\t{Name}\t{Age}\t{Department}\t{Salary.ToString("C", _culture)}";
    }
}
