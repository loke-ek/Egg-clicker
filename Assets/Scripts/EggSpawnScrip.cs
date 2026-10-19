using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EggSpawnScript : MonoBehaviour
{
    [SerializeField] EggRandomizer eggRandomizer;
    [SerializeField] GameObject eggPrefab;
    [SerializeField] Transform spawnPoint;

    [Header("Egg Limit")]
    [SerializeField] int maxEggs = 100;

    public List<GameObject> spawnedEggs = new List<GameObject>();
    [SerializeField] public TextMeshProUGUI eggsText;

    public void SpawnEgg()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICKCHICK);
        normalEgg selectedEgg = eggRandomizer.RandomizeEggs();

        if (selectedEgg == null)
            return;

        if (spawnedEggs.Count >= maxEggs)
        {
            TemporarySel.Instance.storedEggValue += selectedEgg.value_get;
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
            egg.value = selectedEgg.value_get;
        }

        newEgg.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-4,4), ForceMode2D.Impulse);
        newEgg.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-10,10),Random.Range(-2,-5),0));

        SpriteRenderer spriteRenderer = newEgg.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = selectedEgg.eggImage_get;
        }

        spawnedEggs.Add(newEgg);
        EggText();
    }

    public void EggText()
    {
        eggsText.text = "Eggs: " + spawnedEggs.Count.ToString();
    }
}