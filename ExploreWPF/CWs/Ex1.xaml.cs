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

namespace ExploreWPF
{
    /// <summary>
    /// Логика взаимодействия для Ex1.xaml
    /// </summary>
    public partial class Ex1 : Window
    {
        public Ex1()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        public string Password { get; set; }
        private void UserPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void PassCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (PassCheckBox.IsChecked == true)
            {
               
            }
        }
    }
}
