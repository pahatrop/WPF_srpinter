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
    public class EditStudentViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Edit student";
            }
        }
        private int _studentId;
        private string _studentFirstname;
        private string _studentLastname;
        private string _studentMiddlename;
        private int _studentCource;
        private string _studentType;
        private int _studentDepartment;

        private bool _canExecute;

        private string saved;

        public string Saved
        {
            get { return saved; }
        }

        public async Task EditStudent(Student student)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.EditStudent(() =>
                {
                    saved = "Saved!";
                    RaisePropertyChanged("Saved");
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

        private ICommand _actionEditStudent;

        public EditStudentViewModel(Student student)
        {
            _canExecute = true;
            _studentId = student.Id;
            _studentFirstname = student.Firstname;
            _studentLastname = student.Lastname;
            _studentMiddlename = student.Middlename;
            _studentCource = student.Cource;
            _studentType = student.Type;
            _studentDepartment = student.Department;
        }

        public ICommand actionEditStudent
        {
            get
            {
                return _actionEditStudent ?? (_actionEditStudent = new CommandHandler(() =>
                {
                    saved = "Loading...";
                    RaisePropertyChanged("Saved");
                    EditStudent(new Student(_studentId, _studentFirstname, _studentLastname, _studentMiddlename, _studentCource, _studentType, _studentDepartment));
                }, _canExecute));
            }
        }

    }
}
