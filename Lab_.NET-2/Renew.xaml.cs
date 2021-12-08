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
using System.Windows.Shapes;

namespace Lab_.NET_2
{
    /// <summary>
    /// Логика взаимодействия для Renew.xaml
    /// </summary>
    public partial class Renew : Window
    {
        public Renew(string newe, string old)
        {
            InitializeComponent();
            Helper help = new Helper() { Was = old, New = newe };
            List<Helper> list = new List<Helper>() { help };
            dataGrid.ItemsSource = list;

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class Helper
    {
        public string Was { get; set; }
        public string New { get; set; }
    }
}
