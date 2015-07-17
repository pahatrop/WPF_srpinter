using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_sprinter
{
    public class MainViewModel : ObservableObject
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        private Visibility _loader = Visibility.Hidden;
        private string titleText;

        public string TitleText
        {
            get
            {
                return titleText;
            }
            set
            {
                titleText = value;
            }
        }
        public Visibility Preloader
        {
            get
            {
                return _loader;
            }
        }
        public void UpdateTitle()
        {
            titleText = _currentPageViewModel.Name;
            RaisePropertyChanged("TitleText");
        }
        
        public void ChangeLoaderVisible(bool visible = false)
        {
            if (visible)
            {
                _loader = Visibility.Visible;
            }
            else
            {
                _loader = Visibility.Hidden;
            }
            RaisePropertyChanged("Preloader");
        }
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    RaisePropertyChanged("CurrentPageViewModel");
                }
            }
        }
        public MainViewModel()
        {
            CurrentPageViewModel = new MainWindowViewModel();
            titleText = _currentPageViewModel.Name;
            RaisePropertyChanged("Preloader");
            RaisePropertyChanged("CurrentPageViewModel");
        }
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }
    }
}
