using System.ComponentModel;

namespace ListOfCompanyEmployees
{
    public class Department : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; } 
            set
            {
                name = value;
                NotifyPropertyChanged("Name"); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        } 

        public override string ToString() => Name;
    }
}
