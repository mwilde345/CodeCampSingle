using UnityEngine;
using System.Collections;

public class PacketAttributes : MonoBehaviour {

    public Material red, blue, green, yellow, purple, pink;
    public float speed;
    bool hasExpired;

    //Packet Object
    //GameObject po;
    Transform dst;
    packet packet;
    //Material material;
    
    public void init(packet packet, Transform src, Transform dst) {
        this.packet = packet;
        this.dst = dst;
        gameObject.transform.position = src.position;
        //material = yellow;
    }
	

    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        hasExpired = true;
    }


	public void Update() {
	    if(!hasExpired) {
            gameObject.transform.LookAt(dst);
            gameObject.transform.Translate(Vector3.forward * speed, Space.Self);
        }
	}
    public packet getRaw() {
        return packet;
    }
    public bool checkExpirationDate() {
        return hasExpired;
    }
}
