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
    float timer;
    //Material material;
    
    public void init(packet packet, Transform src, Transform dst) {
        this.packet = packet;
        this.dst = dst;
        gameObject.transform.position = src.position;

        int rand = (int)( 6f * Random.value);
        if(rand == 0) GetComponent<Renderer>().material = red;
        else if (rand == 1) GetComponent<Renderer>().material = blue;
        else if (rand == 2) GetComponent<Renderer>().material = green;
        else if (rand == 3) GetComponent<Renderer>().material = yellow;
        else if (rand == 4) GetComponent<Renderer>().material = purple;
        else if (rand == 5) GetComponent<Renderer>().material = pink;
    }
    void OnTriggerEnter(Collider other) {
        Terminate();
    }

    void Terminate() {
        if (timer >= 0.1f) Destroy( gameObject );
    }


	public void Update() {
        timer += Time.deltaTime;
        gameObject.transform.LookAt(dst);
        gameObject.transform.Translate(Vector3.forward * speed, Space.Self);
	}
    public packet getRaw() {
        return packet;
    }
    public bool checkExpirationDate() {
        return hasExpired;
    }
}
