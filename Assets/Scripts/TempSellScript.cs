using TMPro;
using UnityEngine;

public class TemporarySel : MonoBehaviour
{
    public static TemporarySel Instance;

    [SerializeField] EggSpawnScript eggSpawnScript;
    [SerializeField] TextMeshProUGUI moneyCounter_txt;

    [SerializeField] int Money;

    private void Awake()
    {
        Instance = this;
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        UpdateMoneyText();
    }

    public void SellEggs()
    {
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

        eggSpawnScript.spawnedEggs.Clear();

        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyCounter_txt.text = Money.ToString();
    }
}
