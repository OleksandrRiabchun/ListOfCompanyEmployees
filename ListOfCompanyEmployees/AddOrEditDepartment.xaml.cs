using System.Windows;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для AddedDepartment.xaml
    /// </summary>
    public partial class AddOrEditDepartment : Window
    {
        private readonly Department _department;
        public AddOrEditDepartment(Department prototypeDepartment)
        {
            InitializeComponent();
            _department = prototypeDepartment;
            DataContext = _department;
        }

        private void OnSaveDepartment(object sender, RoutedEventArgs e)
        {
            if (_department.Name != null)
            {
                DataContext = _department;
            }
            else
            {
                MessageBox.Show("Введите департамент!!!");
                return;
            }
            Close();
        }
    }
}
