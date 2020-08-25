using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ListOfCompanyEmployees
{
    interface INotifyPropertyChanged : IDataErrorInfo
    {
        new string Error { get; }
        new string this[string columnName] { get; }
    }
    public class Department : INotifyPropertyChanged 
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

        public string Error => throw new System.NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public override string ToString() => Name;
    }
}
