using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WpfCurrency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConverter_Click(object sender, RoutedEventArgs e)
        {
            ServiceReferenceCurrency.ServiceCurrencyClient currency = new ServiceReferenceCurrency.ServiceCurrencyClient();
            string[] number = txtCurrency.Text.Split(',');
            if (number.Length > 1)
            {
                txtCurrencyName.Text = currency.GetCurrencyString(Convert.ToInt32(number[0].Trim()))+ " dollars and " + number[1] + " Cents";
            }
            else
            {
                txtCurrencyName.Text = currency.GetCurrencyString(Convert.ToInt32(number[0].Trim())) + " dollar";
            }
        }

        private void txtCurrency_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
