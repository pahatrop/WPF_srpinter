﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Models;
using WPF_sprinter.view.popUp;

namespace WPF_sprinter
{
    public class CreateUniversityViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Create university";
            }
        }
        private string _universityName;
        private string _universityAddress;
        private int _universityLevel;

        private bool _canExecute;


        public async Task CreateNewUniversity(University university)
        {
            await Task.Run(() =>
            {
                AppDelegate.Instance.dataController.CreateNewUniversity(() =>
                {
                    AppDelegate.Instance.Alert.ShowAlert("University successfully created! No errors reported.", true);
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

        public CreateUniversityViewModel()
        {
            _canExecute = true;
        }

        public ICommand actionSave
        {
            get
            {
                return _actionSave ?? (_actionSave = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.ChangeLoaderVisible(true);
                    University data = new University(-1, _universityName, _universityAddress, _universityLevel, null);
                    if (new Validation().Validate(data))
                    {
                        CreateNewUniversity(data);
                    }
                }, _canExecute));
            }
        }
    }
}
