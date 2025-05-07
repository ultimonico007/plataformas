using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento hacia adelante/atrás
        float move = Input.GetAxis("Vertical"); // W y S
        Vector3 forwardMovement = transform.forward * move * moveSpeed * Time.deltaTime;
        transform.position += forwardMovement;

        // Rotación izquierda/derecha
        float rotation = Input.GetAxis("Horizontal"); // A y D
        transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}