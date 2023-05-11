using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace HL6RQ1_HFT_2022231.WPFClient
{
    /// <summary>
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {

        static RestService rest;
        public List<long> StillOpenLents { get; set; }
        public List<long> Fine { get; set; }
        public List<KeyValuePair<string, double>> PricesByAuthors { get; set; }
        public List<KeyValuePair<string, double>> AvarageIncomePerBookPerYear { get; set; }
        public ObservableCollection<long> collection { get; set; }
        public ObservableCollection<KeyValuePair<string, double>> collection2 { get; set; }
        public StatisticsWindow()
        {
            InitializeComponent();
            DataContext = this;
            collection = new ObservableCollection<long>();
            collection2 = new ObservableCollection<KeyValuePair<string, double>>();
            rest = new RestService("http://localhost:54941/");
        }

        private void NONCRUD1_click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            Fine = rest.Get<long>("Stat/HasToPayFine");
            foreach (var item in Fine)
            {
                collection.Add(item);
            }
        }

        private void NONCRUD2_click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            StillOpenLents = rest.Get<long>("Stat/StillOpenLentsByBookId");
            foreach (var item in StillOpenLents)
            {
                collection.Add(item);
            }
        }

        private void NONCRUD3_click(object sender, RoutedEventArgs e)
        {
            double price = rest.GetSingle<double>("Stat/AVGLentingPrice");
            AVG.Content = price;
            AVG.ContentStringFormat = "Average book price {0} Ft";
        }
        private void NONCRUD4_click(object sender, RoutedEventArgs e)
        {
            this.collection2.Clear();
            PricesByAuthors = rest.Get<KeyValuePair<string, double>>("Stat/AVGLentingPricesByAuthors");
            foreach (var item in PricesByAuthors)
            {
                collection2.Add(item);
            }

        }

        private void NONCRUD5_click(object sender, RoutedEventArgs e)
        {
            this.collection2.Clear();
            int year = int.Parse(TB_year.Text);
            AvarageIncomePerBookPerYear = rest.Getp<KeyValuePair<string, double>>(year, "Stat/GetAverageIncomePerBookPerYear");
            foreach (var item in AvarageIncomePerBookPerYear)
            {
                collection2.Add(item);
            }

        }
        
    }
}
