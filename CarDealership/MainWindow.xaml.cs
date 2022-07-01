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

namespace CarDealership
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Car> cars;
        public MainWindow()
        {
            cars = new List<Car> { new Car() { Name = "Tesla model X", _Color = "DarkGray", Price = 20000, State = true, Year = 2018 }, new Car() { Name = "Mercedes", _Color = "Red", Price = 16000, State = true, Year = 2020 } };
            InitializeComponent();
            foreach (var item in cars)
            {
                lstCars.Items.Add(item);
            }
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(EdName.Text)) || (string.IsNullOrWhiteSpace(EdCost.Text)) ||
                           (string.IsNullOrWhiteSpace(EdYear.Text)) || (string.IsNullOrWhiteSpace(EdColor.Text)))
                throw new ArgumentNullException();
            short year = 0;
            double cost = 0;

            if (!double.TryParse(EdCost.Text, out cost) || !short.TryParse(EdYear.Text, out year))
                throw new Exception("Value can not be a text");
            Car nCar = new Car()
            {
                _Color = EdColor.Text,
                Name = EdName.Text,
                Price = cost,
                State = EdState.IsChecked == true,
                Year = year
            };
            lstCars.Items.Add(nCar);
        }

        private void RemoveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (lstCars.SelectedItem != null)
            {
                lstCars.Items.Remove(lstCars.SelectedItem as Car);
            }
        }
    }
}
