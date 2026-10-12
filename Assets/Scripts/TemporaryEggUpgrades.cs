
using UnityEngine;

public class TemporaryEggUpgrades : MonoBehaviour
{
    [SerializeField] EggRandomizer eggRandomizer;
    [SerializeField] TemporarySel TempSelScript;

    [SerializeField] normalEgg diamondEgg;
    [SerializeField] normalEgg rainbowEgg;

    [SerializeField] int diamondCost = 500;
    [SerializeField] int rainbowCost = 2000;

    private bool diamondUnlocked = false;
    private bool rainbowUnlocked = false;

    public void BuyDiamondEgg()
    {
        if (diamondUnlocked)
        {
            Debug.Log("Diamond egg is already unlocked");
            return;
        }

        if (TempSelScript.Money < diamondCost)
        {
            Debug.Log("Not enough money for the diamond egg broke");
            return;
        }

        TempSelScript.AddMoney(-diamondCost);

        if (!eggRandomizer.eggSOlist.Contains(diamondEgg))
        {
            eggRandomizer.eggSOlist.Add(diamondEgg);
        }

        diamondUnlocked = true;

        Debug.Log("Diamond egg unlocked!");
    }

    public void BuyRainbowEgg()
    {
        if (rainbowUnlocked)
        {
            Debug.Log("Rainbow egg is already unlocked");
            return;
        }

        if (TempSelScript.Money < rainbowCost)
        {
            Debug.Log("Not enough money for the rainbow egg broke");
            return;
        }

        TempSelScript.AddMoney(-rainbowCost);

        if (!eggRandomizer.eggSOlist.Contains(rainbowEgg))
        {
            eggRandomizer.eggSOlist.Add(rainbowEgg);
        }

        rainbowUnlocked = true;

        Debug.Log("Rainbow egg unlocked!");
    }
}
