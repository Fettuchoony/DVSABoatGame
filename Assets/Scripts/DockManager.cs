using UnityEngine;

public class DockManager : MonoBehaviour
{

    public GameObject openShopUI;

    public GameObject shopButton;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openShopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter () {
        shopButton.SetActive(true);
    }

    void OnTriggerStay () {
        Debug.Log("In buy zone!");
        openShopUI.SetActive(true);
    }

    void OnTriggerExit() {
        openShopUI.SetActive(false);
    }
    
}
