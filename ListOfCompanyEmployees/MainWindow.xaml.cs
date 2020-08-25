using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ListOfCompanyEmployees
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        private readonly ObservableCollection<Department> _departments = new ObservableCollection<Department>();

        public MainWindow()
        {
            InitializeComponent();
            FillDepartments();
            FilEmployeest();
        }

        private void AddNewEmployee(object sender, RoutedEventArgs e)
        {
            var nextId = _employees.Count + 1;
            var newEmployee = new Employee();
            var addEmployee = new AddOrEditEmployee(newEmployee, _departments);
            addEmployee.Show();
            addEmployee.Closed += (s, ew) => _employees.Add(
                new Employee
                {
                    Id = nextId, Name = newEmployee.Name, Department = newEmployee.Department, Age = newEmployee.Age, Salary = newEmployee.Salary
                });
        }

        private void AddNewDepartments(object sender, RoutedEventArgs e)
        {
            var newDepartment = new Department();
            var addDepartmentForm = new AddOrEditDepartment(newDepartment);
            addDepartmentForm.Show();
            addDepartmentForm.Closed += (s, ea) => _departments.Add(newDepartment);
        }

        private void ChangeEmployee(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = lbEmployee.SelectedItem as Employee;
            var selectedIndex = lbEmployee.SelectedIndex;
            if (selectedEmployee is null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }

            var changeEmployee = new AddOrEditEmployee(selectedEmployee, _departments);
            changeEmployee.Show();
            changeEmployee.Closed += (s, ea) => _employees.RemoveAt(selectedIndex);
            changeEmployee.Closed += (s, ea) => _employees.Add(selectedEmployee);
        }

        private void ChangeDepartment(object sender, RoutedEventArgs e)
        {
            var selectDepartment = lbDepartmant.SelectedItem as Department;
            var selectedIndex = lbDepartmant.SelectedIndex;
            if (selectDepartment is null)
            {
                MessageBox.Show("Выберите департамент");
                return;
            }

            var changeDepartment = new AddOrEditDepartment(selectDepartment);
            changeDepartment.Show();
            changeDepartment.Closed += (s, ea) => _departments.RemoveAt(selectedIndex);
            changeDepartment.Closed += (s, ea) => _departments.Add(selectDepartment);
        }

        private void FillDepartments()
        {
            _departments.Add(new Department { Name = "Department 1" });
            _departments.Add(new Department { Name = "Department 2" });
            _departments.Add(new Department { Name = "Department 3" });

            lbDepartmant.ItemsSource = _departments;
        }

        private void FilEmployeest()
        {
            var rnd = new Random();
            Department GetDep() => _departments[rnd.Next(0, _departments.Count - 1)];

            _employees.Add(new Employee { Id = 1, Name = "Vasia", Department = GetDep(), Age = 25, Salary = 3000m });
            _employees.Add(new Employee { Id = 2, Name = "Petya", Department = GetDep(), Age = 27, Salary = 6000m });
            _employees.Add(new Employee { Id = 3, Name = "Kolya", Department = GetDep(), Age = 30, Salary = 8000m });

            lbEmployee.ItemsSource = _employees;
        }
    }
}