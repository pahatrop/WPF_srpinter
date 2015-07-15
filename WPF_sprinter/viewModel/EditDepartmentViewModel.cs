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
    public class EditDepartmentViewModel : INotifyPropertyChanged
    {
        private int _departmentId;
        private string _departmentName;
        private int _departmentUniversity;

        private bool _canExecute;

        delegate void MethodDelegate(Department department);
        private void BtnCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            MethodDelegate delg = (MethodDelegate)ares.AsyncDelegate;
            MessageBox.Show("Saved");
        }

        public string departmentName
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
            }
        }
        public int departmentUniversity
        {
            get { return _departmentUniversity; }
            set
            {
                _departmentUniversity = value;
            }
        }

        private ICommand _actionEditDepartment;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditDepartmentViewModel(Department department)
        {
            _canExecute = true;
            _departmentId = department.Id;
            _departmentName = department.Name;
            _departmentUniversity = department.University;
        }

        public ICommand actionEditDepartment
        {
            get
            {
                return _actionEditDepartment ?? (_actionEditDepartment = new CommandHandler(() =>
                {
                    MethodDelegate sd = AppDelegate.Instance.dataController.EditDepartment;
                    IAsyncResult asyncRes = sd.BeginInvoke(new Department(_departmentId, _departmentName, _departmentUniversity), new AsyncCallback(BtnCallback), null);
                }, _canExecute));
            }
        }
    }
}
