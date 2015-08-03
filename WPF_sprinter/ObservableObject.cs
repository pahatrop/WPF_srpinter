﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPF_sprinter
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region Debugging Aides

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This 
        /// method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public virtual void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// Returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might 
        /// override this property's getter to return true.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        #endregion // Debugging Aides

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raises the PropertyChange event for the property specified
        /// </summary>
        /// <param name="propertyName">Property name to update. Is case-sensitive.</param>
        public virtual void RaisePropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members

        #region CancelButton
        private ICommand _actionCancel;
        private ICommand _actionCloseNotif;
        public ICommand actionCancel
        {
            get
            {
                return _actionCancel ?? (_actionCancel = new CommandHandler(() =>
                {
                    //AppDelegate.Instance.MW = new MainWindowViewModel();
                    AppDelegate.Instance.Context.CurrentPageViewModel = AppDelegate.Instance.MW;
                    AppDelegate.Instance.MW.UniversitiesViewModel();
                    AppDelegate.Instance.Context.UpdateTitle();
                }, true));
            }
        }
        public ICommand actionCloseNotif
        {
            get
            {
                return _actionCloseNotif ?? (_actionCloseNotif = new CommandHandler(() =>
                {
                    AppDelegate.Instance.Context.Notification();
                    AppDelegate.Instance.Context.UpdateTitle();
                }, true));
            }
        }
        #endregion

    }

}
