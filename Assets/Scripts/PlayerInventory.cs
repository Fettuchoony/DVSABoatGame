using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    public TextMeshProUGUI speedButton;

    public TextMeshProUGUI maxSpeedButton;

    private PlayerController pc;

    public Dictionary<string, int> currUpgrades;

    public Dictionary<string,int> upgradeCosts;

    public Dictionary<string,float[]> listOfUpgrades;

    private int currency = 0;
    // public int currSpeedUpgrade = 0;
    void Start()
    {
        UpdateCurrency(0);
        pc = GetComponent<PlayerController>();
        InitUpgrades();
        speedButton.text = "Top Speed Level:" +  upgradeCosts["speed"];
        maxSpeedButton.text = "Acceleration Level: " + upgradeCosts["maxSpeed"];
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
        listOfUpgrades["speed"] = new float[7]{2f,3f,5f,8f,10f,13f,30f};

        // The current upgrade level of maxSpeed
        currUpgrades["maxSpeed"] = 0;
        //The current cost of the maxSpeed upgrade
        upgradeCosts["maxSpeed"] = 5;
        // The set 4 maxSpeed upgrades
        listOfUpgrades["maxSpeed"] = new float[4]{10f,13f,20f,27f};

    
    }

    public void speedUpgrade(){
        // First check if player can purchase upgrade
        // Second check if the current upgrade doesnt pass the list of upgrades
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
            Debug.Log(currUpgrades["maxSpeed"]);
        }
    }
}
