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
            
            for (int iy = 0; iy < allSites.Count; iy++)
            {
                Site site = allSites[iy];
                Debug.WriteLine($"From For One");
                for (int ix = 0; ix < site.Hosts.Count; ix++)
                {
                    Debug.WriteLine($"From For Two");
                    Host host = site.Hosts[ix];
                    string address = host.Address;
                    Debug.WriteLine($"{site.Name} host {host.Address}");
                    var TT = new Thread(() =>
                    {

                        Thread.CurrentThread.IsBackground = true;
                        Debug.WriteLine($" ------- Hey, I'm from background thread for IP: {address}");
                        BackgroundPing(iy, ix, address);
                        
                    });

                    TT.Start();
                }
                
            }
        }
        
       public static void BackgroundPing(int indexY, int indexX, string address)
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

                if (reply.Status == IPStatus.Success)
                {
                    //Debug.WriteLine($"{address} reply");
                  

                }
                else
                {
                    // Debug.WriteLine($"{address} do not reply");
                   
                }
            }
        }
    }
}
