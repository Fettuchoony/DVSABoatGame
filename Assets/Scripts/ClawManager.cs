using UnityEngine;

public class ClawManager : MonoBehaviour
{

    public Transform bucket;
    public Transform leftClaw;
    public Transform rightClaw;
    public Transform leftCast;
    public Transform rightCast;
    public float clawTranslateSpeed;

    public Rigidbody2D rb;
    [Range(0f, 1f)] public float rotSpeed;
    [Range(0f, 1f)] public float translateSpeed;

    private Vector2 deltaVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deltaVelocity = Vector2.zero;
    }

    void FixedUpdate() {

        // Left claw control
        // Close
        if (Input.GetKey("a") && leftClaw.eulerAngles.z < 358f) {
            leftClaw.Rotate(new Vector3(0f, 0f, 1f * rotSpeed));
        }
        // Open
        if (Input.GetKey("d") && leftClaw.eulerAngles.z > 315f) {
            leftClaw.Rotate(new Vector3(0f, 0f, -1f * rotSpeed));
        }

        // Right claw control
        // Close
        if (Input.GetKey("a") && rightClaw.eulerAngles.z > 2f) {
            rightClaw.Rotate(new Vector3(0f, 0f, -1f * rotSpeed));
        }
        // Open
        if (Input.GetKey("d") && rightClaw.eulerAngles.z < 45f) {
            rightClaw.Rotate(new Vector3(0f, 0f, 1f * rotSpeed));
        }

        Vector2 currVel = rb.linearVelocity;

        // left/right translation of claw
        if (Input.GetKey("left") && (currVel.x > -translateSpeed)) {
            deltaVelocity = currVel +  new Vector2(rb.linearVelocity.x - 1f, 0);
        }

        if (Input.GetKey("right") && (currVel.x < translateSpeed)) {
            deltaVelocity = currVel +  new Vector2(rb.linearVelocity.x + 1f, 0);
        }

        // up/down translation of claw
        if (Input.GetKey("up") && (currVel.y < translateSpeed)) {
            deltaVelocity = currVel +  new Vector2(0, rb.linearVelocity.y + 1f);
        }

        if (Input.GetKey("down") && (currVel.y > -translateSpeed)) {
            deltaVelocity = currVel +  new Vector2(0, rb.linearVelocity.y - 1f);
        }


        int layerMask = LayerMask.GetMask("Terrain");

        
        // bool left = Physics2D.Raycast(leftCast.position, -Vector2.up, 0.01f, layerMask, -0.1f, 0.1f);
        // bool right = Physics2D.Raycast(rightCast.position, -Vector2.up, 0.01f, layerMask, -0.1f, 0.1f);
        // Debug.DrawRay(leftCast.position, -Vector2.up, Color.green);
        
        // if (left|| right) {
        //     transform.position += new Vector3(0f, 0.05f, 0f);
        // }
        
    }

    void Update() { 
        
        rb.linearVelocity = rb.linearVelocity + deltaVelocity;
        if (rb.linearVelocity.x > translateSpeed || rb.linearVelocity.x < -translateSpeed) { 
            rb.linearVelocity = new Vector2(rb.linearVelocity.x/rb.linearVelocity.x, 0);
        }
        if (rb.linearVelocity.y > translateSpeed || rb.linearVelocity.y < -translateSpeed) { 
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y/rb.linearVelocity.y);
        }
        rb.linearVelocity = 0.95f * rb.linearVelocity;


        // Check for terrain collisions
        // int layerMask = LayerMask.GetMask("Terrain");

        // bool left = Physics2D.Raycast(leftCast.position, -Vector2.up, 0.01f, layerMask, -0.1f, 0.1f);
        // bool right = Physics2D.Raycast(rightCast.position, -Vector2.up, 0.01f, layerMask, -0.1f, 0.1f);
        // Debug.DrawRay(leftCast.position, -Vector2.up, Color.green);
        
        // if (left|| right) {
        //     transform.position += new Vector3(0f, 0.01f, 0f);
        // }
    }



    // void OnCollisionStay(Collision collision) {
    //     Debug.Log("Bonk!");

    //     // Grab collision data of other object to detect if it is terrain
    //     Collider otherCollision = collision.contacts[0].otherCollider;

    //     // Bonk on terrain collisions
    //     if (otherCollision.tag == "Terrain") {
    //         transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0f);
    //     }
    // }

    
}
