using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace ExploreWPF.HWs.HW_Lesson1
{
    /// <summary>
    /// Логика взаимодействия для Ex2.xaml
    /// </summary>
    public partial class Ex2 : Window
    {
        public Ex2()
        {
            InitializeComponent();
        }

        private void Btn_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                if (secondTb.Text.Length > 0 && secondTb.Text[secondTb.Text.Length - 1] == '=')
                {
                    secondTb.Text = "";
                    MainTb.Text = "";
                }

                var btn = sender as Button;
                string btnContent = btn.Content.ToString();

                if (btn.Content.ToString()[0] == '_')
                    btnContent = btn.Content.ToString().Remove(0, 1);

                if (char.IsDigit(btnContent.ToCharArray()[0]) && !char.IsSymbol(btnContent.ToCharArray()[0]))
                {
                    MainTb.Text += btnContent;
                    return;
                }

                if (MainTb.Text.Length > 0 && char.IsLetter(btnContent.ToString()[0]) || MainTb.Text.Length > 0 && !char.IsPunctuation(MainTb.Text[MainTb.Text.Length - 1]))
                {
                    switch (btnContent)
                    {
                        case "CE":
                            short ind = 0;
                            for (int i = MainTb.Text.Length - 1; i > 0; i--)
                            {
                                if (!char.IsDigit(MainTb.Text[i]))
                                {
                                    ind = (short)i;
                                    break;
                                }
                            }

                            MainTb.Text = MainTb.Text.Remove(ind);
                            break;
                        case "C":
                            MainTb.Text = "";
                            break;
                        case "<":
                            MainTb.Text = MainTb.Text.Substring(0, MainTb.Text.Length - 1);
                            break;
                        case "=":
                            DataTable dt = new DataTable();
                            secondTb.Text = MainTb.Text + "=";
                            if (MainTb.Text.Contains(','))
                                MainTb.Text = MainTb.Text.Replace(',', '.');
                            try
                            {
                                MainTb.Text = dt.Compute(MainTb.Text, "").ToString();
                            }
                            catch (Exception)
                            {
                                secondTb.Text = "";
                                MessageBox.Show("Incomplete expression", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            HistoryStackPanel.Children.Add(new Label { Content = $"{secondTb.Text + MainTb.Text}" });
                            return;
                    }
                    if (char.IsPunctuation(btn.Content.ToString()[0]))
                    {
                        MainTb.Text += btnContent;
                    }
                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            if (HistoryRow.Height == new GridLength(0))
            {
                HistoryRow.Height = new GridLength(1, GridUnitType.Star);
                BtnsRow.Height = new GridLength(0);

            }

            else
            {
                BtnsRow.Height = new GridLength(1, GridUnitType.Star);
                HistoryRow.Height = new GridLength(0);
            }

        }
    }
}
