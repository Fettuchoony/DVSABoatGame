using UnityEngine;

public class SalmonManager : MonoBehaviour
{

    public Rigidbody2D rb;
    public int swimSpeed;
    private float nextMove = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null) {
            Debug.Log("Salmon is missing an rb!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextMove) {
            rb.AddForce(new Vector2(swimSpeed * (Random.value - 0.5f),  swimSpeed * (Random.value - 0.5f)));
            nextMove = Time.time + 5f;
            Debug.Log(Time.time);
        }
        if (transform.position.y < -3) {
            rb.linearVelocity *= 0.999f;
        } else if (transform.position.y >= -3 && transform.position.y < -2.9f){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
        } else {
            rb.gravityScale = 1f;
        }
    }
}
