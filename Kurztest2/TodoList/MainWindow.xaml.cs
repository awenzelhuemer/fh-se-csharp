using System.Linq;
using System.Windows;
using TodoList.ViewModels;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private MainViewModel VM
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddItemDialog dialog = new();
            dialog.Owner = this;
            var dialogVm = new AddItemDialogViewModel();
            dialog.DataContext = dialogVm;
            if (dialog.ShowDialog() ?? false)
            {
                VM.Items.Add(new ListEntryViewModel(dialogVm.Name, dialogVm.DueDate.Value));
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if(VM.SelectedItem != null)
            {
                VM.Items.Remove(VM.SelectedItem);
            }
        }

        private void SelectLast(object sender, RoutedEventArgs e)
        {
            VM.SelectedItem = VM.Items.LastOrDefault();
        }
    }
}
