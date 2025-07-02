using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    public TextMeshProUGUI speedButton;

    public TextMeshProUGUI maxSpeedButton;

    public Dictionary<string, int> currUpgrades;

    public Dictionary<string,int> upgradeCosts;

    public Dictionary<string,float[]> listOfUpgrades;

    public bool[] completedLevels;
    private PlayerController pc;
    private BaitManager baitManager;

    private static int currency = 9999;
    // public int currSpeedUpgrade = 0;
    void Start()
    {
        UpdateCurrency(0);
        completedLevels = new bool[9];
        for (int i = 0; i < 9; i++) { completedLevels[i] = false; }
        pc = GetComponent<PlayerController>();
        InitUpgrades();
        speedButton.text = "Top Speed Level:" + upgradeCosts["speed"];
        maxSpeedButton.text = "Acceleration Level: " + upgradeCosts["maxSpeed"];
        baitManager = GameObject.Find("FishBait").GetComponent<BaitManager>();
    }

    public void UpdateCurrency(int deltaCurrency){
        currency += deltaCurrency;
        currencyText.text = currency.ToString();
    }
    private void InitUpgrades(){
        currUpgrades = new Dictionary<string, int>();
        upgradeCosts = new Dictionary<string, int>();
        listOfUpgrades = new Dictionary<string, float[]>();

        // The current upgrade level of speed
        currUpgrades["speed"] = 0;
        // The current cost of the speed upgrade
        upgradeCosts["speed"] = 1;
        // The set 7 speed upgrades
        listOfUpgrades["speed"] = new float[7]{12f,14f,16f,18f,20f,22f,24f};

        // The current upgrade level of maxSpeed
        currUpgrades["maxSpeed"] = 0;
        //The current cost of the maxSpeed upgrade
        upgradeCosts["maxSpeed"] = 5;
        // The set 4 maxSpeed upgrades
        listOfUpgrades["maxSpeed"] = new float[4]{20f,24f,28f,32f};

    
    }

    void Update() {
        // Debug.Log(currency);
    }

    public void speedUpgrade(){
        // First check if player can purchase upgrade
        // Second check if the current upgrade doesnt pass the list of upgrades
        Debug.Log(currency);
        if(upgradeCosts["speed"] <= currency && currUpgrades["speed"] < listOfUpgrades["speed"].Length-1){
            UpdateCurrency(-upgradeCosts["speed"]);
            upgradeCosts["speed"] += 2+currUpgrades["speed"];
            currUpgrades["speed"] += 1;
            speedButton.text = "Top Speed Cost:" +  upgradeCosts["speed"];
            pc.speed = listOfUpgrades["speed"][currUpgrades["speed"]];
        }
    }
    public void maxSpeedUpdgrade(){
        if(upgradeCosts["maxSpeed"] <= currency && currUpgrades["maxSpeed"] < listOfUpgrades["maxSpeed"].Length-1){
            UpdateCurrency(-upgradeCosts["maxSpeed"]);
            currUpgrades["maxSpeed"] += 1;
            upgradeCosts["maxSpeed"] *= 2;
            maxSpeedButton.text = "Acceleration Cost: " + upgradeCosts["maxSpeed"];
            pc.maxSpeed = listOfUpgrades["maxSpeed"][currUpgrades["maxSpeed"]];
            // Debug.Log(currUpgrades["maxSpeed"]);
        }
    }

    public void fishBaitPurchase()
    {
        if (currency >= 7)
        {
            UpdateCurrency(-7);
            baitManager.totalBaits += 1;
        }
    }
}
