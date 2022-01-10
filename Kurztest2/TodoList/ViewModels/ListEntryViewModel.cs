using System;

namespace TodoList.ViewModels
{
    public class ListEntryViewModel : BaseViewModel
    {
        #region Private Fields

        private bool done = true;
        private DateTime dueDate;
        private string name;

        #endregion

        #region Public Constructors

        public ListEntryViewModel(string name, DateTime dueDate)
        {
            Name = name;
            DueDate = dueDate;
        }

        #endregion

        #region Public Events

        public event Action<string> NameChanged;

        #endregion

        #region Public Properties

        public bool Done
        {
            get => done;
            set
            {
                if (done != value)
                {
                    done = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DueDate
        {
            get => dueDate; set
            {
                if (dueDate != value)
                {
                    dueDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}