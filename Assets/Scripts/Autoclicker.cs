using System.Collections;
using UnityEngine;

public class Autoclicker : MonoBehaviour
{
    public bool isActive = false;
    public float interval;
    public float cost;
    public float upgradeMultiplier = 1.2f;

    [SerializeField] EggSpawnScript spawnScript;
    [SerializeField] TemporarySel moneyScript;

    private void Update()
    {
        if (isActive)
        {
            //StartCoroutine(AutoClicker());
        }
          
    }

    public void Upgrade()
    {
        if (isActive)
        {
            if (moneyScript.Money >= cost)
            {
                interval *= upgradeMultiplier;
                cost *= upgradeMultiplier;
                Debug.Log("NEW VALUES: cost -- " + cost + ", interval -- " + interval);
            }
            StartCoroutine(AutoClicker());
        }
        else
        {
            isActive = true;
            Debug.Log("ACTIVE SET TO: " + isActive);
        }
    }

    public IEnumerator AutoClicker()
    {
        yield return new WaitForSeconds(interval);
        spawnScript.SpawnEgg();
        Debug.Log("FINISHED AUTO COR");
    }
}
