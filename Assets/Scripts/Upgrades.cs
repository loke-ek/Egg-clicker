using System.Diagnostics.Metrics;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//add so that after you buy the upgrades a certain amoutn of times, your enot allowed to anymlore
public class Upgrades : MonoBehaviour
{
    [Header("References")]
    [SerializeField] EggRandomizer gameManager;
    [SerializeField] TemporarySel tempSell;
    [SerializeField] sceneScript sceneScript;

    [Header("Upgrade Settings")]
    [SerializeField] public int chanceUpgradeLimit = 0;
    [SerializeField] public int valueUpgradeLimit = 0;
    [SerializeField] public TextMeshProUGUI chanceCostTXT;
    [SerializeField] public TextMeshProUGUI valueCostTXT;
    [SerializeField] public TextMeshProUGUI diamondEggTXT;
    [SerializeField] public TextMeshProUGUI rainbowEggTXT;
    [SerializeField] public GameObject chanceButton;
    [SerializeField] public GameObject valueButton;
    [SerializeField] public GameObject diamondEggButton;
    [SerializeField] public GameObject rainbowEggButton;
    [SerializeField] public int chancePrice;
    [SerializeField] public int valuePrice;
    [SerializeField] public int diamondCost;
    [SerializeField] public int rainbowCost;
    private bool diamondUnlocked = false;
    private bool rainbowUnlocked = false;
    [SerializeField] normalEgg diamondEgg;
    [SerializeField] normalEgg rainbowEgg;

    public void Update()
    {
        MoneyCheckChance();
        MoneyCheckValue();
        MoneyCheckDiamond();
        MoneyCheckRainbow();
    }

    public void ChanceUpgrade()
    {
        Chance();
    }

    public void ValueUpgrade()
    {
        Value();
    }

    public void BuyDiamondEgg()
    {
        DiamondEgg();
    }

    public void BuyRainbowEgg()
    {
        RainbowEgg();
    }


    // Check if the player has enough money for the chance upgrade
    public void MoneyCheckChance()
    {
        if (chanceUpgradeLimit >= 10)
        {
            chanceCostTXT.text = "Maxed";
            chanceButton.GetComponent<Button>().interactable = false;
            Debug.Log("Chance upgrade limit reached");
            return;
        }

        if (tempSell.Money >= chancePrice)
        {
            chanceButton.GetComponent<Button>().interactable = true;
        }
        // If the player doesn't have enough money for the chance upgrade, disable the button
        else if (tempSell.Money < chancePrice)
        {
            chanceButton.GetComponent<Button>().interactable = false;
            return;
        }
    }

    // Check if the player has enough money for the value upgrade
    public void MoneyCheckValue()
    {
        if (valueUpgradeLimit >= 10)
        {
            valueCostTXT.text = "Maxed";
            valueButton.GetComponent<Button>().interactable = false;
            Debug.Log("Value upgrade limit reached");
            return;
        }

        if (tempSell.Money >= valuePrice)
        {
            valueButton.GetComponent<Button>().interactable = true;
        }
        else if (tempSell.Money < valuePrice)
        {
            valueButton.GetComponent<Button>().interactable = false;
            return;
        }
    }

    // Check if the player has enough money for the diamond egg
    public void MoneyCheckDiamond()
    {
        if (diamondUnlocked)
        {
            Debug.Log("Diamond egg is already unlocked");
            diamondEggButton.GetComponent<Button>().interactable = false;
            diamondEggTXT.text = "Unlocked";
            return;
        }
        if (tempSell.Money >= diamondCost)
        {
            diamondEggButton.GetComponent<Button>().interactable = true;
        }
        else if (tempSell.Money < diamondCost)
        {
            diamondEggButton.GetComponent<Button>().interactable = false;
            return;
        }
        
    }

    public void MoneyCheckRainbow()
    {
        if (rainbowUnlocked)
        {
            Debug.Log("Rainbow egg is already unlocked");
            rainbowEggButton.GetComponent<Button>().interactable = false;
            rainbowEggTXT.text = "Unlocked";
            return;
        }
        if (tempSell.Money >= rainbowCost)
        {
            rainbowEggButton.GetComponent<Button>().interactable = true;
        }
        else if (tempSell.Money < rainbowCost)
        {
            rainbowEggButton.GetComponent<Button>().interactable = false;
            return;
        }
        
    }

    private normalEgg Chance()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
        // Check if the player has enough money for the chance upgrade
        
            tempSell.Money -= chancePrice;
            tempSell.UpdateMoneyText();
            chancePrice += 100; // Increase the price for the next upgrade
            chanceCostTXT.text = chancePrice.ToString(); // Update the cost text
            chanceUpgradeLimit++; // Increase the counter of how many times youve upgraded the chance

        
        

        // increases the chance of golden egg, while decreasing the chance of normal egg
        Debug.Log("Upgrading eggs...");
        gameManager.eggSOlist[0].chance += 5;
        gameManager.eggSOlist[1].chance += 10;
        gameManager.eggSOlist[2].chance += 15;
        gameManager.eggSOlist[3].chance += 20;
        return null;

    }

    private normalEgg Value()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
        
        
            tempSell.Money -= valuePrice;
            tempSell.UpdateMoneyText();
            valuePrice *= 2; // Increase the price for the next upgrade
            valueCostTXT.text = valuePrice.ToString(); // Update the cost text
            valueUpgradeLimit++; // Increase the counter of how many times youve upgraded the value

       

        Debug.Log("Upgrading eggs...");
        gameManager.eggSOlist[0].value *= 2;
        gameManager.eggSOlist[1].value *= 2;
        gameManager.eggSOlist[2].value *= 2;
        gameManager.eggSOlist[3].value *= 2;
        return null;
    }

    private void DiamondEgg()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
        tempSell.AddMoney(-diamondCost);
        diamondUnlocked = true;
        gameManager.eggSOlist.Add(diamondEgg);
        
    }

    private void RainbowEgg()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
        tempSell.AddMoney(-rainbowCost);
        rainbowUnlocked = true;
        gameManager.eggSOlist.Add(rainbowEgg);
    }

}
