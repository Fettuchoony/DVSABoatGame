using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BargeManager : MonoBehaviour
{

    public int totalPollutedDirt;
    public int totalNormalDirt;
    public int totalFish;
    public int levelNum;
    private int initPollutedDirt;
    private int initNormalDirt;
    private int initFish;
    private DialogueManager dialogue;

    // Create Initial variables

    public GameObject costsUI;
    public PlayerInventory inv;
    public GameObject endGameScreen;
    public TextMeshProUGUI normalDirtSynopsis;
    public TextMeshProUGUI pollutedDirtSynopsis;
    public TextMeshProUGUI fishSynopsis;
    public TextMeshProUGUI totalEgg;
    public GameObject controlUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endGameScreen.SetActive(false);
        GameObject boat = GameObject.Find("Boat");
        if (boat == null) {
            Debug.Log("Boat reference is missing... Could not retrieve currency data.");
        }

        inv = boat.GetComponent<PlayerInventory>();
        if (boat == null) {
            Debug.Log("Player Inventory reference is missing... Could not retrieve currency data.");
        }

        // Find dialogue so we can start the text convo on main game reload
        GameObject dialogueCanvas = GameObject.Find("Dialogue");
        if (dialogueCanvas == null) {
            Debug.Log("Dialogue reference is missing... Could not retrieve textID data.");
        }
        dialogue = dialogueCanvas.GetComponent<DialogueManager>();
        if (dialogue == null) {
            Debug.Log("Dialogue compnent is missing... Could not retrieve class data from canvas.");
        }

        GameObject[] contaminants = GameObject.FindGameObjectsWithTag("ContaminatedDirt");
        if (contaminants == null) {
            Debug.Log("No contaminants detected!");
        }
        totalPollutedDirt = contaminants.Length;
        initPollutedDirt = totalPollutedDirt;

        GameObject[] dirts = GameObject.FindGameObjectsWithTag("CleanDirt");
        if (dirts == null) {
            Debug.Log("No normal dirt detected!");
        }
        totalNormalDirt = dirts.Length;
        initNormalDirt = totalNormalDirt;

        GameObject[] fishes = GameObject.FindGameObjectsWithTag("Fish");
        if (fishes == null) {
            Debug.Log("No fish detected!");
        }
        totalFish = fishes.Length;
        initFish = totalFish;

        // GameObject controlUI = GameObject.Find("Controls");
        // if (controlUI == null) {
        //     Debug.Log("No controls ui detected!");
        // }

        // Debog test money transfer between scenes
        // inv.UpdateCurrency(1337);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalPollutedDirt <= 0) {
            EndScene();
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        // if dirt
        if (other.gameObject.GetComponent<WaterPhysics2D>() != null) {
            other.gameObject.GetComponent<WaterPhysics2D>().TriggerScore();
            GameObject.Destroy(other.gameObject);
        }
    }

    private void EndScene() {
        Debug.Log("End Scene!");
        controlUI.SetActive(false);
        costsUI.SetActive(false);
        normalDirtSynopsis.text = "" + (initNormalDirt - totalNormalDirt) + " x -1" ;
        pollutedDirtSynopsis.text = "" + (initPollutedDirt - totalPollutedDirt) + " x 10";
        fishSynopsis.text = "" + (initFish - totalFish) + " x -10";
        endGameScreen.SetActive(true);
        inv.completedLevels[levelNum-1] = true;
    }   

    public void ExitScene() {
        dialogue.toggleDialogue(true, 10 * levelNum);
        SceneManager.LoadScene("MainGame");
    }
}
