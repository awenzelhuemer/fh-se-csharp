using System;
using System.Collections.ObjectModel;

namespace TodoList.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Private Fields

        private ListEntryViewModel selectedItem;

        #endregion

        #region Public Constructors

        public MainViewModel()
        {
            Items.Add(new ListEntryViewModel("Test 1", DateTime.Now.AddMinutes(-30)));
            Items.Add(new ListEntryViewModel("Test 2", DateTime.Now.AddMinutes(-60)));
        }

        #endregion

        #region Public Properties

        public ObservableCollection<ListEntryViewModel> Items { get; } = new();

        public ListEntryViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}