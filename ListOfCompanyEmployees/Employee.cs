using System.ComponentModel;
using System.Globalization;

namespace ListOfCompanyEmployees
{
    public class Employee : INotifyPropertyChanged
    { 
        private readonly CultureInfo _culture;
        private int id;
        private string name;
        private int age;
        private Department department;
        private decimal salary;

        public int Id 
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public Department Department
        {
            get { return department; }
            set
            {
                department = value;
                NotifyPropertyChanged("Department");
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                salary = value;
                NotifyPropertyChanged("Salary");
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Employee(CultureInfo culture = default)
        {
            _culture = culture ?? CultureInfo.CreateSpecificCulture("uk-UA");
        }

        public override string ToString() => $"{Id}\t{Name}\t{Age}\t{Department}\t{Salary.ToString("C", _culture)}";
    }
}
