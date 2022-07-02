using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.MessageBox;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OpenFileBtn(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                var res = MessageBox.Show("Текстовое поле не пустое\nХотите сохранить данные?", "Внимание!",
                    MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (res == MessageBoxResult.Yes)
                    SaveFileBtn(this, new RoutedEventArgs());
                textBox.Text = "";
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Length > 0)
                using (StreamReader sr = File.OpenText(openFileDialog.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        textBox.Text += sr.ReadLine();
                        textBox.Text += '\n';
                    }
                }
        }

        private void SaveFileBtn(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog.FileName = $"{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}.txt";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName.Length > 0)
                using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                {
                    sw.WriteLine(textBox.Text);
                }
        }

        private void CopyTextBtn(object sender, RoutedEventArgs e)
        {
            if (textBox.SelectedText.Length > 0)
                textBox.Copy();
        }
        private void PasteTextBtn(object sender, RoutedEventArgs e)
        {
            textBox.Paste();
        }
        private void CutTextBtn(object sender, RoutedEventArgs e)
        {
            if (textBox.SelectedText.Length > 0)
                textBox.Cut();
        }
    }
}
