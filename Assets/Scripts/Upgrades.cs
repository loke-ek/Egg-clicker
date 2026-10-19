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
    [SerializeField] public GameObject chanceButton;
    [SerializeField] public GameObject valueButton;
    [SerializeField] public int chancePrice;
    [SerializeField] public int valuePrice;
    [SerializeField] public int diamondCost;
    [SerializeField] public int rainbowCost;
    private bool diamondUnlocked = false;
    private bool rainbowUnlocked = false;
    [SerializeField] normalEgg diamondEgg;
    [SerializeField] normalEgg rainbowEgg;
    
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

    private normalEgg Chance()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
        // Check if the player has enough money for the chance upgrade
        if (tempSell.Money >= chancePrice)
        {
            chanceButton.GetComponent<Button>().interactable = true;
            tempSell.Money -= chancePrice;
            tempSell.UpdateMoneyText();
            chancePrice += 100; // Increase the price for the next upgrade
            chanceCostTXT.text = "Cost: " + chancePrice.ToString(); // Update the cost text
            chanceUpgradeLimit++; // Increase the counter of how many times youve upgraded the chance

        }
        // If the player doesn't have enough money for the chance upgrade, disable the button
        else if (tempSell.Money < chancePrice) 
        {
            chanceButton.GetComponent<Button>().interactable = false;
        }

        if (chanceUpgradeLimit >= 10)
        {
            chanceButton.GetComponent<Button>().interactable = false;
            Debug.Log("Chance upgrade limit reached");
            return null;
        }

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
        // Check if the player has enough money for the value upgrade
        if (tempSell.Money >= valuePrice)
        {
            valueButton.GetComponent<Button>().interactable = true;
            tempSell.Money -= valuePrice;
            tempSell.UpdateMoneyText();
            valuePrice *= 2; // Increase the price for the next upgrade
            valueCostTXT.text = "Cost: " + valuePrice.ToString(); // Update the cost text
            valueUpgradeLimit++; // Increase the counter of how many times youve upgraded the value

        }
        // If the player doesn't have enough money for the value upgrade, disable the button
        else if (tempSell.Money < valuePrice)
        {
            valueButton.GetComponent<Button>().interactable = false;
        }

        if (valueUpgradeLimit >= 10)
        {
            valueButton.GetComponent<Button>().interactable = false;
            Debug.Log("Value upgrade limit reached");
            return null;
        }

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
        if (diamondUnlocked)
        {
            Debug.Log("Diamond egg is already unlocked");
            return;
        }

        if (tempSell.Money < diamondCost)
        {
            Debug.Log("Not enough money for the diamond egg broke");
            return;
        }

        tempSell.AddMoney(-diamondCost);

        if (!gameManager.eggSOlist.Contains(diamondEgg))
        {
            gameManager.eggSOlist.Add(diamondEgg);
        }

        diamondUnlocked = true;

        Debug.Log("Diamond egg unlocked!");
    }

    private void RainbowEgg()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
        if (rainbowUnlocked)
        {
            Debug.Log("Rainbow egg is already unlocked");
            return;
        }

        if (tempSell.Money < rainbowCost)
        {
            Debug.Log("Not enough money for the rainbow egg broke");
            return;
        }

        tempSell.AddMoney(-rainbowCost);

        if (!gameManager.eggSOlist.Contains(rainbowEgg))
        {
            gameManager.eggSOlist.Add(rainbowEgg);
        }

        rainbowUnlocked = true;

        Debug.Log("Rainbow egg unlocked!");
    }

}
