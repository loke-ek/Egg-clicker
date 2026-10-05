using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField]eggmanager eggManager;
    //fix so that eggmanager is actually connected to the randomizer script 
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
        eggManager.eggs[1].chance += 5;
        eggManager.eggs[2].chance += 10;
        eggManager.eggs[3].chance += 15;
        return null;

    }

    public normalEgg Value()
    {
        Debug.Log("Upgrading eggs...");
        eggManager.eggs[0].value *= 2;
        eggManager.eggs[1].value *= 2;
        eggManager.eggs[2].value *= 2;
        eggManager.eggs[3].value *= 2;
        return null;
    }

}
