using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class FilterData
{


    //Test stuff 
   

    // Returns a packet list of the first occurance of each unique ipSource 
    static List<packet> uniqueSourceIPs(List<packet> pktLst)
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

    static List<string> uniqueIpSrcStrings(List<packet> pktLst)
    {
        List<string> uniqueIPList = new List<string>();
        while (pktLst.Count != 0)
        {
            packet p = pktLst.First();
            Console.WriteLine(p.ipSource);
            pktLst = pktLst.Where(x => !x.ipSource.Trim().Contains(p.ipSource.Trim())).ToList();
            uniqueIPList.Add(p.ipSource);
        }
        return uniqueIPList;
    }

    static List<string> uniqueIpDestStrings(List<packet> pktLst)
    {
        List<string> uniqueIPList = new List<string>();
        while (pktLst.Count != 0)
        {
            packet p = pktLst.First();
            Console.WriteLine(p.ipDest);
            pktLst = pktLst.Where(x => !x.ipDest.Trim().Contains(p.ipDest.Trim())).ToList();
            uniqueIPList.Add(p.ipDest);
        }
        return uniqueIPList;
    }

    public static List<string> allUniqueIPs (List<packet> pktLst)
    {
        List<string> srcIps = uniqueIpSrcStrings(pktLst);
        List<string> destIps = uniqueIpDestStrings(pktLst);
        srcIps.AddRange(destIps);
        return srcIps;


    }


    static List<packet> findOccurances(string uniqueIP, List<packet> pktLst)
    {
        pktLst = pktLst.Where(x => x.ipSource.Trim().Contains(uniqueIP.Trim())).ToList();
        return pktLst;
    }
     

}
