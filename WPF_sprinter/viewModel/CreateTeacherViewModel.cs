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
using Microsoft.Win32;

namespace WPF_sprinter
{
    public class CreateTeacherViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Create teacher";
            }
        }
        private string _teacherFirstname;
        private string _teacherLastname;
        private string _teacherMiddlename;
        private string _teacherSpecialty;
        private int _teacherDepartment;
        private string _teacherAvatar;

        private bool _canExecute;

        public async Task CreateNewTeacher(Teacher teacher)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewTeacher(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(false);
                    AppDelegate.Instance.Alert.ShowAlert("Teacher successfully created! No errors reported.", true);
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

        private ICommand _actionSave;
        private ICommand _actionAvatar;

        public CreateTeacherViewModel(int u)
        {
            _canExecute = true;
            _teacherAvatar = "default";
            _teacherDepartment = u;
        }

        public ICommand actionAvatar
        {
            get
            {
                return _actionAvatar ?? (_actionAvatar = new CommandHandler(() =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        _teacherAvatar = openFileDialog.FileName;
                    }
                }, _canExecute));
            }
        }
        public ICommand actionSave
        {
            get
            {
                return _actionSave ?? (_actionSave = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(true);
                    Teacher data = new Teacher(-1, _teacherFirstname, _teacherLastname, _teacherMiddlename, _teacherSpecialty, _teacherDepartment, _teacherAvatar);
                    if (new Validation().Validate(data))
                    {
                        CreateNewTeacher(data);
                    }
                }, _canExecute));
            }
        }

    }
}
