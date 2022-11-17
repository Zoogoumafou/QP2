using QuickPing2.Classs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            int iy = 0;
            foreach (Site site in allSites)
            {
                iy++;
                for (int ix = 0; ix < site.Hosts.Count; ix++)
                {
                    Host host = site.Hosts[ix];
                    string address = host.Address;

                    new Thread(() =>
                    {

                        Thread.CurrentThread.IsBackground = true;
                        BackgroundPing(iy, ix, address);
                        Console.WriteLine($"Hey, I'm from background thread for IP: {address}");
                    }).Start();

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
                    Globals.GobalListSites.allSites[indexY].Hosts[indexX].Status = "Connected";
                    Globals.GobalListSites.allSites[indexY].Hosts[indexX].LastSucces = DateTime.Now.ToString("h:mm:ss tt");

                }
                else
                {
                    // Debug.WriteLine($"{address} do not reply");
                    Globals.GobalListSites.allSites[indexY].Hosts[indexX].Status = "Not Connected";
                    Globals.GobalListSites.allSites[indexY].Hosts[indexX].LastFail = DateTime.Now.ToString("h:mm:ss tt");
                }
            }
        }
    }
}
