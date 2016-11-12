using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class FilterData
{


    //Test stuff 
    static void Main(string[] args)
    {
        ReadInPacketsComma test = new ReadInPacketsComma(@"C:\Users\Sara\Documents\tst");
        List<packet> pktLst = test.packetLst;

        List<packet> testOcc = findOccurances("144.38.26.51", pktLst);
        for (int i = 0; i < testOcc.Count; i++)
        {
            Console.WriteLine(testOcc[i].num + " " + testOcc[i].ipDest);
        }


    }

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


    static List<packet> findOccurances(string uniqueIP, List<packet> pktLst)
    {
        pktLst = pktLst.Where(x => x.ipSource.Trim().Contains(uniqueIP.Trim())).ToList();
        return pktLst;
    }


}
