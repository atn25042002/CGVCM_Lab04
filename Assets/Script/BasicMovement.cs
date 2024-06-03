using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Variables de movimiento
    public float speed = 12.0f;
    public float jumpForce = 5.0f;
    public float rotationSpeed = 100.0f;
    private Rigidbody rb;
    private bool isGrounded;
    private int countColision;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        countColision= 0;
    }

    void Update()
    {
    // Rotación del personaje
        float horizontalRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, horizontalRotation, 0);

        // Movimiento del personaje
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Salto del personaje
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }    
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el personaje está tocando el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            countColision++;
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verificar si el personaje dejó de tocar el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            countColision--;
            if(countColision == 0){
                print("bloquenado");
                isGrounded = false;
            }            
        }
    }

    public void Accelerate(){
        print("Acelerando");
        speed*= 2.0f;
    }
    
    public void Decelerate(){
        print("Desacelerando");
        speed/= 2.0f;
    }
}
