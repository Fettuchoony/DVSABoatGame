using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public string sceneName;
    public GameObject enterLevelPrompt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter() {
        enterLevelPrompt.SetActive(true);
    }

    public void EnterLevel() {
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerExit() {
        enterLevelPrompt.SetActive(false);
    }
}
