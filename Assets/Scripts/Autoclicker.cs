using System.Collections;
using TMPro;
using UnityEngine;

public class Autoclicker : MonoBehaviour
{
    public bool isActive = false;
    public float interval;
    public float cost;
    public float upgradeMultiplier = 1.5f;
    // public float upgradeMax = 0.25f;

    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] EggSpawnScript spawnScript;
    [SerializeField] TemporarySel moneyScript;
    [SerializeField] GameObject buyButton;

    private void Start()
    {
        AutoClicker();
    }

    private void Update()
    {
        if(moneyScript.Money >= cost)
        {
            buyButton.SetActive(true);

        } else if(moneyScript.Money < cost)
        {
            buyButton.SetActive(false);
        }
    }

    public void Upgrade()
    {
        if (moneyScript.Money >= cost) // Checks if you can afford the upgrade
        {
            if (!isActive) // If you haven't bought it yet, buy and unlock the Autoclicker
            {
                isActive = true;
                moneyScript.Money -= cost;
                moneyScript.UpdateMoneyText();


                SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.COLLECTMONEY);

                cost *= upgradeMultiplier;

                costText.text = cost.ToString();

                Debug.Log("ACTIVE SET TO: " + isActive);
                StartCoroutine(AutoClicker());
                Debug.Log("AUTOCOR STARTED");
                return;
            }
            else // If you HAVE bought it already, upgrade the Autoclicker
            {
                moneyScript.Money -= cost;
                moneyScript.UpdateMoneyText();

                interval /= upgradeMultiplier;
                cost *= upgradeMultiplier;

                costText.text = cost.ToString();

                Debug.Log("NEW VALUES: cost = " + cost + "// interval = " + interval);
                return;
            }
        }
        else
        {
            Debug.Log("NOT ENOUGH MONEY");
            SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.CLICK);
            return;
        }
    }

    public IEnumerator AutoClicker()
    {
        while (isActive)
        {
            spawnScript.SpawnEgg();
            yield return new WaitForSeconds(interval);
            Debug.Log("FINISHED AUTO COR");
        }
    }
}
