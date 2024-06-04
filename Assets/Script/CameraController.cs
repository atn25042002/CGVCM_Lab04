using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Camera> cameras;
    public Camera cameraDefault;
    public Transform target;
    public bool verificar= true;

    private int currentCameraIndex = 0;

    void Start()
    {
        EnabledCamera(currentCameraIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(verificar){
                DefaultCamera();
            }else{
                ReLoad();
            }
        }
        if(verificar){
            CheckCurrentCamera();
        }        
    }

    private void CheckCurrentCamera()
    {
        Camera currentCamera = cameras[currentCameraIndex];
        // Dirección del rayo desde la cámara hacia el jugador
        Vector3 directionToPlayer = target.position - currentCamera.transform.position;

        // Información del impacto del raycast
        RaycastHit hit;

        // Ejecutar el Raycast
        if (Physics.Raycast(currentCamera.transform.position, directionToPlayer, out hit))
        {
            // Comprobar si el objeto impactado tiene el tag "Obstaculo"
            if (!hit.collider.CompareTag("Player"))
            {
                SwitchCamera();
            }
        }
    }

    private void SwitchCamera()
    {
        DisabledCamera(currentCameraIndex); // Disable current camera

        currentCameraIndex++;
        
        if (currentCameraIndex >= cameras.Count)
        {
            DefaultCamera();
            currentCameraIndex= 0;
            return;
        }
        EnabledCamera(currentCameraIndex);
    }

    private void EnabledCamera(int index)
    {
        cameras[index].enabled = true;
        Debug.Log("Enabled Camera " + cameras[index].name);
    }

    private void DisabledCamera(int index)
    {
        cameras[index].enabled = false;
        Debug.Log("Disabled Camera " + cameras[index].name);
    }

    private void DefaultCamera(){
        verificar= false;
        cameraDefault.enabled = true;
    }

    public void ReLoad(){   
        cameraDefault.enabled = false;
        DisabledCamera(currentCameraIndex);
        currentCameraIndex = 0; // Reset to the first camera
        EnabledCamera(currentCameraIndex);
        verificar= true;        
    }
}
