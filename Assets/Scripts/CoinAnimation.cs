using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    // Since the coin will use a rigid body to fall down, it will jump a random direction with this liimts
    public float jumpForce = 5f;
    public float minX = -4f;
    public float maxX = 4f;

    // Get the rigid body of the coin
    private Rigidbody2D rb;

    // get the rigid body and do the random jump
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        JumpRandomly();
    }

    // the random jump that the coin will do
    void JumpRandomly()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 jumpDirection = new Vector2(randomX - transform.position.x, 1).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    
    // The coin will despawn after goin outside the map
    void FixedUpdate()
    {
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
}
