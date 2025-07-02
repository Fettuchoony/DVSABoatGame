using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterPhysics2D : MonoBehaviour
{

    private Rigidbody2D rb;
    private BargeManager barge;
    private Scene currScene;
    private string tag;
    private float lastSway;
    private float swayDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swayDir = 1;
        lastSway = 0f;
        currScene = SceneManager.GetActiveScene();
        tag = gameObject.tag;
        rb = GetComponent<Rigidbody2D>();

        if (rb == null) {
            Debug.Log("Water item is missing an rb!");
        }

        GameObject bargeObj = GameObject.FindWithTag("Barge");
        if (bargeObj == null) {
            Debug.Log("Barge is missing from a pollutant!");
        }
        if (bargeObj.GetComponent<BargeManager>() == null) {
            Debug.Log("Barge component missing  in water physics is missing from a pollutant!");
        } else {
            barge = bargeObj.GetComponent<BargeManager>();
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < -3 && !tag.Equals("Fish")) {
            rb.linearVelocity *= 0.8f;
            // Swaying water code
            if (currScene.name.Equals("Level7") || currScene.name.Equals("Level8") || currScene.name.Equals("Level9")) {
                if ((Time.time - lastSway) > 3f) {
                    swayDir *= -1f;
                    lastSway = Time.time;
                }
                rb.AddForce(new Vector2(swayDir * 1f, 0));
            }
        } 

    }

    public void TriggerScore() {
        if (tag.Equals("CleanDirt")) {
            barge.inv.UpdateCurrency(-1);
        } else if (tag.Equals("ContaminatedDirt")){
            barge.inv.UpdateCurrency(5);
        } else if (tag.Equals("Fish")) {
            barge.inv.UpdateCurrency(-10);
        } else if (tag.Equals("Extinguisher")) {
            barge.inv.UpdateCurrency(10);
        } else if (tag.Equals("Chip")) {
            barge.inv.UpdateCurrency(15);
        }
    }

    // Count submissions of particles
    void OnDisable() {

        if (tag.Equals("CleanDirt")) {
            barge.totalNormalDirt--;
        } else if (tag.Equals("ContaminatedDirt")){
            barge.totalPollutedDirt--;
        } else if (tag.Equals("Fish")) {
            barge.totalFish--;
        } else if (tag.Equals("Extinguisher")) {
            barge.totalExtinguisher--;
        } else if (tag.Equals("Chip")) {
            barge.totalChips--;
        }

    }
}
