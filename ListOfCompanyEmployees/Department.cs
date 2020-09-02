using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ListOfCompanyEmployees
{
    public class Department : BaseNotifyPropertyChanged, IDataErrorInfo
    { 
        private string _name;  
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                { 
                    case "Name":
                        if (int.TryParse(Name, out _))
                        {
                            MessageBox.Show(error = "Некорректное имя!!!");
                        }
                        break; 
                }
                return error;
            }
        }

        public string Error { get; }

        public override string ToString() => Name;
    }
}
