using System.Collections.Generic;
using UnityEngine;

public class EggSpawnScript : MonoBehaviour
{
    [SerializeField] EggRandomizer eggRandomizer;
    [SerializeField] GameObject eggPrefab;
    [SerializeField] Transform spawnPoint;

    [Header("Egg Limit")]
    [SerializeField] int maxEggs = 100;

    public List<GameObject> spawnedEggs = new List<GameObject>();

    public void SpawnEgg()
    {
        normalEgg selectedEgg = eggRandomizer.RandomizeEggs();

        if (selectedEgg == null)
            return;

        if (spawnedEggs.Count >= maxEggs)
        {
            TemporarySel.Instance.AddMoney(selectedEgg.chance_get);
            return;
        }


        GameObject newEgg = Instantiate(
            eggPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        Egg egg = newEgg.GetComponent<Egg>();

        if (egg != null)
        {
            egg.value = selectedEgg.chance_get;
        }

        newEgg.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-4,4), ForceMode2D.Impulse);
        newEgg.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-10,10),Random.Range(-2,-5),0));

        SpriteRenderer spriteRenderer = newEgg.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = selectedEgg.eggImage_get;
        }

        spawnedEggs.Add(newEgg);
    }
}