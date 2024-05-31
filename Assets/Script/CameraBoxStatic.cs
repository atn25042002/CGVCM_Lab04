using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoxStatic : MonoBehaviour
{
    public Camera CameraOut;
    public Camera CameraIn;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Activate Camera2 and deactivate Camera1 when the player enters the trigger
            CameraOut.enabled = false;
            CameraIn.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Reactivate Camera1 and deactivate Camera2 when the player exits the trigger
            CameraOut.enabled = true;
            CameraIn.enabled = false;
        }
    }
}
