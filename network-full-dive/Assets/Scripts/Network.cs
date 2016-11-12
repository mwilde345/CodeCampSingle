using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Network : MonoBehaviour {

    public GameObject port;
    public float radius;

    List<PacketAttributes> active;
    List<packet> queued;
    List<packet> logged;
    GameObject[] ports;
    string[] ips;

	void Start () {
        active = new List<PacketAttributes>();
        ReadInPacketsComma rip = new ReadInPacketsComma( "Assets/PacketData/test.csv" );
        queued = rip.packetLst;
        initPorts();
    }


    //Null for unfound ip
    Transform getPortFromIP(string ip) {
        for(int i = 0; i < ips.Length; i++) {
            if (ips[i].Equals( ip )) return ports[i].transform;
        }
        return null;
    }


    void initPorts() {
        //Get total number of ports to be simulated;
        //Get an String array of ips
        //ips = FilterData.uniqueSourceIPs(queued).ToArray();
        //List<packet> unique = FilterData.uniqueSourceIPs();
        //for (int i = 0; i < unique.Count; i++) {
         //   ips[i] = packet.
        //s}
        if (ips.Length < 1) return;
        Vector3[] portPoints = PortInit.initPortPoints( radius, ips.Length );
        for (int i = 0; i < portPoints.Length; i++) {
            GameObject portInstance = Instantiate( port );
            portInstance.transform.position = portPoints[i];
            portInstance.transform.LookAt( GameObject.FindGameObjectWithTag("Center").transform );
            portInstance.transform.rotation *= Quaternion.Euler( 90, 0, 0 );
        }
    }

    void Update() {
        if (active.Count < 1) {
            packet current = queued[0];
            active.Add( new PacketAttributes( current, getPortFromIP(current.ipDest).transform ) );
            logged.Add(current);
            queued.Remove(current);
        }else {
            foreach (PacketAttributes pa in active) {
                if (pa.checkExpirationDate()) active.Remove(pa);
            }
        }
    }

}