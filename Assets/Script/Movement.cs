using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotationSpeed = 120.0f;
    private Vector3 moveDirection = Vector3.zero;
    private bool onGround= false;

    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (onGround)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }else{
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
        
    }

    void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");

        // Determinar la dirección de rotación basada en la entrada del usuario
        if (horizontalInput != 0)
        {
            float rotationStep = rotationSpeed * Time.deltaTime * horizontalInput;
            transform.Rotate(0, rotationStep, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            print("En suelo");
            onGround= true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Verificar si el objeto ha dejado de colisionar con el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround= false;
        }
    }
}