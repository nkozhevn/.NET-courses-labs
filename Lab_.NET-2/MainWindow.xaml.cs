using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
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
using System.Data;
using System.ComponentModel;
using System.Net;
using System.Threading;

namespace Lab_.NET_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Threat> metrics;
        Pages paging;
        int current_page = 1, flag = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Load(object sender, RoutedEventArgs e)
        {
            Loading loader = new Loading();
            if (!Loading.checker) { loader.Show(); Thread.Sleep(4000); }
            Name.Visibility = Id.Visibility = Visibility.Visible;
            Refresh_Button.IsEnabled = true;
            metrics = Parser.EnumerateMetrics(Loading.Dir).ToList();
            paging = new Pages(metrics);
            dataGrid.ItemsSource = paging.First();
            Manage.Visibility = Visibility.Visible;
            PageInfo.Content = PageDisplay();

        }
        public string PageDisplay()
        {
            return current_page + @"/" + paging.pages;
        }
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            current_page++;
            PageInfo.Content = PageDisplay();

            Backwards.IsEnabled = true;
            if (current_page == paging.pages)
            {

                Forward.IsEnabled = false;
                dataGrid.ItemsSource = paging.Last();
            }
            else
            {
                dataGrid.ItemsSource = paging.Next(current_page);
            }
        }

        private void Backwards_Click(object sender, RoutedEventArgs e)
        {
            current_page--;
            PageInfo.Content = PageDisplay();


            Forward.IsEnabled = true;
            if (current_page == 1)
            {

                Backwards.IsEnabled = false;
                dataGrid.ItemsSource = paging.First();
            }
            else
            {
                dataGrid.ItemsSource = paging.Prev(current_page);
            }
        }



        private void dataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Threat path = dataGrid.SelectedItem as Threat;
            if (path != null & flag == 0)
            {
                MessageBox.Show(path.ToString(), "Полная информация по " + path.FormatId, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (flag == 1)
            {
                new Renew(path.ToString(), metrics.Find(
                    delegate (Threat bs)
                    {
                        return bs.Id == path.Id;
                    }
                ).ToString()).Show();
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            new Uploader();
            List<Threat> changes = new List<Threat>();
            for (int i = 0; i < Uploader.metrics.Count; i++)
            {
                if (!Compare(Uploader.metrics.ElementAt(i), metrics.ElementAt(i)))
                {
                    changes.Add(Uploader.metrics.ElementAt(i));
                }
            }
            MessageBox.Show("Обновление прошло успешно", "Количество обновленных строк: " + changes.Count, MessageBoxButton.OK);
            if (changes.Count != 0)
            {
                flag = 1;
                GoBack_Button.Visibility = Visibility.Visible;
                Refresh_Button.Visibility = Manage.Visibility = Visibility.Hidden;
                dataGrid.ItemsSource = changes;
            }
            else
            {
                MessageBox.Show("Нет обновлений", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            flag = 0;
            GoBack_Button.Visibility = Visibility.Hidden;
            Refresh_Button.Visibility = Manage.Visibility = Visibility.Visible;
            dataGrid.ItemsSource = metrics = Uploader.metrics;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private bool Compare(Threat a, Threat b)
        {
            if (a.Id != b.Id || a.Name != b.Name || a.Obj != b.Obj || a.Source != b.Source ||
                a.Reliability != b.Reliability || a.Integrity != b.Integrity || a.Confidentiality != b.Confidentiality || a.Info != b.Info)
            {
                return false;
            }
            return true;
        }
    }
}
