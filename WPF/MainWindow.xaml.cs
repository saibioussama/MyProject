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

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EmployesBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployesWindows em = new EmployesWindows();
            em.Show();
            this.Hide();
        }

        private void DepartementsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProjectsBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ParticipationsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
