using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] EggRandomizer gameManager;
    [SerializeField] TemporarySel tempSell;
    [SerializeField] public GameObject chanceButton;
    [SerializeField] public GameObject valueButton;
    [SerializeField] public int chancePrice;
    [SerializeField] public int valuePrice;
    public void ChanceUpgrade()
    {
        Payment();
        Chance();
    }

    public void ValueUpgrade()
    {
        Payment();
        Value();
    }

    public void BuyUpgrade()
    {
        Payment();
    }

    void Payment()
    {
        // Check if the player has enough money for the chance upgrade
        if (tempSell.Money >= chancePrice)
        {
            tempSell.Money -= chancePrice;
            Chance();
            chancePrice += 100; // Increase the price for the next upgrade
        }
        // If the player doesn't have enough money for the chance upgrade, disable the button
        else if (tempSell.Money < chancePrice)
        {
            chanceButton.SetActive(false);
        }
        // Check if the player has enough money for the value upgrade
        if (tempSell.Money >= valuePrice)
        {
            tempSell.Money -= valuePrice;
            Value();
            valuePrice *= 2; // Increase the price for the next upgrade
        }
        // If the player doesn't have enough money for the value upgrade, disable the button
        else if (tempSell.Money < valuePrice)
        {
            valueButton.SetActive(false);
        }
    }

    public normalEgg Chance()
    {

        // increases the chance of golden egg, while decreasing the chance of normal egg
        Debug.Log("Upgrading eggs..."); 
        gameManager.eggSOlist[0].chance += 5;
        gameManager.eggSOlist[1].chance += 10;
        gameManager.eggSOlist[2].chance += 15;
        gameManager.eggSOlist[3].chance += 20;
        return null;

    }

    public normalEgg Value()
    {
        Debug.Log("Upgrading eggs...");
        gameManager.eggSOlist[0].value *= 2;
        gameManager.eggSOlist[1].value *= 2;
        gameManager.eggSOlist[2].value *= 2;
        gameManager.eggSOlist[3].value *= 2;
        return null;
    }

}
