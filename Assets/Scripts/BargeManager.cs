using UnityEngine;

public class BargeManager : MonoBehaviour
{

    public int totalPollutedDirt;
    public int totalNormalDirt;
    public int totalFish;
    public PlayerInventory inv;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject boat = GameObject.Find("Boat");
        if (boat == null) {
            Debug.Log("Boat reference is missing... Could not retrieve currency data.");
        }

        inv = boat.GetComponent<PlayerInventory>();
        if (boat == null) {
            Debug.Log("Player Inventory reference is missing... Could not retrieve currency data.");
        }

        GameObject[] contaminants = GameObject.FindGameObjectsWithTag("ContaminatedDirt");
        if (contaminants == null) {
            Debug.Log("No contaminants detected!");
        }
        totalPollutedDirt = contaminants.Length;

        GameObject[] dirts = GameObject.FindGameObjectsWithTag("CleanDirt");
        if (dirts == null) {
            Debug.Log("No normal dirt detected!");
        }
        totalNormalDirt = dirts.Length;

        GameObject[] fishes = GameObject.FindGameObjectsWithTag("Fish");
        if (fishes == null) {
            Debug.Log("No fish detected!");
        }
        totalFish = fishes.Length;

        // Debog test money transfer between scenes
        // inv.UpdateCurrency(1337);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPollutedDirt <= 0) {
            endScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject.Destroy(other.gameObject);
    }

    private void endScene() {
        Debug.Log("End Scene!");
    }
}
