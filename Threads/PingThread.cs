using QuickPing2.Classs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;

namespace QuickPing2.Threads
{
    public class PingThread
    {
       public static void DoWork()
        {
            List<Site> allSites = Globals.GobalListSites.allSites;

            allSites.ForEach(site => {
                site.Hosts.ForEach(host => {

                    var BGPing = new Thread(() =>
                    {
                        Debug.WriteLine($"Starting BGPing for {host.Name}@{host.Address} in {site.Name}");
                        BackgroundPing(host.Address, site.Name);
                    });
                    BGPing.Start();
                });
            });
        }
        
       public static void BackgroundPing(string address, string siteName)
        {
            while (true)
            {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                options.DontFragment = true;
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                PingReply reply = pingSender.Send(address, timeout, buffer, options);
                
                int indexSite = Globals.GobalListSites.allSites.FindIndex(x => x.Name == siteName);
                int indexHost = Globals.GobalListSites.allSites[indexSite].Hosts.FindIndex(x => x.Address == address);
                
                if (reply.Status == IPStatus.Success)
                {
                    Globals.GobalListSites.allSites[indexSite].Hosts[indexHost].LastSucces = DateTime.Now.ToString("h:mm:ss tt");
                    Globals.GobalListSites.allSites[indexSite].Hosts[indexHost].Status = "Reachable";
                    
                }
                else
                {
                    Globals.GobalListSites.allSites[indexSite].Hosts[indexHost].LastFail = DateTime.Now.ToString("h:mm:ss tt");
                    Globals.GobalListSites.allSites[indexSite].Hosts[indexHost].Status = "Not Reachable";
                   
                }
            }
        }
    }
}
