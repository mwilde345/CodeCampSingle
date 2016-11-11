using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class FilterData
{
    

    //Test stuff 
    static void Main (string [] args)
    {
        ReadInPacketsComma test = new ReadInPacketsComma(@"C:\Users\Sara\Documents\tst");
        List <packet> pktLst = test.packetLst;
        List<packet> uniqeScIps = uniqueSourceIPs(pktLst);
        
    }

    // Returns a packet list of the first occurance of each unique ipSource 
    static List<packet> uniqueSourceIPs (List<packet> pktLst)
    {
        List<packet> uniqueIPList = new List<packet>();
        while (pktLst.Count != 0)
        {
            packet p = pktLst.First();
            Console.WriteLine(p.ipSource);
            for (int i = 0; i < pktLst.Count; i++)
            {
                if (pktLst[i].ipSource.Trim().Contains(p.ipSource.Trim()))
                {
                    pktLst.Remove(pktLst[i]);
                }
            }
            uniqueIPList.Add(p);
        }
        return uniqueIPList; 
        
    }




}
