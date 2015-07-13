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
    public class CreateTeacherViewModel : INotifyPropertyChanged
    {
        private string _teacherFirstname;
        private string _teacherLastname;
        private string _teacherMiddlename;
        private string _teacherSpecialty;
        private int _teacherDepartment;

        private bool _canExecute;

        public string teacherFirstname
        {
            get { return _teacherFirstname; }
            set
            {
                _teacherFirstname = value;
            }
        }
        public string teacherLastname
        {
            get { return _teacherLastname; }
            set
            {
                _teacherLastname = value;
            }
        }
        public string teacherMiddlename
        {
            get { return _teacherMiddlename; }
            set
            {
                _teacherMiddlename = value;
            }
        }
        public string teacherSpecialty
        {
            get { return _teacherSpecialty; }
            set
            {
                _teacherSpecialty = value;
            }
        }

        private ICommand _actionCreateTeacher;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public CreateTeacherViewModel(int u)
        {
            _canExecute = true;
            _teacherDepartment = u;
        }

        public ICommand actionCreateTeacher
        {
            get
            {
                return _actionCreateTeacher ?? (_actionCreateTeacher = new CommandHandler(() =>
                {
                    AppDelegate.Instance.dataController.CreateNewTeacher(new Teacher(-1, _teacherFirstname, _teacherLastname, _teacherMiddlename, _teacherSpecialty, _teacherDepartment));
                }, _canExecute));
            }
        }

    }
}
