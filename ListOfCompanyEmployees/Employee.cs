using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;

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
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
                NotifyPropertyChanged("Department");
            }
        }

        public decimal Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                NotifyPropertyChanged("Salary");
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (int.TryParse(Name, out _))
                        {
                            MessageBox.Show(error = "Некорректное имя!!!");
                        }
                        break;

                    case "Age":
                        if ((Age < 0) || (Age > 100))
                        {
                            MessageBox.Show(error = "Возраст должен быть меньше 0 и больше 100");
                        }
                        break;

                    case "Salary":
                        if (Salary < 0)
                        {
                            MessageBox.Show(error = "Зарплата не может быть отрицательной");
                        }
                        break; 
                }
                return error;
            }
        } 

        public string Error => throw new System.NotImplementedException(); 

        public event PropertyChangedEventHandler PropertyChanged;

        public Employee(CultureInfo culture = default)
        {
            _culture = culture ?? CultureInfo.CreateSpecificCulture("uk-UA");
        }

        public void NotifyPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}