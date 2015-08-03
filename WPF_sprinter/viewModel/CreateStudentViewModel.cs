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
using System.IO;

namespace WPF_sprinter
{
    public class CreateStudentViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Create student";
            }
        }
        private string _studentFirstname;
        private string _studentLastname;
        private string _studentMiddlename;
        private int _studentCource;
        private string _studentType;
        private int _studentDepartment;
        private string _studentPhone;
        private string _studentPassport;
        private int _studentSex = 0;
        private string _studentBirthDate;
        private string _studentAddress;
        private string _studentAvatar;

        private bool _canExecute;

        private List<string> sexVariant;
        public List<string> SexVariant
        {
            get
            {
                return sexVariant;
            }
        }

        public async Task CreateNewStudent(Student student)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewStudent(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(false);
                    AppDelegate.Instance.Alert.ShowAlert("Student successfully created! No errors reported.", true);
                },
                student);
            });
        }

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
        public string studentPhone
        {
            get { return _studentPhone; }
            set
            {
                _studentPhone = value;
            }
        }
        public string studentPassport
        {
            get { return _studentPassport; }
            set
            {
                _studentPassport = value;
            }
        }
        public int studentSex
        {
            get { return _studentSex; }
            set
            {
                _studentSex = value;
            }
        }
        public string studentBirthDate
        {
            get { return _studentBirthDate; }
            set
            {
                _studentBirthDate = value;
            }
        }
        public string studentAddress
        {
            get { return _studentAddress; }
            set
            {
                _studentAddress = value;
            }
        }

        private ICommand _actionSave;
        private ICommand _actionAvatar;

        public CreateStudentViewModel(int u)
        {
            _studentAvatar = "default";
            _canExecute = true;
            _studentDepartment = u;
            sexVariant = new List<string>();
            sexVariant.Add("Male");
            sexVariant.Add("Famale");
        }
        public string SexSelected
        {
            set
            {
                for(int i = 0; i < sexVariant.Count; i++)
                {
                    if (value == sexVariant[i])
                    {
                        _studentSex = i;
                    }
                }
            }
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
                        _studentAvatar = openFileDialog.FileName;
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
                    Student data = new Student(-1, _studentFirstname, _studentLastname, _studentMiddlename, _studentCource, _studentType, _studentDepartment, _studentPhone, _studentPassport, _studentSex, _studentBirthDate, _studentAddress, _studentAvatar);
                    if (new Validation().Validate(data))
                    {
                        CreateNewStudent(data);
                    }
                }, _canExecute));
            }
        }
    }
}
