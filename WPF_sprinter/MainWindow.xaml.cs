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

namespace WPF_sprinter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            //new XmlDataProvider().CreateNewUniversity(new University(-1,"cfu","dfa",4));
            //new XmlDataProvider().GetAllTeachers();
            //new XmlDataProvider().CreateNewTeacher(new Teacher(-1, "dsfg", "dfg", "fs", "dfgd", 3));
            //new XmlDataProvider().CreateNewStudent(new Student(-1, "dsfg","dfg","fs",4,"dfgd",3));
            //new XmlDataProvider().EditDepartment(new Department(287177, "physics2", 42));
            //new XmlDataProvider().RemoveTeacher(8071382);
        }
    }
}
