using System.ComponentModel;
using System.Globalization;

namespace ListOfCompanyEmployees
{
    public class Employee : INotifyPropertyChanged
    { 
        private readonly CultureInfo _culture;
        private int _id;
        private string _name;
        private int _age;
        private Department _department;
        private decimal _salary;

        public int Id 
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public Department Department
        {
            get { return _department; }
            set
            {
                _department = value;
                NotifyPropertyChanged("Department");
            }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
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
    }
}
