using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ListOfCompanyEmployees
{
    public partial class Window1 : Window
    {
        private readonly ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        private readonly ObservableCollection<Department> _departments = new ObservableCollection<Department>();

        public Window1()
        {
            InitializeComponent();
            FillDepartments();
            FilEmployeest();
        }

        private void AddNewEmployee(object sender, RoutedEventArgs e)
        {
            var nextId = _employees.Count + 1;
            var newEmployee = new Employee();
            AddChangeEmployee addEmployee = new AddChangeEmployee(newEmployee, _departments);
            addEmployee.Show();
            addEmployee.Closed += (s, ew) => _employees.Add(new Employee() { Id = nextId, Name = newEmployee.Name, Department = newEmployee.Department, Age = newEmployee.Age, Salary = newEmployee.Salary });
        }

        private void AddNewDepartments(object sender, RoutedEventArgs e)
        {
            var newDepartment = new Department();
            AddDepartmentForm addDepartmentForm = new AddDepartmentForm(newDepartment);
            addDepartmentForm.Show();
            addDepartmentForm.Closed += (s, ea) => _departments.Add(newDepartment);
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

        private void ChangeEmployee(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = lbEmployee.SelectedItem as Employee;
            if (selectedEmployee is null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            AddChangeEmployee changeEmployee = new AddChangeEmployee(selectedEmployee, _departments);
            changeEmployee.Show();
        }

        private void ChangeDepartment(object sender, RoutedEventArgs e)
        {
            var selectDepartment = lbDepartmant.SelectedItem as Department;
            if (selectDepartment is null)
            {
                MessageBox.Show("Выберите департамент");
                return;
            }
            AddDepartmentForm changeDepartment = new AddDepartmentForm(selectDepartment);
            changeDepartment.Show();
            changeDepartment.Closed += ChangeDepartment_Closed;
        }

        private void ChangeDepartment_Closed(object sender, EventArgs e)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                var selectedEmployee = _employees[i];
                _ = new AddChangeEmployee(selectedEmployee, _departments);
            }
        }
    }
}