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
    public class CreateDepartmentViewModel : MainViewModel
    {
        private string _departmentName;
        private int _departmentUniversity;

        private bool _canExecute;

        private string saved;

        public string Saved
        {
            get { return saved; }
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

        private ICommand _actionCreateDepartment;

        public async Task CreateNewDepartment(Department department)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewDepartment(() =>
                {
                    saved = "Saved!";
                    RaisePropertyChanged("Saved");
                },
                department);
            });
        }

        public CreateDepartmentViewModel(int u)
        {
            _canExecute = true;
            _departmentUniversity = u;
        }

        public ICommand actionCreateDepartment
        {
            get
            {
                return _actionCreateDepartment ?? (_actionCreateDepartment = new CommandHandler(() =>
                {
                    saved = "Loading...";
                    RaisePropertyChanged("Saved");
                    CreateNewDepartment(new Department(-1, _departmentName, _departmentUniversity));
                }, _canExecute));
            }
        }

    }
}
