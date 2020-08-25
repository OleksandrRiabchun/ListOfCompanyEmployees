using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddOrEditEmployee : Window
    {
        private readonly Employee _employee;

        public AddOrEditEmployee(Employee employee, ObservableCollection<Department> dep)
        {
            InitializeComponent();

            _employee = employee;
            employeeName.Text = _employee.Name;
            employeeAge.Text = _employee.Age.ToString();
            employeeDep.ItemsSource = dep;
            employeeDep.SelectedItem = employee.Department;
            employeeSalary.Text = _employee.Salary.ToString();
            DataContext = _employee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employee.Name = employeeName.Text;
            if (int.TryParse(employeeAge.Text, out var age) && age > 0)
            {
                _employee.Age = age;
            }
            else
            {
                MessageBox.Show("Некорректний возраст!!!");
                return;
            }
             
            if (employeeDep.SelectedItem != null)
            {
                _employee.Department = (Department)employeeDep.SelectedItem;
            }
            else
            {
                MessageBox.Show("Выберите департамент!!!");
                return;
            }  

            if (int.TryParse(employeeSalary.Text, out var salary) && salary > 0)
            {
                _employee.Salary = salary;
            }
            else
            {
                MessageBox.Show("Некорректная зарплата!!!");
                return;
            } 
            Close();
        }
    }
}