using QuickPing2.Classs;
using System.Windows;
using System.Collections.Generic;
using QuickPing2.Threads;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Threading;
using QuickPing2.Utils;

namespace QuickPing2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            JSONHanlder.JsonToList();
            Threads.PingThread.DoWork();

        }

      
    }

   
}
