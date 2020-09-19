using System;
using System.ComponentModel;
using System.Globalization;

namespace ListOfCompanyEmployees
{
    public class Employee : BaseNotifyPropertyChanged, IDataErrorInfo
    {
        private readonly CultureInfo _culture;
        private int _id;
        private string _name;
        private int _age;
        private Department _department;
        private decimal _salary;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                NotifyPropertyChanged(nameof(Age));
            }
        }

        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                NotifyPropertyChanged(nameof(Department));
            }
        }

        public decimal Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                NotifyPropertyChanged(nameof(Salary));
            }
        }
         
        public string this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Name":
                        if (int.TryParse(Name, out _))
                        {
                            return "Некорректное имя!";
                        }
                        break;
                    case "Salary":
                        if (Salary < 0)
                        {
                            return "Зарплата не может быть отрицательной";
                        } 
                        break;
                    default:
                        return null;
                } 
                return null;
            }
        }

        public string Error => null;

        public Employee(int id) : this()
        {
            _id = id;
        }

        public Employee(CultureInfo culture = default)
        {
            _culture = culture ?? CultureInfo.CreateSpecificCulture("uk-UA");
        }

        public Employee Clone() => new Employee(_culture)
        {
            Id = _id,
            Name = _name.Clone().ToString(),
            Department = Department,
            Age = _age,
            Salary = _salary
        };
    }
}