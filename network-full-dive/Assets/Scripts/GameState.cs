using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    static bool pause = true;
    static float timer, reset = 0.18f;
    
    void Update() {
        if (timer >= reset) {
            if (Input.GetButton( "Start" )) {
                timer = 0f;
                pause = !pause;
                print( pause );
            }
        }
        else timer += Time.deltaTime;
    }
	
    public static bool isPaused() {
        return pause;
    }
}
