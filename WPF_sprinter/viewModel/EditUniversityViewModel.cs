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
    public class EditUniversityViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Edit university";
            }
        }
        private int _universityId;
        private string _universityName;
        private string _universityAddress;
        private int _universityLevel;

        private bool _canExecute;

        private string saved;

        public string Saved
        {
            get { return saved; }
        }

        public async Task EditUniversity(University university)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.EditUniversity(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(false);
                    AppDelegate.Instance.Alert.ShowAlert("University successfully edited! No errors reported.", true);
                },
                university);
            });
        }

        public string universityName
        {
            get { return _universityName; }
            set
            {
                _universityName = value;
            }
        }
        public string universityAddress
        {
            get { return _universityAddress; }
            set
            {
                _universityAddress = value;
            }
        }
        public int universityLevel
        {
            get { return _universityLevel; }
            set
            {
                _universityLevel = value;
            }
        }

        private ICommand _actionSave;
        
        public EditUniversityViewModel(University university)
        {
            _canExecute = true;
            _universityId = university.Id;
            _universityAddress = university.Address;
            _universityName = university.Name;
            _universityLevel = university.Level;
        }

        public ICommand actionSave
        {
            get
            {
                return _actionSave ?? (_actionSave = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(true);
                    University data = new University(_universityId, _universityName, _universityAddress, _universityLevel, null);
                    if (new Validation().Validate(data))
                    {
                        EditUniversity(data);
                    }
                }, _canExecute));
            }
        }
    }
}
