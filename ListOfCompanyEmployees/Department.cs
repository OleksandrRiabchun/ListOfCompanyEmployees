using System.ComponentModel;

namespace ListOfCompanyEmployees
{
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        public override string ToString() => Name;
    }
}
