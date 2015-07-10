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

namespace WPF_sprinter.forms
{
    /// <summary>
    /// Interaction logic for EditUniversity.xaml
    /// </summary>
    public partial class EditStudent : Window
    {
        public EditStudent(Student student)
        {
            InitializeComponent();
            DataContext = new EditStudentViewModel(student);
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
