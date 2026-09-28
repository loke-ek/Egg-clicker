using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class EggRandomizer : MonoBehaviour
{
    public List<normalEgg> eggSOlist;
    [SerializeField] int totalChance;

    public void RandomizeEggs()
    {
        int value = Random.Range(0, totalChance);

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
