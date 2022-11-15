using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using QuickPing2.Classs;

namespace QuickPing2.Utils
{
    internal class JSONHanlder
    {
        public List<Site> sites = new List<Site>();
        public List<Host> hosts = new List<Host>();
        public List<Site> JsonToList() // Convert Json file to List Object
        {
            JObject? o1 = JObject.Parse(File.ReadAllText("Config/ips.json"));
            foreach (JToken site in o1["config"]["sites"])
            {

                foreach (JToken ip in site["ips"])
                {
                    hosts.Add(new Host { Name = ip["name"].ToString(), Address = ip["address"].ToString() });
                }
                sites.Add(new Site { Name = site["name"].ToString(), NetworkAddress = site["network"]?["address"]?.ToString(), NetworkMask = site["network"]?["netmask"]?.ToString(), Gateway = site["network"]?["gatway"]?.ToString(), Hosts = hosts });

            }

            return sites;
        }

    }
}
