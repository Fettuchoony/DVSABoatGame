using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LateStart()
    {
        GameObject boat = GameObject.Find("Boat");
        if (boat != null) { 
            PlayerInventory inv = boat.GetComponent<PlayerInventory>();
            if (inv != null) {
                bool finishedGame = true;
                for (int i = 0; i < 9; i++) {
                    if (!inv.completedLevels[i]) {
                        finishedGame = false;
                    }
                }
                if (finishedGame) {
                    SceneManager.LoadScene("Credits");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
