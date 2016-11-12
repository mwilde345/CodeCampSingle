using UnityEngine;
using System.Collections;

public class Menu : VRGUI {

    public string currentIP;

    public override void OnVRGUI() {
        if(GameState.isPaused()) {
            GUILayout.BeginArea( new Rect( 0f, 0f, Screen.width / 2, Screen.height / 2 ) );
            if (GUILayout.Button("Click Me!")) {
                //
            }

            GUILayout.EndArea();
        }



        currentIP = PlayerLookingAt.currentIP;
        print( Screen.height );
        GUILayout.BeginArea( new Rect( Screen.width / 2 - 250f, Screen.height / 2 + 120f,  120f, 20f ) );
        GUILayout.TextField(currentIP);
        GUILayout.EndArea();
    }

}
