using UnityEngine;

public class BargeManager : MonoBehaviour
{

    private PlayerInventory inv;


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
        inv.UpdateCurrency(1337);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        string tag = other.tag;
        GameObject.Destroy(other.gameObject);

        if (tag.Equals("CleanDirt")) {
            inv.UpdateCurrency(-1);
        } else if (tag == "ContaminatedDirt"){
            inv.UpdateCurrency(5);
        } else if (tag == "Fish") {
            inv.UpdateCurrency(-10);
        }
    }
}
