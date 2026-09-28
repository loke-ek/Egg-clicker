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
        int randomValue = Random.Range(0, totalChance);

        foreach (normalEgg egg in eggSOlist)
        {
            totalChance += egg.chance;
            if (randomValue < totalChance)
            {
                Debug.Log(egg.ToString());
                return;
            }
        }
    }

}
