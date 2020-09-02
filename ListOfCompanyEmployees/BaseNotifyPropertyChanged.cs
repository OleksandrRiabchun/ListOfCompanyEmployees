using System.ComponentModel;
using System.Runtime.CompilerServices;
using ListOfCompanyEmployees.Annotations;

namespace ListOfCompanyEmployees
{
    public class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}