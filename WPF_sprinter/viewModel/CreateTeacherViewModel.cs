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
    public class CreateTeacherViewModel : MainViewModel
    {
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

        public async Task CreateNewTeacher(Teacher teacher)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewTeacher(() =>
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

        private ICommand _actionCreateTeacher;

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
                    saved = "Loading...";
                    RaisePropertyChanged("Saved");
                    CreateNewTeacher(new Teacher(-1, _teacherFirstname, _teacherLastname, _teacherMiddlename, _teacherSpecialty, _teacherDepartment));
                }, _canExecute));
            }
        }

    }
}
