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
    public class EditDepartmentViewModel : INotifyPropertyChanged
    {
        private int _departmentId;
        private string _departmentName;
        private int _departmentUniversity;

        private bool _canExecute;

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
                    new XmlDataProvider().EditDepartment(new Department(_departmentId, _departmentName, _departmentUniversity));

                }, _canExecute));
            }
        }
    }
}
