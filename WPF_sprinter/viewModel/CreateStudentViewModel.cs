using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_sprinter
{
    public class CreateStudentViewModel : INotifyPropertyChanged
    {
        private string _studentFirstname;
        private string _studentLastname;
        private string _studentMiddlename;
        private int _studentCource;
        private string _studentType;
        private int _studentDepartment;

        private bool _canExecute;

        public string studentFirstname
        {
            get { return _studentFirstname; }
            set
            {
                _studentFirstname = value;
            }
        }
        public string studentLastname
        {
            get { return _studentLastname; }
            set
            {
                _studentLastname = value;
            }
        }
        public string studentMiddlename
        {
            get { return _studentMiddlename; }
            set
            {
                _studentMiddlename = value;
            }
        }
        public int studentCource
        {
            get { return _studentCource; }
            set
            {
                _studentCource = value;
            }
        }
        public string studentType
        {
            get { return _studentType; }
            set
            {
                _studentType = value;
            }
        }

        private ICommand _actionCreateStudent;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public CreateStudentViewModel(int u)
        {
            _canExecute = true;
            _studentDepartment = u;
        }

        public ICommand actionCreateStudent
        {
            get
            {
                return _actionCreateStudent ?? (_actionCreateStudent = new CommandHandler(() =>
                {
                    AppDelegate.Instance.dataController.CreateNewStudent(new Student(-1, _studentFirstname, _studentLastname, _studentMiddlename, _studentCource, _studentType, _studentDepartment));
                }, _canExecute));
            }
        }

    }
}
