using UnityEngine;

public class EggSpawnScript : MonoBehaviour
{
    [SerializeField] EggRandomizer eggRandomizer;
    [SerializeField] GameObject eggPrefab;
    [SerializeField] Transform spawnPoint;

    public void SpawnEgg()
    {
        normalEgg selectedEgg = eggRandomizer.RandomizeEggs();

        if (selectedEgg == null)
            return;

        GameObject newEgg = Instantiate(
            eggPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        SpriteRenderer spriteRenderer = newEgg.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = selectedEgg.eggImage_get;
        }
    }
}