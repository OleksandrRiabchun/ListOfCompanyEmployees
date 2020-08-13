using System;
using System.Windows; 
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddChangeEmployee : Window
    {
        private readonly Employee _employee; 

        public AddChangeEmployee(Employee employee, ObservableCollection<Department> dep)
        {
            InitializeComponent(); 
            _employee = employee; 
            employeeName.Text = _employee.Name;
            employeeAge.Text = _employee.Age.ToString();
            employeeDep.ItemsSource = dep;
            employeeSalary.Text = _employee.Salary.ToString();  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string patternname = @"[\D]";
            string patternage = @"[0-9]+";

            if (Regex.IsMatch(employeeName.Text, patternname, RegexOptions.IgnoreCase))
            {
                _employee.Name = employeeName.Text;
            }
            else { MessageBox.Show("Некорректное имя!!!"); return; }

            if (employeeAge.Text !="0" && Regex.IsMatch(employeeAge.Text, patternage))
            {
                _employee.Age = Convert.ToInt32(employeeAge.Text);
            }
            else { MessageBox.Show("Некорректний возраст!!!"); return; }

            if (employeeDep.SelectedItem != null)
            {
               _employee.Department = (Department)employeeDep.SelectedItem;
            }
            else { MessageBox.Show("Выберите департамент!!!"); return; }

            if (employeeSalary.Text != "0" && Regex.IsMatch(employeeSalary.Text, patternage))
            {
               _employee.Salary = Convert.ToInt32(employeeSalary.Text);
            }
            else { MessageBox.Show("Некорректная зарплата!!!"); return; }
             
            Close();
        } 
    }
}
