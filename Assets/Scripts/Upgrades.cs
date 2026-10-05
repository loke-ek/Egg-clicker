using UnityEngine;

public class Upgrades : MonoBehaviour
{

    eggmanager eggmanagerrr;
    public normalEgg ChanceUpgrade()
    {
        // Implement the logic to upgrade eggs here
        Debug.Log("Upgrading eggs..."); 
        eggmanagerrr.eggs[0].chance -= 10;
        eggmanagerrr.eggs[1].chance += 10;
        return null;

    }


}
