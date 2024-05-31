using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera[] cameras;
    // Start is called before the first frame update
    void Start()
    {
        cameras[0].gameObject.SetActive(true);
    }

    

    void OnEnable()
    {
    }

    void OnDisable()
    {
    }

    // Método que se llama cuando se emite el evento
    void HandleChangeCameraEvent()
    {
        Debug.Log("El evento ChangeCamera ha sido emitido.");
    }
}
