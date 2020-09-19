using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddOrEditEmployeeWindow : EditableDataChildWindow
    {
        private readonly Employee _employee;
        private readonly Action<Employee> _saveEmpl;

        public AddOrEditEmployeeWindow(Employee employee, Action<Employee> saveEmpl, ObservableCollection<Department> dep)
            : base(employee)
        {
            InitializeComponent();

            _employee = employee;
            employeeDep.ItemsSource = dep;
            _saveEmpl = saveEmpl;
            DataContext = _employee;
        }

        private void OnSaveClick(object sender, RoutedEventArgs e)
        {
            _saveEmpl(_employee);
            IsSavedData = true;
            Close();
        }
    }
}