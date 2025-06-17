using UnityEngine;

public class DogDialogue4 : MonoBehaviour
{

    public int currLevel;
    private bool[] compLvls;
    private GameObject boat;
    private DialogueManager dialogue;
    private PlayerInventory inv;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject dialogueObj = GameObject.Find("Dialogue");
        if (dialogueObj == null) {
            Debug.Log("Could not find dialogue object from dog dialogue");
        }
        dialogue = dialogueObj.GetComponent<DialogueManager>();

        boat = GameObject.Find("Boat");
        if (boat == null) {
            Debug.Log("Could not find the player boat object from the dog dialogue script");
        }
        inv = boat.GetComponent<PlayerInventory>();
        if (boat == null) {
            Debug.Log("Could not find the player inventory from the dog dialogue script");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        compLvls = inv.completedLevels;
        if (other.tag == "Player") {
            // lvl 2
            if (currLevel == 6 && !compLvls[currLevel-1]) {
                Debug.Log("DT2");
                dialogue.toggleDialogue(true, 100 + 10*currLevel);
            }
            
        }
    }
}
