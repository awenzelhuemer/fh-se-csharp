using System;

namespace TodoList.ViewModels
{
    public class AddItemDialogViewModel : BaseViewModel
    {
        #region Private Fields

        private DateTime? dueDate;
        private string name;

        #endregion

        #region Public Properties

        public DateTime? DueDate
        {
            get
            {
                return dueDate;
            }
            set
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
            get { return name; }
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