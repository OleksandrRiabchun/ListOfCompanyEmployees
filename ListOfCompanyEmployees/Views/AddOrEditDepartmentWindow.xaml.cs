using System;
using System.Windows;
using System.Windows.Controls;
using ListOfCompanyEmployees.Models;

namespace ListOfCompanyEmployees.Views
{
    /// <summary>
    /// Логика взаимодействия для AddedDepartment.xaml
    /// </summary>
    public partial class AddOrEditDepartmentWindow : EditableDataChildWindow
    {
        private readonly Department _department;
        private readonly Action<Department> _saveDep;
        public AddOrEditDepartmentWindow(Department prototypeDepartment, Action<Department> saveDep) : base(prototypeDepartment)
        {
            InitializeComponent();
            _department = prototypeDepartment;
            _saveDep = saveDep;
            DataContext = _department;
        }

        private void OnSaveDepartment(object sender, RoutedEventArgs e)
        {
            departmentNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

            if (Validation.GetHasError(departmentNameTextBox))
                return;

            _saveDep(_department);
            WasSavedData = true; 
            Close();
        }
    }
}
