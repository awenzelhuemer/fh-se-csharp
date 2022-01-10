using System.Windows;

namespace TodoList
{
    /// <summary>
    /// Interaction logic for AddItemDialog.xaml
    /// </summary>
    public partial class AddItemDialog : Window
    {
        public AddItemDialog()
        {
            InitializeComponent();
        }

        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
