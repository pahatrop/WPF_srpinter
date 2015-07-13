﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_sprinter
{
    public class EditUniversityViewModel : INotifyPropertyChanged
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

        private ICommand _actionEditUniversity;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditUniversityViewModel(University university)
        {
            _canExecute = true;
            _universityId = university.Id;
            _universityAddress = university.Address;
            _universityName = university.Name;
            _universityLevel = university.Level;
        }

        public ICommand actionEditUniversity
        {
            get
            {
                return _actionEditUniversity ?? (_actionEditUniversity = new CommandHandler(() =>
                {
                    AppDelegate.Instance.dataController.EditUniversity(new University(_universityId, _universityName, _universityAddress, _universityLevel));

                }, _canExecute));
            }
        }
    }
}
