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
             JSONHanlder sites = new JSONHanlder();
             List<Site> sitesList = sites.JsonToList();

            InitializeComponent();
            foreach (Site site in sitesList)
            {
                for (int i = 0; i < site.Hosts.Count; i++)
                {
                    Host host = site.Hosts[i];
                    Debug.WriteLine($"{site.Name} has the host {host.Name} with address of {host.Address}");
                }
            }
        }
    }
    
}
