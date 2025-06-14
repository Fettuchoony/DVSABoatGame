using UnityEngine;

public class DogDialogue : MonoBehaviour
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

    void OnTriggerEnter() {
        compLvls = inv.completedLevels;
        // lvl 1
        if (currLevel == 1 && !compLvls[currLevel-1]) {
            // Nothing
        }
        // lvl 2
        if (currLevel == 2 && !compLvls[currLevel-1]) {
            Debug.Log("Dog triggered");
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
        // lvl 3
        if (currLevel == 3 && !compLvls[currLevel-1]) {
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
        // lvl 4
        if (currLevel == 4 && !compLvls[currLevel-1]) {
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
        // lvl 5
        if (currLevel == 5 && !compLvls[currLevel-1]) {
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
        // lvl 6
        if (currLevel == 6 && !compLvls[currLevel-1]) {
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
        // lvl 7
        if (currLevel == 7 && !compLvls[currLevel-1]) {
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
        // lvl 8
        if (currLevel == 8 && !compLvls[currLevel-1]) {
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
        // lvl 9
        if (currLevel == 9 && !compLvls[currLevel-1]) {
            dialogue.toggleDialogue(true, 100 + 10*currLevel);
        }
    }
}
