using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Cambia la camara al entrar en colision con el jugador
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
