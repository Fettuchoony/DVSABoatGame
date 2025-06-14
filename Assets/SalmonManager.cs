using UnityEngine;

public class SalmonManager : MonoBehaviour
{

    private Rigidbody2D rb;
    public int swimSpeed;
    private float nextMove = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null) {
            Debug.Log("Salmon is missing an rb!");
        }
        Random.InitState((int) transform.position.x);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        if (Time.time > nextMove) {
            rb.AddForce(new Vector2(swimSpeed * (Random.value - 0.5f),  swimSpeed * (Random.value - 0.5f)));
            nextMove = Time.time + 0.1f;
        }
        if (transform.position.y < -2.9f) {
            rb.linearVelocity *= 0.98f;
            rb.gravityScale = 0.01f;
            if (transform.position.y > -3.0f) {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -Mathf.Abs(rb.linearVelocity.y));
            }
        } else {
            rb.gravityScale = 1f;
        }
    }
}
