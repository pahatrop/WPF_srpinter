﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_sprinter
{
    public sealed class AppDelegate
    {
        public DataController dataController = new DataController(new XmlDataProvider());

        static readonly AppDelegate myInstance = new AppDelegate();

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