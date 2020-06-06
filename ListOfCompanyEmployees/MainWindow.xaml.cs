using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ListOfCompanyEmployees
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> items = new ObservableCollection<Employee>();
        ObservableCollection<Department> dep = new ObservableCollection<Department>();

        public MainWindow()
        { 
            InitializeComponent(); 
            FillList(); 
        }   
        void FillList()
        {
            //items.Add(new Employee { Name = "Петр1", Department = "Отдел 1", Salary = 1000 });
            //items.Add(new Employee { Name = "Петр2", Department = "Отдел 2", Salary = 2000 });
            //items.Add(new Employee { Name = "Петр3", Department = "Отдел 3", Salary = 3000 });
            //items.Add(new Employee { Name = "Петр4", Department = "Отдел 4", Salary = 4000 });
            //items.Add(new Employee { Name = "Петр5", Department = "Отдел 5", Salary = 5000 });
            //Employee.ItemsSource = items;
            //dep.Add(new Department { NameDep = "Отдел 1" });
            //dep.Add(new Department { NameDep = "Отдел 2" });
            //dep.Add(new Department { NameDep = "Отдел 3" });
            //Department.ItemsSource = dep; 
        }

        public void AddDepartment(object sender, RoutedEventArgs e)
        { 
            //addded.Show(); 
        }

        public void Adddd(object obj)
        {
            dep.Add(new Department { Name = obj.ToString() }); ; 
            Department.ItemsSource = dep;
        }

        private void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] == dep[0]) Employee.ItemsSource = items[0].ToString();
            if (e.AddedItems[0] == dep[1]) Employee.ItemsSource = items[1].ToString();
            if (e.AddedItems[0] == dep[2]) Employee.ItemsSource = items[2].ToString(); 
        }
    }
}
