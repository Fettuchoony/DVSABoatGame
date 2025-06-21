using UnityEngine;



public class Bystander : MonoBehaviour
{

    public GameObject UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CorrectOption() {
        
    }

    public void IncorrectOption() {

    }

    void OnTriggerEnter() {
        UI.SetActive(true);
    }

    void OnTriggerExit() {
        UI.SetActive(false);
    }
}
