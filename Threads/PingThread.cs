using QuickPing2.Classs;
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
            foreach (Site site in allSites)
            {
                for (int i = 0; i < site.Hosts.Count; i++)
                {
                    Host host = site.Hosts[i];
                    string address = host.Address;
                    Debug.WriteLine(address);
                    

                }
            }
        }
        
       public static void BackgroundPing(string address)
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
                    Debug.WriteLine($"{address} reply");
                }
                else
                {
                    Debug.WriteLine($"{address} do not reply");
                }
            }
        }
    }
}
