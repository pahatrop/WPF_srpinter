using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_sprinter
{
    public class EditStudentViewModel : INotifyPropertyChanged
    {
        private int _studentId;
        private string _studentFirstname;
        private string _studentLastname;
        private string _studentMiddlename;
        private int _studentCource;
        private string _studentType;
        private int _studentDepartment;

        private bool _canExecute;

        delegate void MethodDelegate(Student student);
        private void BtnCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            MethodDelegate delg = (MethodDelegate)ares.AsyncDelegate;
            MessageBox.Show("Saved");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

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
                    MethodDelegate sd = AppDelegate.Instance.dataController.EditStudent;
                    IAsyncResult asyncRes = sd.BeginInvoke(new Student(_studentId, _studentFirstname, _studentLastname, _studentMiddlename, _studentCource, _studentType, _studentDepartment), new AsyncCallback(BtnCallback), null);
                }, _canExecute));
            }
        }

    }
}
