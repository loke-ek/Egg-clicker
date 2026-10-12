using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("References")]
    [SerializeField] EggRandomizer gameManager;
    [SerializeField] TemporarySel tempSell;

    [Header("Upgrade Settings")]
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
        // Check if the player has enough money for the chance upgrade
        if (tempSell.Money >= chancePrice)
        {
            chanceButton.GetComponent<Button>().interactable = true;
            tempSell.Money -= chancePrice;
            tempSell.UpdateMoneyText();
            chancePrice += 100; // Increase the price for the next upgrade
        }
        // If the player doesn't have enough money for the chance upgrade, disable the button
        else if (tempSell.Money < chancePrice)
        {
            chanceButton.GetComponent<Button>().interactable = false;
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
        // Check if the player has enough money for the value upgrade
        if (tempSell.Money >= valuePrice)
        {
            valueButton.GetComponent<Button>().interactable = true;
            tempSell.Money -= valuePrice;
            tempSell.UpdateMoneyText();
            valuePrice *= 2; // Increase the price for the next upgrade
        }
        // If the player doesn't have enough money for the value upgrade, disable the button
        else if (tempSell.Money < valuePrice)
        {
            valueButton.GetComponent<Button>().interactable = false;
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
