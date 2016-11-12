using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class FilterData
{
    

    // Returns a packet list of the first occurance of each unique ipSource 
    static List<packet> uniqueSourceIPs (List<packet> pktLst)
    {
        List<packet> uniqueIPList = new List<packet>();
        while (pktLst.Count != 0)
        {
            packet p = pktLst.First();
            Console.WriteLine(p.ipSource);
            pktLst = pktLst.Where(x => !x.ipSource.Trim().Contains(p.ipSource.Trim())).ToList();
            uniqueIPList.Add(p);
        }
        return uniqueIPList; 
        
    }

    public static List<string> uniqueIpStrings (List<packet> pktLst)
    {
        List<string> uniqueIPList = new List<string>();
        while (pktLst.Count != 0)
        {
            packet p = pktLst.First();
            Console.WriteLine(p.ipSource);
            pktLst = pktLst.Where(x => !x.ipSource.Trim().Contains(p.ipSource.Trim())).ToList();
            uniqueIPList.Add(p.ipSource);
        }
        uniqueIPList.Sort();
        return uniqueIPList;
    }



    static void findDestinations(string uniqueIP)
    {
        
    }
<<<<<<< HEAD
     
=======
>>>>>>> origin/master

}
