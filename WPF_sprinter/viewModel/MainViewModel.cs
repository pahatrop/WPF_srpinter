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
        public List<string> ToBeRemoved = new List<string>();
        private int _notification = 0;
        private string titleText;
        private string notifText;

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
        public string NotifText
        {
            get
            {
                return notifText;
            }
        }
        public Visibility Preloader
        {
            get
            {
                return _loader;
            }
        }
        public int NotifVisibility
        {
            get
            {
                return _notification;
            }
        }
        public void UpdateTitle()
        {
            titleText = _currentPageViewModel.Name;
            RaisePropertyChanged("TitleText");
        }
        public void Notification(string text = "null")
        {
            if (text == "null")
            {
                _notification = 0;
            }
            else
            {
                _notification = 95;
            }
            notifText = text;
            RaisePropertyChanged("NotifVisibility");
            RaisePropertyChanged("NotifText");
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
            //foreach (Student p in new XMLDataProvider.XmlDataProvider().GetAllStudents())
            //{

                //foreach (Department department in new XMLDataProvider.XmlDataProvider().GetAllDepartments())
                //{
                    //for (int i = 0; i < 100; i++)
                    //{
                        //AppDelegate.Instance.dataController.EditStudent(null, new Student(p.Id, "Сергей", "Иванов", "Сергеевич", 1, p.Type, p.Department, p.Avatar));
                    //}
                //}
            //}
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
