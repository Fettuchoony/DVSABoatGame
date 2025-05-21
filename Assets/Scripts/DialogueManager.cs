using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject dialogueObject;
    public float dialogueFadeInSpeed;

    private TextMeshProUGUI  dialogue;
    private int textID;
    private string test = "WASDWASDWASDWASD";

    private Dictionary<int, string> currDialogue;

    private RectTransform rectTrans;

    private float gameTime;
    private float waitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currDialogue = new Dictionary<int, string>();
        dialogue = dialogueObject.GetComponent<TextMeshProUGUI>();
        rectTrans = dialogueObject.GetComponent<RectTransform>();
        gameTime = 0.5f;
        StartCoroutine(animatedText("Edwin I wanna get more money PLEASE!!"));
        waitTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        // dialogueObject.transform.position = Vector3.Lerp(new Vector3(0,0,0),new Vector3(0,10,0),1f);

        if(textBox.activeSelf && Time.time - waitTime > 5f){
            rectTrans.anchoredPosition = Vector3.Lerp(new Vector3(0,0,0),new Vector3(0,50,0),  gameTime);
            gameTime *= 1f + dialogueFadeInSpeed * Time.deltaTime;
        }
    }

    // void FixedUpdate()
    // {
        
    // }

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
            waitTime = Time.deltaTime;
            StartCoroutine(animatedText(currDialogue[textID]));
        }
    }

    public void changeDialogueID(int ID) {
        textID = ID;
    }
}
