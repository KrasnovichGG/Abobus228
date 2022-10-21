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

namespace Abobus228
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Data.PodgotovkaEGSEntities db = new Data.PodgotovkaEGSEntities();
        public List<Data.Product_for_Agent> products = new List<Data.Product_for_Agent>();
        public MainWindow()
        {
            InitializeComponent();
            RefreshCBbox();

        }
        private void CBNumberWite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pageSize = Convert.ToInt32(CBNumberWite.SelectedItem.ToString());
            RefreshPaggination();
            RefreshButtons();
        }

        private void BLeft_Click(object sender, RoutedEventArgs e)
        {   
            if (pageNumber == 0)
                return;
            pageNumber--;
            RefreshPaggination();
        }

        private void RLeft_Click(object sender, RoutedEventArgs e)
        {
            if (agents.Count % pageSize == 0)
            {
                if (pageNumber == (agents.Count / pageSize) - 1)
                    return;
            }
            else
            {
                if (pageNumber == (agents.Count / pageSize))
                    return;
            }
            pageNumber++;
            RefreshPaggination();
        }
        int pageSize;
        int pageNumber;
        List<Data.Product_for_Agent> agents = db.Product_for_Agent.ToList();
        private void RefreshCBbox()
        {
            CBNumberWite.Items.Add("10");
            CBNumberWite.Items.Add("20");
            CBNumberWite.Items.Add("50");
            CMBSORT.Items.Add("По умолчанию");
            CMBSORT.Items.Add("По названию");
            CMBSORT.Items.Add("По числам");
        }

        private void RefreshPaggination()
        {
            DGWrites.ItemsSource = null;
            DGWrites.ItemsSource = agents.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }
        private void RefreshButtons()
        {
            WPButtons.Children.Clear();
            if (agents.Count % pageSize == 0)
            {
                for (int i = 0; i < agents.Count / pageSize; i++)
                {
                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click;
                    button.Margin = new Thickness(5);
                    button.Width = 50;
                    button.Height = 50;
                    button.FontSize = 20;
                    WPButtons.Children.Add(button);
                }
            }
            else
            {
                for (int i = 0; i < agents.Count / pageSize + 1; i++)
                {
                    Button button = new Button();
                    button.Content = i + 1;
                    button.Click += Button_Click;
                    button.Margin = new Thickness(5);
                    button.Width = 50;
                    button.Height = 50;
                    button.FontSize = 20;
                    WPButtons.Children.Add(button);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            pageNumber = Convert.ToInt32(button.Content) - 1;
            RefreshPaggination();
            CMBSORT_SelectionChanged(null, null);
        }

        private void CMBSORT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGWrites.ItemsSource = null;
            if (CMBSORT.SelectedIndex == 0)
            {
                DGWrites.ItemsSource = agents.Skip(pageNumber * pageSize).Take(pageSize).ToList();
            }
            else if (CMBSORT.SelectedIndex == 1)
            {
                var a = agents.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                for (int? j = 0; j < a.Count; j++)
                {
                    for (int i = 0; i < a.Count - 1; i++)
                    {
                        if (a[i].CompareTo(a[i + 1]) > 0)
                        {
                            var temp = a[i];
                            a[i] = a[i + 1];
                            a[i + 1] = temp;
                        }
                    }
                }
                DGWrites.ItemsSource = a;
            }
            else if (CMBSORT.SelectedIndex == 2)
            {
                var a = agents.Skip(pageNumber * pageSize).Take(pageSize).ToList();
                for (int? j = 0; j < a.Count; j++)
                {
                    for (int i = 0; i < a.Count - 1; i++)
                    {
                        if (a[i].CompareTo(a[i + 1], 3) > 0)
                        {
                            var temp = a[i];
                            a[i] = a[i + 1];
                            a[i + 1] = temp;
                        }
                    }
                }
                DGWrites.ItemsSource = a;
            }
        }

        private void txbpoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            DGWrites.ItemsSource = null;
            DGWrites.ItemsSource = agents.Where(x => x.Name_Products.Contains(txbpoisk.Text)).Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }
    }
}
