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
    public class EditTeacherViewModel : INotifyPropertyChanged
    {
        private int _teacherId;
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

        private ICommand _actionEditTeacher;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditTeacherViewModel(Teacher teacher)
        {
            _canExecute = true;
            _teacherId = teacher.Id;
            _teacherFirstname = teacher.Firstname;
            _teacherLastname = teacher.Lastname;
            _teacherMiddlename = teacher.Middlename;
            _teacherSpecialty = teacher.Specialty;
            _teacherDepartment = teacher.Department;
        }

        public ICommand actionEditTeacher
        {
            get
            {
                return _actionEditTeacher ?? (_actionEditTeacher = new CommandHandler(() =>
                {
                    new XmlDataProvider().EditTeacher(new Teacher(_teacherId, _teacherFirstname, _teacherLastname, _teacherMiddlename, _teacherSpecialty, _teacherDepartment));
                }, _canExecute));
            }
        }

    }
}
