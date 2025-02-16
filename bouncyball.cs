using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float minY = -5.5f;  // Y position at which ball resets
    public float maxVelocity = 15f;  // Maximum velocity the ball can reach

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reset the ball's position and linear velocity if it falls below the screen
        if (transform.position.y < minY)
        {
            transform.position = Vector3.zero;
            rb.linearVelocity = Vector2.zero;  // Use linearVelocity instead of velocity
        }

        // Clamp the ball's velocity to prevent it from getting too fast
        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxVelocity);  // Use linearVelocity instead of velocity
        }
    }

    // This function handles collisions with objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            // Destroy the brick on collision with the ball
            Destroy(collision.gameObject);
        }
    }
}
