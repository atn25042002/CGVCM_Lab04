using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTopFollowCamera : MonoBehaviour
{
    // camera will follow this object
    public Transform target;
    //camera transform
    public Transform camTransform;
    // change this value to get desired smoothness
    public float smoothTime = 0.3f;
    // offset between camera and target
    private Vector3 offset;
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;
    private float yVelocity = 0.0f;

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
    }

    private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = target.position + offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // update rotation
        // Obtener las rotaciones actuales y deseadas
        float currentYAngle = camTransform.eulerAngles.y;
        float targetYAngle = target.eulerAngles.y;

        // Suavizar el ángulo Y utilizando SmoothDampAngle
        float smoothYAngle = Mathf.SmoothDampAngle(currentYAngle, targetYAngle, ref yVelocity, smoothTime);

        // Crear un nuevo Quaternion con la rotación suavizada en Y
        Quaternion smoothRotation = Quaternion.Euler(camTransform.eulerAngles.x, smoothYAngle, camTransform.eulerAngles.z);

        // Asignar la nueva rotación al objeto
        camTransform.rotation = smoothRotation;
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
