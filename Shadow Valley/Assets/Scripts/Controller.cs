using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    Vector3 jump;
    public float jumpForce = 2.0f;
    bool isGrounded;
    Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0, jumpForce, 0);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void OnCollisionExit(){
        isGrounded = false;
    }

    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, 0);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Jump();
        }
    }

    void Jump(){
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    }
}
