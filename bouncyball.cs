using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float minY = -5.5f;  
    public float maxVelocity = 15f;  // Maximum velocity the ball can reach

    private Rigidbody2D rb;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        // Resetting the ball's position and linear velocity if it falls below the screen
        if (transform.position.y < minY)
        {
            transform.position = Vector3.zero;
            rb.linearVelocity = Vector2.zero;  // Use linearVelocity instead of velocity
        }

        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxVelocity);  /
        }
    }

    // Function for handling collisions with objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            // Destroys the brick object when collided by ball
            Destroy(collision.gameObject);
        }
    }
}
