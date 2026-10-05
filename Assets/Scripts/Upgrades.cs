using UnityEngine;

public class Upgrades : MonoBehaviour
{

    EggRandomizer eggRandomizer;
    public normalEgg ChanceUpgrade()
    {
        // increases the chance of golden egg, while decreasing the chance of normal egg
        Debug.Log("Upgrading eggs..."); 
        eggRandomizer.eggSOlist[0].chance -= 10;
        eggRandomizer.eggSOlist[1].chance += 10;
        return null;

    }


}
