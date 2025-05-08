using UnityEngine;

public class BuoyancyController : MonoBehaviour
{

    public GameObject parent;
    public Transform backLeft;
    public Transform backRight;
    public Transform forwardLeft;
    public Transform forwardRight;

    [Range(0,10)] public float buoyancy = 0f;

    private Rigidbody rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (transform.position.y < 0f) {
        //     Vector3 buoyancyVec = new Vector3(0f, buoyancy*9.81f*Mathf.Abs(transform.position.y), 0f);
        //     backLeftRB.AddForce(buoyancyVec);
        //     backRightRB.AddForce(buoyancyVec);
        //     forwardLeftRB.AddForce(buoyancyVec);
        //     forwardRightRB.AddForce(buoyancyVec);
        // }
        // if ((transform.position.y > 0f && rb.linearVelocity.y > 0f) || (transform.position.y < -0.5f && rb.linearVelocity.y < 0f)) {
        //     Vector3 vel = rb.linearVelocity;
        //     vel.y = vel.y * 0.9f;
        //     rb.linearVelocity = vel;
        // }
        // else {
        //     rb.linearDamping=0f;
        // }
        // if (forwardLeft.position.y < 0f) rb.AddForceAtPosition(Vector3.up * buoyancy * Mathf.Abs(forwardLeft.position.y), forwardLeft.position);
        // if (forwardRight.position.y < 0f) rb.AddForceAtPosition(Vector3.up * buoyancy * Mathf.Abs(forwardRight.position.y), forwardRight.position);
        // if (backLeft.position.y < 0f) rb.AddForceAtPosition(Vector3.up * buoyancy * Mathf.Abs(backLeft.position.y), backLeft.position);
        // if (backRight.position.y < 0f) rb.AddForceAtPosition(Vector3.up * buoyancy * Mathf.Abs(backRight.position.y), backRight.position);
        

            
            
    }

    void OnCollisionStay(Collision collision) {
        int contCount = collision.contactCount;
        foreach (ContactPoint contact in collision.contacts) {
            Vector3 pos = contact.point;
            rb.AddForceAtPosition(Vector3.up * buoyancy, pos);
            Debug.Log(pos); 
        }
        
    }

}
