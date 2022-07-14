using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace KeyboardTrainer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        private List<Border> tempBorder = new List<Border>();

        private int AmountPressing = 0;
        private int seconds = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            SpeedLbl.Content = $"Speed = {AmountPressing / seconds} chars/sec";
        }

        private void KeyboardTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            //for (int i = 0; i < tempBorder.Count; i++)
            //{
            foreach (Border item in KeyboardPanel.Children)
            {
                if (((Label)item.Child).Tag.ToString() == e.Key.ToString())
                {
                    Color c = ((SolidColorBrush)(item.Background)).Color;
                    LighterColor(ref c);
                    item.Background = new SolidColorBrush(c);
                    item.BorderBrush = new SolidColorBrush(Colors.Black);
                    break;
                }
                
            }
            
            //tempBorder.Remove(tempBorder[i]);
            AmountPressing++;
            //}
        }
        private void LighterColor(ref Color c)
        {
            float coeff = 20;
            c.B += (byte)coeff;
            c.R += (byte)coeff;
            c.G += (byte)coeff;
        }

        private void DarknerColor(ref Color c)
        {
            float coeff = 20;
            c.B -= (byte)coeff;
            c.R -= (byte)coeff;
            c.G -= (byte)coeff;
        }

        private void KeyboardTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            //if (!e.IsRepeat)
            //{
            //    var a = e.Key.ToString();
            //    for (int i = 0; i < KeyboardPanel.Children.Count; i++)
            //    {
            //        if ((KeyboardPanel.Children[i] as Border).Child is Label
            //            && ((KeyboardPanel.Children[i] as Border).Child as Label).Tag != null
            //            && ((KeyboardPanel.Children[i] as Border).Child as Label).Tag.ToString() == a
            //            || (KeyboardPanel.Children[i] as Border).Child is Image
            //            && ((KeyboardPanel.Children[i] as Border).Child as Image).Tag != null
            //            && ((KeyboardPanel.Children[i] as Border).Child as Image).Tag.ToString() == a)
            //        {
            //            tempBorder.Add(KeyboardPanel.Children[i] as Border);
            //            (KeyboardPanel.Children[i] as Border).BorderBrush = new SolidColorBrush(Colors.White);
            //            Color c = ((System.Windows.Media.SolidColorBrush)(tempBorder[tempBorder.Count - 1].Background)).Color;
            //            DarknerColor(ref c);
            //            tempBorder[tempBorder.Count - 1].Background = new SolidColorBrush(c);
            //            break;
            //        }
            //    }
            //}

            //if (!e.IsRepeat)
            //    if (KeyboardTextBox.Text.Length > 0)
            //    {
            //        for (int i = 0; i < KeyboardPanel.Children.Count; i++)
            //        {

            //            if (KeyboardPanel.Children[i] is Border && (KeyboardPanel.Children[i] as Border).Child is Label)
            //            {
            //                tempBorder = KeyboardPanel.Children[i] as Border;
            //                if ((tempBorder.Child as Label).Content.ToString()[0] == KeyboardTextBox.Text[letters])
            //                {
            //                    letters++;
            //                    tempColor = tempBorder.Background;
            //                    tempBorder.Background = new SolidColorBrush(Colors.Aqua);
            //                    break;
            //                }
            //            }
            //        }
            //    }

        }
        private static string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

        private void StartBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            StopBtn.IsEnabled = true;
            KeyboardTextBox.Focus();

            timer.Start();

            if (KeyboardTextBox_ReadOnly.Text != string.Empty)
            {
                KeyboardTextBox_ReadOnly.Text = "";
                KeyboardTextBox.Text = "";
            }


            string RandChars = " ";
            var rnd = new Random();

            for (int i = 0; i < _Slider.Value * 3; i++)
            {
                RandChars += allowedChars[rnd.Next(0, allowedChars.Length)];
            }

            for (int i = 0; i < _Slider.Value * 10; i++)
            {
                KeyboardTextBox_ReadOnly.Text += RandChars[rnd.Next(0, RandChars.Length)];
            }
        }

        private void _Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            DiffLbl.Content = "";
            DiffLbl.Content += $"Difficulty: {_Slider.Value}";
        }

        private void KeyboardTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!e.IsRepeat)
            {
                var a = e.Key.ToString();
                for (int i = 0; i < KeyboardPanel.Children.Count; i++)
                {
                    if ((KeyboardPanel.Children[i] as Border).Child is Label
                        && ((KeyboardPanel.Children[i] as Border).Child as Label).Tag != null
                        && ((KeyboardPanel.Children[i] as Border).Child as Label).Tag.ToString() == a
                        || (KeyboardPanel.Children[i] as Border).Child is Image
                        && ((KeyboardPanel.Children[i] as Border).Child as Image).Tag != null
                        && ((KeyboardPanel.Children[i] as Border).Child as Image).Tag.ToString() == a)
                    {
                        tempBorder.Add(KeyboardPanel.Children[i] as Border);
                        (KeyboardPanel.Children[i] as Border).BorderBrush = new SolidColorBrush(Colors.White);
                        Color c = ((System.Windows.Media.SolidColorBrush)(tempBorder[tempBorder.Count - 1].Background)).Color;
                        DarknerColor(ref c);
                        //tempBorder[tempBorder.Count - 1].Background = new SolidColorBrush(c);
                        break;
                    }
                }
            }
        }

        private void StopBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            StartBtn.IsEnabled = true;
            KeyboardTextBox_ReadOnly.Text = "";
            KeyboardTextBox.Text = "";
            timer.Stop();
            AmountPressing = 0;
            seconds = 0;
        }
    }
}
