using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject dialogueObject;
    public float dialogueFadeInSpeed;

    private TextMeshProUGUI  dialogue;
    private int textID;
    private Dictionary<int, string> currDialogue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currDialogue = new Dictionary<int, string>();
        dialogue = dialogueObject.GetComponent<TextMeshProUGUI>();
        currDialogue[-1] = "Edwin I want more Money!!!!";
        toggleDialogue(true, -1);
    }

    IEnumerator animatedText(string text){
        foreach(char c in text.ToCharArray()){
            dialogue.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void toggleDialogue(bool enabled,int textID) {
        dialogue.SetText("");
        textBox.SetActive(enabled);
        if(enabled){
            StartCoroutine(animatedText(currDialogue[textID]));
        }
    }

    public void changeDialogueID(int ID) {
        textID = ID;
    }
}
