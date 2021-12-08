using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows;

namespace Lab_.NET_2
{
    /// <summary>
    /// Логика взаимодействия для Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public static string Dir { get; set; }
        public static bool checker = false;
        public Loading()
        {
            InitializeComponent();

            string url = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";
            if (findFile("thrlist.xlsx"))
            {
                var result = MessageBox.Show("Файл найден на диске, оставить его? Иначе файл скачается с интернета.", "Файл найден на ПК", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    checker = true;
                }
            }
            if (!checker)
            {
                try
                {
                    if (!Directory.Exists(Environment.CurrentDirectory + @"\ThreatTable\"))
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + @"\ThreatTable\");
                    }
                    WebClient client = new WebClient();

                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri(url), Environment.CurrentDirectory + @"\ThreatTable\thrlist.xlsx");
                    Dir = Environment.CurrentDirectory + @"\ThreatTable\thrlist.xlsx";
                }
                catch { MessageBox.Show("Ошибка при загруке!.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                Dir = Environment.CurrentDirectory + @"\ThreatTable\thrlist.xlsx";
                MessageBox.Show("Файл загружен", "Успех");
                this.Close();
            }
        }

        bool findFile(string fileName)
        {
            string catalog = Environment.CurrentDirectory + @"\ThreatTable\";
            try
            {
                foreach (string findedFile in Directory.EnumerateFiles(catalog, fileName,
                    SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        return true;
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
            catch { return false; }
            return false;
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Ok_Button.IsEnabled = true;
            PageInfo.Content = @"Файл сохранен в папку \ThreatTable";
            this.Title = "Загрузка завершена!";
        }

        private void Ok_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
