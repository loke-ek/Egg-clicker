using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField]eggmanager eggManager;
    normalEgg normalEgg;

    public void ChanceUpgrade()
    {
        Chance();
    }

    public normalEgg Chance()
    {
        // increases the chance of golden egg, while decreasing the chance of normal egg
        Debug.Log("Upgrading eggs..."); 
        eggManager.eggs[0].chance -= 10;
        eggManager.eggs[1].chance += 10;
        return null;

    }


}
