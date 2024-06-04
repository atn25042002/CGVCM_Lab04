using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoxStatic : MonoBehaviour
{
    public Camera CameraOut;
    public Camera CameraIn;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el usuario ingreso al trigger
        if (other.CompareTag("Player"))
        {
            // Activa Camera2 y desactiva Camera1
            CameraOut.enabled = false;
            CameraIn.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el usuario salio del trigger
        if (other.CompareTag("Player"))
        {
            // Reactiva Camera1 y desactiva Camera2
            CameraOut.enabled = true;
            CameraIn.enabled = false;
        }
    }
}
