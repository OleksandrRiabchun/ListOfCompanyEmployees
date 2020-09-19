using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ListOfCompanyEmployees.Models;

namespace ListOfCompanyEmployees.Views
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
            employeeName.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            employeeAge.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            employeeSalary.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
            //employeeDep.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

            if (Validation.GetHasError(employeeName)
             || Validation.GetHasError(employeeAge)
             || Validation.GetHasError(employeeSalary)
             || Validation.GetHasError(employeeDep))
            return;

            _saveEmpl(_employee);
            WasSavedData = true;
            Close();
        }
    }
}