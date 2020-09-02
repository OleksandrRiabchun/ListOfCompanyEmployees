using System.Collections.ObjectModel;
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
            employeeDep.ItemsSource = dep;
            DataContext = _employee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (employeeDep.SelectedItem != null)
            {
                _employee.Department = (Department)employeeDep.SelectedItem;
            }
            else
            {
                MessageBox.Show("Выберите департамент!!!");
                return;
            }
            DataContext = _employee;
            Close();
        }
    }
}