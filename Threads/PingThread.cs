using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuickPing2.Threads
{
    public class PingThread
    {
        public static void DoWork(string address)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            PingReply reply = pingSender.Send(address, timeout, buffer, options);

            if(reply.Status == IPStatus.Success)
            {

            }
        }
        
    }
}
