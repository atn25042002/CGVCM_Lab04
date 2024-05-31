using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Switch cameras when the trigger is entered by the player
            if (Camera1.enabled)
            {
                Camera1.enabled = false;
                Camera2.enabled = true;
            }
            else
            {
                Camera1.enabled = true;
                Camera2.enabled = false;
            }
        }
    }
}
