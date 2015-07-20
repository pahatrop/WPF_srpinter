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
    public class CreateDepartmentViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Create department";
            }
        }
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

        private ICommand _actionSave;

        public async Task CreateNewDepartment(Department department)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewDepartment(() =>
                {
                    MessageBox.Show("Saved!");
                    AppDelegate.Instance.Context.ChangeLoaderVisible(false);
                },
                department);
            });
        }

        public CreateDepartmentViewModel(int u)
        {
            _canExecute = true;
            _departmentUniversity = u;
        }

        public ICommand actionSave
        {
            get
            {
                return _actionSave ?? (_actionSave = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(true);
                    CreateNewDepartment(new Department(-1, _departmentName, _departmentUniversity));
                }, _canExecute));
            }
        }

    }
}
