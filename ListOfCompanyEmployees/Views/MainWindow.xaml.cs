﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using ListOfCompanyEmployees.Models;

namespace ListOfCompanyEmployees.Views
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
        private readonly ObservableCollection<Department> _departments = new ObservableCollection<Department>();

        public MainWindow()
        {
            InitializeComponent();
            FillDepartments();
            FillEmployees();
        }

        private void AddNewEmployee(object sender, RoutedEventArgs e)
        {
            var nextId = _employees.Count + 1;
            var newEmployee = new Employee(nextId);
            var window = new AddOrEditEmployeeWindow(
                newEmployee,
                empl => _employees.Add(empl),
                _departments);

            window.Show();
        }

        private void AddNewDepartments(object sender, RoutedEventArgs e)
        {
            var newDepartment = new Department();
            var window = new AddOrEditDepartmentWindow(
                newDepartment,
                dep => _departments.Add(dep));
            window.Show(); 
        }

        private void ChangeEmployee(object sender, RoutedEventArgs e)
        {
            if (!(lvEmployee.SelectedItem is Employee selectedEmployee))
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }

            var window = new AddOrEditEmployeeWindow(
                selectedEmployee.Clone(),
                empl =>
                {
                    _employees.RemoveAt(lvEmployee.SelectedIndex); 
                    _employees.Add(empl);
                },
                _departments);

            window.Show();
        }

        private void ChangeDepartment(object sender, RoutedEventArgs e)
        { 
            if (!(lbDepartmant.SelectedItem is Department selectedDepartment))
            {
                MessageBox.Show("Выберите департамент");
                return;
            }

            var window = new AddOrEditDepartmentWindow(
                selectedDepartment.Clone(),
                dep =>
                {
                    _departments.RemoveAt(lbDepartmant.SelectedIndex);
                    _departments.Add(dep);
                });
            window.Show(); 
        } 
        #region Seed Data

        private void FillDepartments()
        {
            _departments.Add(new Department { Name = "Department 1" });
            _departments.Add(new Department { Name = "Department 2" });
            _departments.Add(new Department { Name = "Department 3" });

            lbDepartmant.ItemsSource = _departments;
        }

        private void FillEmployees()
        {
            var rnd = new Random();
            Department GetDep() => _departments[rnd.Next(0, _departments.Count - 1)];

            _employees.Add(new Employee { Id = 1, Name = "Vasia", Department = GetDep(), Age = 25, Salary = 3000m });
            _employees.Add(new Employee { Id = 2, Name = "Petya", Department = GetDep(), Age = 27, Salary = 6000m });
            _employees.Add(new Employee { Id = 3, Name = "Kolya", Department = GetDep(), Age = 30, Salary = 8000m });

            lvEmployee.ItemsSource = _employees;
        }

        #endregion
    }
}