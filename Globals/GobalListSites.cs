
using System.Collections.Generic;
using QuickPing2.Classs;
using QuickPing2.Utils;

namespace QuickPing2.Globals
{
   

    public static class GobalListSites
    {
        static JSONHanlder sites = new JSONHanlder();
        static public  List<Site> allSites = sites.JsonToList();

    }
}
