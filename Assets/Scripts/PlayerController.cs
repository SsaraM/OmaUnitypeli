using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 2500f;
    public float jump = 33f;
    public float gravityModifier;
    public bool isOnGround = true;

    private Rigidbody playerRb;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        // Move the player left to right
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * horizontalInput * Time.deltaTime *speed );

        // Make the player jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
        }

        // Keep the player inbounds
        if (transform.position.x < -12)
        {
            transform.position = new Vector3(-12, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 12)
        {
            transform.position = new Vector3(12, transform.position.y, transform.position.z);
        }

        // Game over
        if (transform.position.y > 46)
        {
            gameManager.GameOver();
        }

    }


    
    private void OnCollisionEnter(Collision collision)
    {
        // Prevent double jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        // Cloud enemies
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Tomato collectibles
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
        }
    }
}
