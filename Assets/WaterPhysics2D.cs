using UnityEngine;

public class WaterPhysics2D : MonoBehaviour
{

    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null) {
            Debug.Log("Water item is missing an rb!");
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < -3) {
            rb.linearVelocity *= 0.8f;
        } 
    }
}
