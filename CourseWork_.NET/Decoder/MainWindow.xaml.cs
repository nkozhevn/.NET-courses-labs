using Microsoft.Win32;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace Decoder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Encryptor encryptor = new Encryptor();
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void encDo_Click(object sender, RoutedEventArgs e)
        {
            if (CheckKey(keyword.Text) == true && keyword.Text != "")
            {
                encryptor.keyword = keyword.Text;
                ChCode.Text = encryptor.Encrypt(forCode.Text);
            }
            else MessageBox.Show("Введите ключ шифрования без пробелов, используя только кириллицу");
        }

        private void decDo_Click(object sender, RoutedEventArgs e)
        {
            if (CheckKey(keyword.Text) == true && keyword.Text != "")
            {
                encryptor.keyword = keyword.Text;
                ChCode.Text = encryptor.Decrypt(forCode.Text);
            }
            else MessageBox.Show("Введите ключ шифрования без пробелов, используя только кириллицу");
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            if (ttxt.IsChecked == true)
            {
                OpenTxt();
            }
            else OpenDocx();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (ttxt.IsChecked == true)
            {
                CreateTxt();
            }
            else CreateDocx();
        }
        private void CreateDocx()
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Word documents(*.docx) | *.docx";
                if (saveFile.ShowDialog() == true)
                {
                    Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document document = winword.Documents.Add();
                    document.Content.Text = ChCode.Text;
                    document.SaveAs(saveFile.FileName);
                    document.Close();
                    document = null;
                    winword.Quit();
                    winword = null;
                    MessageBox.Show("Файл сохранен");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка:\n{e.Message}");
            }
        }
        private void OpenDocx()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Word documents(*.docx) | *.docx";
                if (dialog.ShowDialog() == true)
                {
                    
                    Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document document = winword.Documents.Open(dialog.FileName);
                    Microsoft.Office.Interop.Word.Range rng = document.Range(0, document.Characters.Count);
                    forCode.Text = rng.Text;
                    document.Close();
                    document = null;
                    winword.Quit();
                    winword = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка:\n{e.Message}");
            }

        }
        private void CreateTxt()
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Text documents(*.txt) | *.txt";
                if (saveFile.ShowDialog() == true)
                {
                    using (StreamWriter sw = new StreamWriter(saveFile.OpenFile(), Encoding.Default))
                    {
                        sw.Write(ChCode.Text);
                        sw.Close();
                    }
                    MessageBox.Show("Файл сохранен");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }

        }
        private void OpenTxt()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Text documents (*.txt)|*.txt";
                if (dialog.ShowDialog() == true)
                {
                    FileInfo fileInfo = new FileInfo(dialog.FileName);
                    using (StreamReader sr = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.UTF8))
                    {
                        string inp = sr.ReadToEnd();
                        if (inp.Contains('�')) inp = File.ReadAllText(dialog.FileName, Encoding.GetEncoding(1251));
                        forCode.Text = inp;
                        sr.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка: " + e.Message);
            }
        }
        private bool CheckKey(string s)
        {
            bool a = true;
            foreach (var cha in s)
            {
                if (cha == ' ' || ((cha >= 'a') && (cha <= 'z')) || ((cha >= 'A') && (cha <= 'Z')))
                {
                    a = false;
                    break;
                }
            }
            return a;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Info.Visibility = Visibility.Hidden;
                encDo.Visibility = Visibility.Visible;
                decDo.Visibility = Visibility.Visible;
                ttxt.Visibility = Visibility.Visible;
                tdocx.Visibility = Visibility.Visible;
                save.Visibility = Visibility.Visible;
                open.Visibility = Visibility.Visible;
                keyw.Visibility = Visibility.Visible;
                keyword.Visibility = Visibility.Visible;
                forCode.Visibility = Visibility.Visible;
                ChCode.Visibility = Visibility.Visible;
                fd.Visibility = Visibility.Visible;
            }
        }
    }
}
