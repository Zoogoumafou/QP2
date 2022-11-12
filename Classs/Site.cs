using System.Collections.Generic;


namespace QuickPing2.Classs
{
    public class Site
    {

        public string? Name { get; set; }
        public string? NetworkAddress { get; set; }
        public string? NetworkMask { get; set; }
        public string? Gateway { get; set; }
        public List<Host>? Hosts { get; set; }

    }
}
