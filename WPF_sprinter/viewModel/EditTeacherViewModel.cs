using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Models;

namespace WPF_sprinter
{
    public class EditTeacherViewModel : MainViewModel
    {
        private int _teacherId;
        private string _teacherFirstname;
        private string _teacherLastname;
        private string _teacherMiddlename;
        private string _teacherSpecialty;
        private int _teacherDepartment;

        private bool _canExecute;

        private string saved;

        public string Saved
        {
            get { return saved; }
        }

        public async Task EditTeacher(Teacher teacher)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.EditTeacher(() =>
                {
                    saved = "Saved!";
                    RaisePropertyChanged("Saved");
                },
                teacher);
            });
        }

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
                    saved = "Loading...";
                    RaisePropertyChanged("Saved");
                    EditTeacher(new Teacher(_teacherId, _teacherFirstname, _teacherLastname, _teacherMiddlename, _teacherSpecialty, _teacherDepartment));
                }, _canExecute));
            }
        }

    }
}
