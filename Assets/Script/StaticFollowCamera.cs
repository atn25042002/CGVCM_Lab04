using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFollowCamera : MonoBehaviour
{
    // camera will follow this object
    public Transform target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        offset = camTransform.position - target.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {            
            MoveCameraBehindPlayer();
        }
        // Dirección del rayo desde la cámara hacia el jugador
        Vector3 directionToPlayer = target.position - transform.position;

        // Información del impacto del raycast
        RaycastHit hit;

        // Ejecutar el Raycast
        if (Physics.Raycast(transform.position, directionToPlayer, out hit))
        {
            // Comprobar si el objeto impactado tiene el tag "Obstaculo"
            if (hit.collider.CompareTag("Obstaculo"))
            {
                MoveCameraBehindPlayer();
            }
        }
    }

    private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = target.position + offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        //transform.LookAt(target);
    }

    void MoveCameraBehindPlayer()
    {        
        // Calcular la nueva posición de la cámara
        Vector3 newCameraPosition = target.position + target.TransformDirection(offset);

        // Mover la cámara a la nueva posición
        transform.position = newCameraPosition;

        // Asegurar que la cámara esté mirando al personaje
        transform.LookAt(target);
        offset = camTransform.position - target.position;
    }
}