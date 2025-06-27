using UnityEngine;
using Unity.Mathematics;
using UnityEngine.SocialPlatforms;

public class SalmonManager : MonoBehaviour
{

    private Rigidbody2D rb;
    public int swimSpeed;
    // public bool isBaitPresent = false;
    private float nextMove = 0f;
    private BaitManager baitManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baitManager = GameObject.Find("FishBait").GetComponent<BaitManager>();
        
        if (rb == null)
        {
            Debug.Log("Salmon is missing an rb!");
        }
        UnityEngine.Random.InitState((int) transform.position.x);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate()
    {
        if (Time.time > nextMove) {
            if (baitManager.isBaitPresent)
            {
                Vector2 position = transform.position;
                rb.AddForce(new Vector2(math.sign(baitManager.baitXPos - position.x)*5, math.sign(-2 - position.y)));
            }
            else
            {
                rb.AddForce(new Vector2(swimSpeed * (UnityEngine.Random.value - 0.5f), swimSpeed * (UnityEngine.Random.value - 0.5f)));
                nextMove = Time.time + 0.1f;
            }
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
