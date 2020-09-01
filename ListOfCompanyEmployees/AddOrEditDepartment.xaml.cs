﻿using System.Windows;
using System.Windows.Controls;

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
            departmentNameTextBox.Text = prototypeDepartment.Name; 
            DataContext = _department;
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