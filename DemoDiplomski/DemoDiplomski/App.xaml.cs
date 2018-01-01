using DemoDiplomski.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoDiplomski
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private void ApplicationStart(object sender, StartupEventArgs e)
        //{
        //    Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

        //    var dialog = new LoginDialog();
        //    if(dialog.ShowDialog() == true)
        //    {
        //        var mw = new MainWindow();
        //        Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        //        Current.MainWindow = mw;
        //        mw.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERROR");
        //        Current.Shutdown(-1);
        //    }
        //}

        //Hvatanje UI Thread errora
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.StackTrace, e.Exception.Message);
            if (System.Diagnostics.Debugger.IsAttached)
            {
                //////////////System.Diagnostics.Debugger.Break();
            }
            e.Handled = true;
        }

    }
}
