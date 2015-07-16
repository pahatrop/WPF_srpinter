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
    public class CreateUniversityViewModel : MainViewModel
    {
        private string _universityName;
        private string _universityAddress;
        private int _universityLevel;

        private bool _canExecute;

        private string saved;

        public string Saved
        {
            get { return saved; }
        }


        public async Task CreateNewUniversity(University university)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewUniversity(() =>
                {
                    saved = "Saved!";
                    RaisePropertyChanged("Saved");
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

        private ICommand _actionCreateUniversity;

        public CreateUniversityViewModel()
        {
            _canExecute = true;
        }

        public ICommand actionCreateUniversity
        {
            get
            {
                return _actionCreateUniversity ?? (_actionCreateUniversity = new CommandHandler(() =>
                {
                    saved = "Loading...";
                    RaisePropertyChanged("Saved");
                    CreateNewUniversity(new University(-1, _universityName, _universityAddress, _universityLevel));
                }, _canExecute));
            }
        }
 

    }
}
