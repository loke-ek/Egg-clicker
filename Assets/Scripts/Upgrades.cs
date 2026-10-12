using System.Runtime.ExceptionServices;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField]EggRandomizer gameManager;
    [SerializeField]public GameObject chanceButton;
    [SerializeField] public GameObject valueButton;
    public void ChanceUpgrade()
    {
        Chance();
    }

    public void ValueUpgrade()
    {
        Value();
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
