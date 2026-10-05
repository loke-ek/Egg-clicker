using UnityEngine;

public class Upgrades : MonoBehaviour
{

    eggmanager eggmanagerrr;
    public normalEgg ChanceUpgrade()
    {
        // increases the chance of golden egg, while decreasing the chance of normal egg
        Debug.Log("Upgrading eggs..."); 
        eggmanagerrr.eggs[0].chance -= 10;
        eggmanagerrr.eggs[1].chance += 10;
        return null;

    }


}
