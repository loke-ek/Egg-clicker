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

    private void Start()
    {
        AutoClicker();
        //StartCoroutine(AutoClicker());
    }
    private void Update()
    {
        //StartCoroutine(AutoClicker());
          
    }

    public void Upgrade()
    {
        if (moneyScript.Money >= cost)
        {
            if (!isActive)
            {
                isActive = true;
                Debug.Log("ACTIVE SET TO: " + isActive);
            }
        }
        else
        {
            interval *= upgradeMultiplier;
            cost *= upgradeMultiplier;
            Debug.Log("NEW VALUES: cost = " + cost + "// interval = " + interval);
        }
    }

    public IEnumerator AutoClicker()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(interval);

            spawnScript.SpawnEgg();
            Debug.Log("FINISHED AUTO COR");
        }
    }
}
