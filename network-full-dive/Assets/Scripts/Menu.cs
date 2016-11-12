using UnityEngine;
using System.Collections;

public class Menu : VRGUI {


    public override void OnVRGUI() {
        GUILayout.BeginArea( new Rect( 0f, 0f, Screen.width, Screen.height ) );
        if (GUILayout.Button("Click Me!")) {
            //
        }

        GUILayout.EndArea();
    }

}
