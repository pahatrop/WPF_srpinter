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

namespace WPF_sprinter.view.popUp
{
    /// <summary>
    /// Interaction logic for ConfirmedAlert.xaml
    /// </summary>
    public partial class ConfirmedAlert : Window
    {
        public bool accept = false;
        public ConfirmedAlert(string text = "Notification")
        {
            InitializeComponent();
            DataText.Text = text;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Accept(object sender, RoutedEventArgs e)
        {
            accept = true;
            this.Close();
        }
    }
}
