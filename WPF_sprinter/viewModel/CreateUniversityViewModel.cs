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
    public class CreateUniversityViewModel : INotifyPropertyChanged
    {
        private int _universityId;
        private string _universityName;
        private string _universityAddress;
        private int _universityLevel;

        private bool _canExecute;

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
        private ICommand _actionEditUniversity;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

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
                    new XmlDataProvider().CreateNewUniversity(new University(-1, _universityName, _universityAddress, _universityLevel));
                }, _canExecute));
            }
        }
 

    }
}
