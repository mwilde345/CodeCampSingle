using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Network : MonoBehaviour {

    public GameObject port;
    public GameObject visualPacket;
    public float radius;

    List<GameObject> active;
    List<packet> queued;
    List<packet> logged;
    GameObject[] ports;
    string[] ips;

	void Start () {
        active = new List<GameObject>();
        logged = new List<packet>();
        ReadInPacketsComma rip = new ReadInPacketsComma( "Assets/PacketData/test.csv" );
        queued = rip.packetLst;
        initPorts();
    }

    void initPorts() {
        //Get total number of ports to be simulated;
        //Get an String array of ips
        //ips = FilterData.uniqueSourceIPs(queued).ToArray();
        ips = FilterData.allUniqueIPs( queued ).ToArray();
        if (ips.Length < 1) {
            print( "Problem with unique ips array" );
            return;
        }
        ports = new GameObject[ips.Length];
        Vector3[] portPoints = PortInit.initPortPoints( radius, ips.Length );
        for (int i = 0; i < portPoints.Length; i++) {
            GameObject portInstance = Instantiate( port );
            portInstance.transform.FindChild( "IP" ).GetComponent<TextMesh>().text = ips[i];
            portInstance.transform.position = portPoints[i];
            portInstance.transform.LookAt( GameObject.FindGameObjectWithTag( "Center" ).transform );
            portInstance.transform.rotation *= Quaternion.Euler( 90, 0, 0 );
            ports[i] = portInstance;
        }
    }

    //Null for unfound ip
    Transform getPortFromIP(string ip) {
        for(int i = 0; i < ips.Length; i++) {
            if (ips[i].Equals( ip )) return ports[i].transform;
        }
        return null;
    }
    

    void Update() {
        if (active.Count < 1) {
            if (queued.Count > 0) {
                packet current = queued[0];
                if (current != null) {
                    Transform src = getPortFromIP( current.ipSource );
                    Transform dst = getPortFromIP( current.ipDest );
                    if (src != null) {
                        GameObject packetInstance = Instantiate( visualPacket );
                        packetInstance.GetComponent<PacketAttributes>().init( current, src, dst );
                    }
                }
                logged.Add( current );
                queued.Remove( current );
            }
        }else {
            //Might have to to a clean up for the list
        }
    }

}