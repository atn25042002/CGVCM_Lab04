using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventChangeCamera : MonoBehaviour
{
    // Definir el delegado y el evento
    public delegate void ChangeCameraEventHandler();
    public event ChangeCameraEventHandler OnChangeCameraEvent;

    void Update()
    {
        // Emitir el evento cuando se presiona la tecla espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EmitChangeCameraEvent();
        }
    }

    // Método para emitir el evento
    protected virtual void EmitChangeCameraEvent()
    {
        OnChangeCameraEvent?.Invoke();
    }
}
