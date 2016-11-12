using UnityEngine;
using System.Collections;

public class PacketAttributes : MonoBehaviour {

    public Material red, blue, green, yellow, purple, pink;
    public AudioClip[] beeps;
    public float speed;
   
    Transform dst;
    packet packet;
    float timer;
    
    public void init(packet packet, Transform src, Transform dst) {
        this.packet = packet;
        this.dst = dst;

        transform.localScale *= (packet.length / 100);

        string protocol = packet.protocol;

        if(protocol.Equals(" TCP ")) GetComponent<Renderer>().material = red;
        else if (protocol.Equals( " UDP " )) GetComponent<Renderer>().material = blue;
        else if (protocol.Equals( " ARP " )) GetComponent<Renderer>().material = green;
        else if (protocol.Equals( " DHCP " )) GetComponent<Renderer>().material = yellow;
        else if (protocol.Equals( " SSDP" )) GetComponent<Renderer>().material = purple;
        else GetComponent<Renderer>().material = pink;

        gameObject.transform.position = src.position;
        initSound();
    }
    IEnumerator initSound() {
        int rand = (int) (6 * Random.value);
        AudioSource audSrc = GetComponent<AudioSource>();
        audSrc.Play();
        yield return new WaitForSeconds( audSrc.clip.length );
        audSrc.clip = beeps[rand];
        audSrc.Play();
        print(true);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Port") Terminate();
    }

    void Terminate() {
        if (timer >= 0.1f) Destroy( gameObject );
    }


	public void Update() {
        if(!GameState.isPaused()) {
            timer += Time.deltaTime;
            gameObject.transform.LookAt(dst);
            gameObject.transform.Translate(Vector3.forward * speed, Space.Self);
        } 
	}
    public packet getRaw() {
        return packet;
    }
}
