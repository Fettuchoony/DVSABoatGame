using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NarrativeControl : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialoguePanel;
    public Text nameText;
    public Text dialogueText;

    [Header("Dialogue Settings")]
    public float typingSpeed = 0.05f;

    // private Queue<string> sentences;
    private bool isTyping = false;
    private string currentSentence;

    void Start()
    {
        // sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopAllCoroutines();
                dialogueText.text = currentSentence;
                isTyping = false;
            }
            else
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(string speaker, string[] dialogueLines)
    {
        dialoguePanel.SetActive(true);
        nameText.text = speaker;
        // sentences.Clear();

        // foreach (string sentence in dialogueLines)
        // {
        //     sentences.Enqueue(sentence);
        // }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // if (sentences.Count == 0)
        // {
        //     EndDialogue();
        //     return;
        // }

        // currentSentence = sentences.Dequeue();
        // StopAllCoroutines();
        // StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
