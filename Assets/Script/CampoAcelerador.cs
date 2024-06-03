using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoAcelerador : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BasicMovement>().Accelerate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BasicMovement>().Decelerate();
        }
    }
}
