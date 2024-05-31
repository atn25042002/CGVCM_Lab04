using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFollowCamera : MonoBehaviour
{
    public Transform target; // El personaje que la cámara seguirá
    public float smoothSpeed = 0.125f; // La velocidad de suavizado para la rotación
    public Vector3 offset; // El desplazamiento inicial de la cámara

    private Vector3 initialOffset;

    private void Start()
    {
        // Calculamos el desplazamiento inicial entre la cámara y el objetivo
        initialOffset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculamos el desplazamiento según la orientación del objetivo
        offset = target.rotation * initialOffset;

        // Calculamos la posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;
        // Suavizamos la posición para que la cámara se mueva suavemente
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Actualizamos la posición de la cámara
        transform.position = smoothedPosition;

        // Rotamos la cámara para que mire hacia el objetivo
        transform.LookAt(target);

        // Si se presiona la tecla Q, la cámara se coloca inmediatamente detrás del objetivo
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }
}
