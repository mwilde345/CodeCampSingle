using UnityEngine;
using System.Collections;

public class PacketAttributes : MonoBehaviour {

    public Material red, blue, green, yellow, purple, pink;
    public float speed;
    bool hasExpired;

    //Packet Object
    GameObject po;
    Transform dest;
    packet packet;
    Material material;

	public PacketAttributes(packet packet, Transform dest) {
        material = yellow;
        this.dest = dest;
    }
	

    void OnTriggerEnter(Collider other) {
        Destroy(po);
        hasExpired = true;
    }


	void Update () {
	    if(!hasExpired) {
            po.transform.LookAt(dest);
            po.transform.Translate(Vector3.forward * speed, Space.Self);
        }
	}
    public packet getRaw() {
        return packet;
    }
    public bool checkExpirationDate() {
        return hasExpired;
    }
}
