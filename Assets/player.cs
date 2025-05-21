using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    
    public GameObject winCanvas;
    public GameObject deathCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        if (winCanvas != null) winCanvas.SetActive(false);
        if (deathCanvas != null) deathCanvas.SetActive(false);
    }

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        Vector3 forwardMovement = transform.forward * move * moveSpeed * Time.deltaTime;
        transform.position += forwardMovement;

        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);

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

        if (collision.gameObject.CompareTag("win"))
        {
            if (winCanvas != null) winCanvas.SetActive(true);
            Time.timeScale = 0f; 
        }
        else if (collision.gameObject.CompareTag("muerte"))
        {
            if (deathCanvas != null) deathCanvas.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("principal");
    }
}