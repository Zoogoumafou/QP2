using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using QuickPing2.Classs;

namespace QuickPing2.Utils
{
    public static class JSONHanlder
    {
        public static List<Site> sites = new List<Site>();
        
        public static void JsonToList() // Convert Json file to List Object
        {
            JObject? o1 = JObject.Parse(File.ReadAllText("Config/ips.json"));
            foreach (JToken site in o1["config"]["sites"])
            {
                List<Host> hosts = new List<Host>();
                
                foreach (JToken ip in site["ips"])
                {
                    hosts.Add(new Host { Name = ip["name"].ToString(), Address = ip["address"].ToString() });
                    Debug.WriteLine($"Adding new host {ip["name"]} with {ip["address"]} has ip.");
                }
                
                sites.Add(new Site { Name = site["name"].ToString(), NetworkAddress = site["network"]?["address"]?.ToString(), NetworkMask = site["network"]?["netmask"]?.ToString(), Gateway = site["network"]?["gatway"]?.ToString(), Hosts = hosts });
                Globals.GobalListSites.allSites = sites;
            }

            
        }

    }
}
