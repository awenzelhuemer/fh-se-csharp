using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoList.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Public Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Public Methods

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}