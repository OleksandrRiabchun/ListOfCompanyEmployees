using System.Windows;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для AddedDepartment.xaml
    /// </summary>
    public partial class AddDepartmentForm : Window
    {
        private readonly Department _department;
        public AddDepartmentForm(Department prototypeDepartment)
        {
            InitializeComponent();
            _department = prototypeDepartment;
            departmentNameTextBox.Text = prototypeDepartment.Name; 
        }
         
        private void OnSaveDepartment(object sender, RoutedEventArgs e)
        {
            if (departmentNameTextBox.Text != "")
            {
                _department.Name = departmentNameTextBox.Text;
            }
            else { MessageBox.Show("Введите департамент"); return; }
             
            Close();
        }
    }
}
