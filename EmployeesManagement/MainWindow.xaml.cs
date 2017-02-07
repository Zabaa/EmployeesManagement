using System;
using System.Linq;
using System.Text;
using System.Windows;


namespace EmployeeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel.EmployeeViewModel();
        }
    }
}
