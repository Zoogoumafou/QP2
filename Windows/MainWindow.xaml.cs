﻿using QuickPing2;
using QuickPing2.Classs;
using QuickPing2.Utils;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using MahApps.Metro.Controls;


namespace QuickPing2.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        public void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
           
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
    
}
