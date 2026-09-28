using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class EggRandomizer : MonoBehaviour
{
    public List<normalEgg> eggSOlist;
    [SerializeField] int totalValue;

    public void RandomizeEggs()
    {

        foreach (normalEgg card in eggSOlist)
        {
            totalValue += card.value_get;
        }


        int value = Random.Range(0, totalValue);
        foreach (normalEgg egg in eggSOlist)
        {
            value -= egg.value_get;
            if (value <= 0)
            {
                Debug.Log(egg.ToString());
                return;
            }
        }
    }

}
