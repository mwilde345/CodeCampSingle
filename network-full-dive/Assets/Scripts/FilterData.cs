using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class FilterData
{
    
    // Returns a packet list of the first occurance of each unique ipSource 
    public static List<packet> uniqueSourceIPs (List<packet> pktLst)
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
