using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    // The parent for the whole 
    public GameObject textBox;
    public GameObject dialogueObject;
    public float dialogueFadeInSpeed;
    public Canvas canvasComp;

    private TextMeshProUGUI  dialogue;
    private int textID;
    private Dictionary<int, string> currDialogue;
    private GameObject dogImage;
    private GameObject salmonImage;
    private GameObject otterImage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Grab the images
        dogImage = GameObject.Find("DogImage");
        salmonImage = GameObject.Find("SalmonImage");
        otterImage = GameObject.Find("OtterImage");
        //Init the Dictionary
        currDialogue = new Dictionary<int, string>();
        //Get the textmeshpro object of the dialouge gameobject
        dialogue = dialogueObject.GetComponent<TextMeshProUGUI>();
        //Test text index is set to -1
        // currDialogue[-1] = "Edwin I want more Money!!!!";
        // Grab canvas so we can disable it
        // canvasComp = GetComponent<Canvas>();
        // if (canvasComp = null) {
        //     Debug.Log("Cant find canvas!");
        // }
        InitDialogue();
        toggleDialogue(true, textID);
    }

    IEnumerator animatedText(string text){
        // Terminate if Empty
        if (text.Equals("")) {
            yield return null;
        }
        dialogue.text = "";
        foreach(char c in text.ToCharArray()){
            dialogue.text += c;
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void ProgressText() {
        textID++;
        toggleDialogue(true, textID);
        if (currDialogue[textID].Equals("")) {
            // textBox.SetActive(false); deprecated
            canvasComp.enabled = false;
        }
    }

    public void disableDialogue() {
        canvasComp.enabled = false;
    }

    public void enableDialogue() {
        canvasComp.enabled = true;
    }

    public void toggleDialogue(bool enabled, int setID) {
        // textBox.SetActive(enabled); deprecated

        canvasComp.enabled = true;
        if (setID < 100) {
            switchDialogueImage("salmon");
        } else if (setID >= 100 && setID < 200) {
            switchDialogueImage("dog");
        } else {
            switchDialogueImage("otter");
        }

        dialogue.text = "";
        textID = setID;
        if(enabled){
            StopAllCoroutines();
            StartCoroutine(animatedText(currDialogue[setID]));
        }
    }

    public void changeDialogueID(int ID) {
        textID = ID;
    }

    private void InitDialogue(){
        // textBox.SetActive(true); deprecated
        canvasComp.enabled = true;
        textID = 0;
        // Format: currDialogue[] = "";
        
        currDialogue[0] = "Hello! Welcome to the Lower Duwamish River!";
        currDialogue[1] = "Way up the river, where the glaciers of Mount Rainier melt into the Green River, us Salmon are born.";
        currDialogue[2] = "However... Due to heavy pollution in the last century from surrounding industry, our population is threatened.";
        currDialogue[3] = "Please! Help us remove the contaminants like PCBs that have accumulated on the river floor.";
        currDialogue[4] = "If you remove contaminants I can give you salmon eggs, which you can spend at the shops around the river.";
        currDialogue[5] = "Press A and D to steer, W to propel forward, and S to reverse. Good Luck!";
        // Terminate text
        currDialogue[6] = "";
        
        // Completed 1st level dialogue
        currDialogue[10] = "That PFAs contaminated dirt stood no chance!";
        currDialogue[11] = "Further down the river you should find more cleanup sights.";
        currDialogue[12] = "Pollutants are detected by the PFAs sniffing dog, he will let you know when youre nearby a cleanup site.";
        currDialogue[13] = "";

        currDialogue[20] = "Great work!";
        currDialogue[21] = "While your work was successful, unfortunately contaminants still continue to flow into the river.";
        currDialogue[22] = "The water flows through the streets of South Park and Georgetown, picking up nasty contaminants and ejecting them into the river through the stormwater pipes.";
        currDialogue[23] = "Luckily there are several community organizations such as DVSA and government agencies such as the Enivronmental Protection Agency looking into the source of these pollutants.";
        currDialogue[24] = "Hopefully one day we can stop this pollution at the source.";
        currDialogue[25] = "For now, let us go clean up the mistakes of the past!";
        currDialogue[26] = "Onward!";
        currDialogue[27] = "";

        currDialogue[30] = "The EPA has divided the river into three area, the upper, middle and lower.";
        currDialogue[31] = "We just finished up the upper area, lets move on to the middle!";
        currDialogue[32] = "";

        currDialogue[40] = "Amazing work!";
        currDialogue[41] = "Its not just PCBs and heavy metal in this water.";
        currDialogue[42] = "Theres Arsenic which is a poison.";
        currDialogue[43] = "Theres cPAHs, which is a chemical that can cause cancer.";
        currDialogue[44] = "Finally, theres dioxins/Furans... Truly nasty stuff.";
        currDialogue[45] = "";




        // Dog text
        // before lvl2 complete
        currDialogue[120] = "Im smelling some PFAs up ahead!";
        currDialogue[121] = "";

        currDialogue[130] = "As we near the industrial area of Seattle I am detecting higher levels of toxic heavy metals.";
        currDialogue[131] = "";

        currDialogue[140] = "I can smell PCBs and other contaminants mixed with the mud at the bottom of the river!";
        currDialogue[141] = "";
    }







    private void switchDialogueImage(string name) {
        if (name.Equals("dog")) {
            dogImage.SetActive(true);
            salmonImage.SetActive(false);
            otterImage.SetActive(false);
        } else if (name.Equals("otter")) {
            dogImage.SetActive(false);
            salmonImage.SetActive(false);
            otterImage.SetActive(true);
        } else if (name.Equals("salmon")) {
            dogImage.SetActive(false);
            salmonImage.SetActive(true);
            otterImage.SetActive(false);
        }
    }


}
