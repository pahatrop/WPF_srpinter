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
    public class EditDepartmentViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Edit department";
            }
        }
        private int _departmentId;
        private string _departmentName;
        private int _departmentUniversity;

        private bool _canExecute;

        public async Task EditDepartment(Department department)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.EditDepartment(() =>
                {
                    MessageBox.Show("Saved!");
                    AppDelegate.Instance.Context.ChangeLoaderVisible(false);
                },
                department);
            });
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

        private ICommand _actionSave;

        public EditDepartmentViewModel(Department department)
        {
            _canExecute = true;
            _departmentId = department.Id;
            _departmentName = department.Name;
            _departmentUniversity = department.Parent;
        }

        public ICommand actionSave
        {
            get
            {
                return _actionSave ?? (_actionSave = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(true);
                    EditDepartment(new Department(_departmentId, _departmentName, _departmentUniversity));
                }, _canExecute));
            }
        }
    }
}
