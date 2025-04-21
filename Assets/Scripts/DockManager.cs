using UnityEngine;

public class DockManager : MonoBehaviour
{

    public GameObject openShopUI;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openShopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay () {
        Debug.Log("In buy zone!");
        openShopUI.SetActive(true);
    }

    void OnTriggerExit() {
        openShopUI.SetActive(false);
    }
    
}
