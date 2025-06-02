using UnityEngine;

public class WaterPhysics2D : MonoBehaviour
{

    public Rigidbody2D rb;
    public BargeManager barge;
    private string tag;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tag = gameObject.tag;
        rb = GetComponent<Rigidbody2D>();

        if (rb == null) {
            Debug.Log("Water item is missing an rb!");
        }

        barge = GameObject.FindWithTag("Barge").GetComponent<BargeManager>();
    }

    void FixedUpdate()
    {
        if (transform.position.y < -3) {
            rb.linearVelocity *= 0.8f;
        } 
    }

    // Count submissions of particles
    void OnDestroy() {

        if (tag.Equals("CleanDirt")) {
            barge.totalNormalDirt--;
            barge.inv.UpdateCurrency(-1);
        } else if (tag == "ContaminatedDirt"){
            barge.totalPollutedDirt--;
            barge.inv.UpdateCurrency(5);
        } else if (tag == "Fish") {
            barge.totalFish--;
            barge.inv.UpdateCurrency(-10);
        }

    }
}
