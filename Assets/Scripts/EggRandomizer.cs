using System.Collections.Generic;
using UnityEngine;

public class EggRandomizer : MonoBehaviour
{
    [SerializeField] List<normalEgg> eggSOlist;

    public normalEgg RandomizeEggs()
    {
        int totalValue = 0;

        //makes the eggs spawn randomly
        foreach (normalEgg egg in eggSOlist)
        {
            totalValue += egg.chance_get;
        }

        int value = Random.Range(0, totalValue);

        //the eggs value plays a part in the randomization, the higher the value the more likely it is to be chosen
        foreach (normalEgg egg in eggSOlist)
        {
            value -= egg.chance_get;

            if (value < 0)
            {
                return egg;
            }
        }

        return null;
    }
}