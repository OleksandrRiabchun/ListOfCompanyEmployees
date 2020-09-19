using System;
using System.ComponentModel;
using System.Windows;

namespace ListOfCompanyEmployees.Views
{
    public class EditableDataChildWindow : Window, IDisposable
    {
        private readonly INotifyPropertyChanged _data;
        public bool IsDataChanged { get; protected set; }
        public bool IsSavedData { get; protected set; }

        public EditableDataChildWindow(INotifyPropertyChanged data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));

            _data.PropertyChanged += OnDataChanged;
        }

        private void OnDataChanged(object sender, PropertyChangedEventArgs e) => IsDataChanged = true;

        protected void OnClosing(object _, CancelEventArgs e)
        {
            // If data is dirty, notify user and ask for a response
            if (IsDataChanged && !IsSavedData)
            {
                var msg = "Data was changed. Close without saving?";
                var result =
                    MessageBox.Show(
                        msg,
                        "Data App",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    // If user doesn't want to close, cancel closure
                    e.Cancel = true;
                }
            }
        }

        public void Dispose() => _data.PropertyChanged -= OnDataChanged;
    }
}