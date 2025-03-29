using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    public TextMeshProUGUI speedButton;

    private PlayerController pc;

    public Dictionary<string, int> currUpgrades;

    public Dictionary<string, int> upgradeCosts;

    private int currency = int.MaxValue;
    // public int currSpeedUpgrade = 0;
    void Start()
    {
        UpdateCurrency(0);
        pc = GetComponent<PlayerController>();
        InitUpgrades();
    }

    private void UpdateCurrency(int deltaCurrency){
        currency += deltaCurrency;
        currencyText.text = "Coins: "+ currency.ToString();
    }
    private void InitUpgrades(){
        currUpgrades = new Dictionary<string, int>();
        upgradeCosts = new Dictionary<string, int>();

        // The current multiplier for the boat speed
        currUpgrades["speed"] = 0;
        upgradeCosts["speed"] = 1;

        // The current multiplier for the max speed for boat
        currUpgrades["maxSpeed"] = 0;

    
    }

    public void speedUpgrade(){
        if(upgradeCosts["speed"] <= currency){
           UpdateCurrency(-upgradeCosts["speed"]);
            currUpgrades["speed"] += 1;
            upgradeCosts["speed"] *= 2;
            speedButton.text = "speedUpgrade:" + upgradeCosts["speed"];
            pc.speed = pc.speed + 1.3f*currUpgrades["speed"];
        }
    }
    public void maxSpeedUpdgrade(){

    }

}
