using System.Collections;
using UnityEngine;

public class Autoclicker : MonoBehaviour
{
    public float interval;
    public int cost;
    public float upgradeLevel = 1.5f;

    [SerializeField] EggSpawnScript spawnScript;
    [SerializeField] TemporarySel moneyScript;

    public void Upgrade()
    {
        if(moneyScript.Money >= cost)
        {
            //iupgrade ig
        }
    }

    public IEnumerator AutoClicker()
    {
        yield return new WaitForSeconds(interval);
        spawnScript.SpawnEgg();
    }
}
