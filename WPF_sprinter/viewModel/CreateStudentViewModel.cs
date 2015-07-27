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
        private string _studentAvatar;

        private bool _canExecute;

        public async Task CreateNewStudent(Student student)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewStudent(() =>
                {
                    MessageBox.Show("Saved!");
                    AppDelegate.Instance.Context.ChangeLoaderVisible(false);
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

        private ICommand _actionSave;
        private ICommand _actionAvatar;


        public CreateStudentViewModel(int u)
        {
            _studentAvatar = Path.GetRandomFileName() + ".jpg";
            _canExecute = true;
            _studentDepartment = u;
        }

        private string targetPath = Directory.GetCurrentDirectory() + "\\data\\images\\";
        private string sourcePath;

        public ICommand actionAvatar
        {
            get
            {
                return _actionAvatar ?? (_actionAvatar = new CommandHandler(() =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        sourcePath = openFileDialog.FileName;
                        if (!System.IO.Directory.Exists(targetPath))
                        {
                            System.IO.Directory.CreateDirectory(targetPath);
                        }
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
                    try
                    {
                        File.Copy(sourcePath, targetPath + _studentAvatar, true);
                    }
                    catch(Exception e)
                    {

                    }
                    CreateNewStudent(new Student(-1, _studentFirstname, _studentLastname, _studentMiddlename, _studentCource, _studentType, _studentDepartment, _studentAvatar));
                }, _canExecute));
            }
        }

    }
}
