using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform pointA; // Punto inicial
    public Transform pointB; // Punto final
    public float speed = 1.0f; // Velocidad de movimiento

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingToB = true;

    private void Start()
    {
        // Inicializar las posiciones de los puntos
        startPosition = pointA.position;
        endPosition = pointB.position;
    }

    private void Update()
    {
        if (movingToB)
        {
            // Mover hacia el punto B
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

            // Si llega al punto B, cambia la dirección
            if (transform.position == endPosition)
            {
                movingToB = false;
            }
        }
        else
        {
            // Mover hacia el punto A
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            // Si llega al punto A, cambia la dirección
            if (transform.position == startPosition)
            {
                movingToB = true;
            }
        }
    }
}
