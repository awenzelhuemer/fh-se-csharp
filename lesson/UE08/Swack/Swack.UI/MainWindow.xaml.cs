using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Swack.Logic;
using Swack.Logic.Models;
using Swack.UI.ViewModels;

namespace Swack.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var currentUser = new User { Username = "awenzelhuemer", ProfileUrl = "https://robohash.org/1.png?&size=150x150" };
            var vm = new MainViewModel(new SimulatedMessagingLogic(currentUser));
            DataContext = vm;

            Loaded += async (s, e) => await vm.InitializeAsync();
        }

        
    }
}
