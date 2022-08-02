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
            employeeAge.Text = Convert.ToString(_employee.Age);
            employeeDep.SelectedItem = _employee.Department;
            employeeDep.ItemsSource = dep;
            employeeSalary.Text = Convert.ToString(_employee.Salary);
            _employee.NotifyPropertyChanged("Department");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (employeeName.Text != "")
                _employee.Name = employeeName.Text;
            else
            {
                MessageBox.Show("Введите имя!!!");
                return;
            }

            if(Convert.ToInt32(employeeAge.Text) >= 18 && Convert.ToInt32(employeeAge.Text) <= 90)
                _employee.Age = Convert.ToInt32(employeeAge.Text);
            else
            {
                MessageBox.Show("Не корректный возраст!!!");
                return;
            }

            _employee.Department = (Department)employeeDep.SelectedItem;
            _employee.Salary = Convert.ToInt32(employeeSalary.Text);
            Close();
        }
    }
}