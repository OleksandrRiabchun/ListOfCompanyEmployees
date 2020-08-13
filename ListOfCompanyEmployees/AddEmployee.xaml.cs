using System;
using System.Windows; 
using System.Collections.ObjectModel; 

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
            employeeAge.CaretIndex = _employee.Age;
            employeeDep.ItemsSource = dep;
            employeeSalary.DataContext = _employee.Salary;  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            _employee.Name = employeeName.Text; 
            _employee.Age = Convert.ToInt32(employeeAge.Text);
            _employee.Department = (Department)employeeDep.SelectedItem;
            _employee.Salary = Convert.ToInt32(employeeSalary.Text);
            Close();
        } 
    }
}
