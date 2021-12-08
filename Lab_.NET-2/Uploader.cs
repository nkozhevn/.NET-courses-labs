using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_.NET_2
{
    class Uploader
    {
        public string Dir { get; set; }
        public static List<Threat> metrics;
        public Uploader()
        {
            //string fileName = file;
            string url = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";

            string Dir = Environment.CurrentDirectory + @"\ThreatTable\thrlist.xlsx";
            try
            {
                WebClient client = new WebClient();
                client.DownloadFileAsync(new Uri(url), Dir);
                Thread.Sleep(3000);
                metrics = Parser.EnumerateMetrics(Dir).ToList();
            }
            catch { MessageBox.Show("При загрузке произошла ошибка. Проверьте соединение или ссылку на файл.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
