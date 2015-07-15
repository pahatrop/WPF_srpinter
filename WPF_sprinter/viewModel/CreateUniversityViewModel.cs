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
    public class CreateUniversityViewModel : INotifyPropertyChanged
    {
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

        delegate void MethodDelegate(University university);
        private void BtnCallback(IAsyncResult asyncRes)
        {
            AsyncResult ares = (AsyncResult)asyncRes;
            MethodDelegate delg = (MethodDelegate)ares.AsyncDelegate;
            saved = "Saved!";
            RaisePropertyChanged("Saved");
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
                    saved = "Loading...";
                    RaisePropertyChanged("Saved");
                    MethodDelegate sd = AppDelegate.Instance.dataController.CreateNewUniversity;
                    IAsyncResult asyncRes = sd.BeginInvoke(new University(-1, _universityName, _universityAddress, _universityLevel), new AsyncCallback(BtnCallback), null);
                }, _canExecute));
            }
        }
 

    }
}
