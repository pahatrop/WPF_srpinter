using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLDataProvider;
using DataContracts;
using RESTDataProvider;
using Models;

namespace WPF_sprinter
{
    public sealed class AppDelegate
    {
        static readonly AppDelegate myInstance = new AppDelegate();
        
        public DataController dataController = new DataController(new RestDataProvider2());

        public MainViewModel Context;

        public MainWindowViewModel MW;

        public PopUp Alert = new PopUp();
        
        static AppDelegate() { }
        
        AppDelegate() { }

        public static AppDelegate Instance
        {
            get
            {
                return myInstance;
            }
        }
    }
}
