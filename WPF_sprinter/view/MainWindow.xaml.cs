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
using Models;

namespace WPF_sprinter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UserControl
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            University item1 = e.NewValue as University;
            Department item2 = e.NewValue as Department;
            if (item1 != null)
            {
                if (item1.Identification == "University")
                {
                    AppDelegate.Instance.MW.SelectedUniversityChanged(item1);
                }
            }
            if (item2 != null)
            {
                if (item2.Identification == "Department")
                {
                    AppDelegate.Instance.MW.SelectedDepartmentChanged(item2);
                }
            }
        }
    }
}
