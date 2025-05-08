using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    
    public TextMeshProUGUI boxText;
    private int textID;

    private Dictionary<int, string> currDialogue;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currDialogue = new Dictionary<int, string>();



    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void toggleDialogue(bool enabled) {
        boxText.SetActive(enabled);
    }

    public void changeDialogueID(int ID) {
        textID = ID;
    }
}
