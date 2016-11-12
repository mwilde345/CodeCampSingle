﻿using UnityEngine;
using System.Collections;

public class PlayerLookingAt : MonoBehaviour {

    public static string currentIP;

    void Update() {
        float length = 200.0f;
        RaycastHit hit;
        Vector3 rayDirection = transform.TransformDirection( Vector3.forward );
        Vector3 rayStart = transform.position + rayDirection;     // Start the ray away from the player to avoid hitting itself
        Debug.DrawRay( rayStart, rayDirection * length, Color.green );
        if (Physics.Raycast( rayStart, rayDirection, out hit, length )) {
            if (hit.collider.tag == "Port") {
                currentIP = hit.collider.gameObject.GetComponent<Node>().ip;
                print(currentIP);
            }
        }
    }
}