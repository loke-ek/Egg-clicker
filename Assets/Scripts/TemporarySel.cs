using System.Drawing;
using TMPro;
using UnityEngine;

public class TemporarySel : MonoBehaviour
{
    public static TemporarySel Instance;

    [SerializeField] public EggSpawnScript eggSpawnScript;
    [SerializeField] public TextMeshProUGUI moneyCounter_txt;

    [SerializeField] public float Money;
    public int storedEggValue = 0;
    public void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int amount)
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.COLLECTMONEY);
        Money += amount;
        UpdateMoneyText();
    }

    public void SellEggs()
    {
        SoundEffectScript.instance.PlaySound(SoundEffectScript.SoundType.EGGCRACK);
        foreach (GameObject eggObject in eggSpawnScript.spawnedEggs)
        {
            if (eggObject != null)
            {
                Egg egg = eggObject.GetComponent<Egg>();

                if (egg != null)
                {
                    Money += egg.value;
                }

                Destroy(eggObject);
            }
        }

        Money += storedEggValue;
        storedEggValue = 0;

        eggSpawnScript.spawnedEggs.Clear();

        UpdateMoneyText();
        eggSpawnScript.EggText();
    }

    public void UpdateMoneyText()
    {
        moneyCounter_txt.text = Money.ToString();
        //moneyCounter_txt.text = "Money: <color=#D2691Eff>" + Money.ToString() + "</color>";
    }

    

}
