using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_sprinter.view.popUp;
using static System.Net.Mime.MediaTypeNames;

namespace WPF_sprinter
{
    public class PopUp
    {
        public void ShowAlert(string text = "", bool BackToMV = false)
        {
            try
            {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    new Alert(text).ShowDialog();
                });
                if (BackToMV)
                {
                    AppDelegate.Instance.Context.CurrentPageViewModel = AppDelegate.Instance.MW;
                    AppDelegate.Instance.MW.UniversitiesViewModel();
                    AppDelegate.Instance.Context.UpdateTitle();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public bool ShowConfirmedAlert(string text = "")
        {
            bool accept = false;
            try
            {
                System.Windows.Application.Current.Dispatcher.Invoke((Action)delegate
                {
                    ConfirmedAlert confAlert = new ConfirmedAlert(text);
                    confAlert.ShowDialog();
                    accept = confAlert.accept;
                });
                return accept;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return accept;
            }
        }
    }
}
