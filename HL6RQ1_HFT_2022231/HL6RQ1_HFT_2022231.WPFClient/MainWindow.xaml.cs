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

namespace HL6RQ1_HFT_2022231.WPFClient
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

        private void Authors_Click(object sender, RoutedEventArgs e)
        {
            AuthorWindow proc = new AuthorWindow();
            proc.Show();
        }
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            BookWindow proc = new BookWindow();
            proc.Show();
        }
        private void Lentings_Click(object sender, RoutedEventArgs e)
        {
            LentingWindow proc = new LentingWindow();
            proc.Show();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow proc = new StatisticsWindow();
            proc.Show();
        }
    }
}
